using OfficeOpenXml;
using System.Text;
using static OfficeOpenXml.ExcelErrorValue;

namespace excel_to_sql
{
    public partial class MainForm : Form
    {
        private string selectedExcelFilePath;
        private List<CheckBox> colCheckBox;

        public MainForm()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            colCheckBox = new List<CheckBox>();
        }

        private void LoadColumnCheckboxesFromExcel(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;

            try
            {
                if (!int.TryParse(colStartRowTxt.Text, out int columnStartRow) || columnStartRow < 1)
                {
                    MessageBox.Show("Lütfen geçerli bir kolon baþlangýç satýrý numarasý girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int colCount = worksheet.Dimension.Columns;

                    //Kolonlar kullanýcýnýn verdiði satýrdan baþladýðý kabul edilir
                    int topMargin = 50;
                    int leftMargin = 10;
                    int checkboxHeight = 20;
                    int checkboxSpacing = 25;

                    for (int col = 1; col <= colCount; col++)
                    {
                        string columnName = worksheet.Cells[columnStartRow, col].Text;

                        CheckBox checkBox = new CheckBox();
                        checkBox.Text = columnName;
                        checkBox.AutoSize = true;
                        checkBox.Location = new System.Drawing.Point(leftMargin, topMargin + col * checkboxSpacing);
                        checkBox.BackColor = System.Drawing.Color.AliceBlue;
                        this.Controls.Add(checkBox);

                        colCheckBox.Add(checkBox);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluþtu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excelAcBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) ;
            {
                openFileDialog1.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedExcelFilePath = openFileDialog1.FileName;

                    ClearColumnCheckboxes();

                    LoadColumnCheckboxesFromExcel(selectedExcelFilePath);
                }
            }
        }

        private void ClearColumnCheckboxes()
        {
            foreach (CheckBox checkBox in colCheckBox)
            {
                this.Controls.Remove(checkBox);
                checkBox.Dispose();
            }

            colCheckBox.Clear();
        }

        //private void sqlCevirBtn_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(selectedExcelFilePath))
        //    {
        //        MessageBox.Show("Lütfen önce bir Excel Dosyasý Seçiniz.");
        //        return;
        //    }

        //    if (!int.TryParse(colBaslangicSatirTxt.Text, out int columnStartRow) || columnStartRow < 1)
        //    {
        //        MessageBox.Show("Lütfen geçerli bir kolon baþlangýç satýrý numarasý girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    try
        //    {
        //        using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(selectedExcelFilePath)))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assume the first sheet contains the table data
        //            int rowCount = worksheet.Dimension.Rows;
        //            int colCount = worksheet.Dimension.Columns;

        //            // Assuming the column names start at the user-provided row number
        //            string tableName = "YourTableName";
        //            StringBuilder sbSqlCommands = new StringBuilder();

        //            // Get column names
        //            string[] columnNames = new string[colCount];
        //            for (int col = 1; col <= colCount; col++)
        //            {
        //                columnNames[col - 1] = worksheet.Cells[columnStartRow, col].Text;
        //            }

        //            // Generate SQL commands
        //            for (int row = columnStartRow + 1; row <= rowCount; row++)
        //            {
        //                string[] values = new string[colCount];
        //                for (int col = 1; col <= colCount; col++)
        //                {
        //                    values[col - 1] = worksheet.Cells[row, col].Text;
        //                }

        //                string sqlRow = $"({string.Join(",", values)})";
        //                sbSqlCommands.Append(sqlRow);

        //                if (row != rowCount)
        //                {
        //                    sbSqlCommands.Append(", ");
        //                }
        //            }

        //            string sqlInsert = $"INSERT INTO {tableName} ({string.Join(",", columnNames)}) VALUES ";
        //            sqlKodlariTxt.Text = sqlInsert + sbSqlCommands.ToString();
        //        }

        //        MessageBox.Show("SQL Komutu Baþarýyla Oluþturuldu");
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show($"Bir Hata Oluþtu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void sqlCevirBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedExcelFilePath))
            {
                MessageBox.Show("Lütfen önce bir Excel dosyasý seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(colStartRowTxt.Text, out int columnStartRow) || columnStartRow < 1)
            {
                MessageBox.Show("Lütfen geçerli bir kolon baþlangýç satýrý numarasý girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(selectedExcelFilePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assume the first sheet contains the table data
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    // Assuming the column names start at the user-provided row number
                    string tableName = tableNameTxt.Text;
                    StringBuilder sbSqlCommands = new StringBuilder();

                    // Get column names and selected columns from CheckBoxes
                    List<string> columnNames = new List<string>();
                    List<int> selectedColumns = new List<int>();

                    for (int col = 1; col <= colCount; col++)
                    {
                        if (colCheckBox[col - 1].Checked)
                        {
                            columnNames.Add(worksheet.Cells[columnStartRow, col].Text);
                            selectedColumns.Add(col);
                        }
                    }

                    // Generate SQL commands
                    for (int row = columnStartRow + 1; row <= rowCount; row++)
                    {
                        List<string> values = new List<string>();
                        foreach (int col in selectedColumns)
                        {
                            values.Add(worksheet.Cells[row, col].Text);
                        }

                        string sqlRow = $"({string.Join(",", values)})";
                        sbSqlCommands.Append(sqlRow);

                        if (row != rowCount)
                        {
                            sbSqlCommands.Append(", ");
                        }
                    }

                    string sqlInsert = $"INSERT INTO {tableName} ({string.Join(",", columnNames)}) VALUES ";
                    sqlKodlariTxt.Text = sqlInsert + sbSqlCommands.ToString();
                }

                MessageBox.Show("Veriler SQL komutlarýna baþarýyla dönüþtürüldü.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluþtu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
