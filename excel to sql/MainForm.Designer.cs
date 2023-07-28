namespace excel_to_sql
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            excelAcBtn = new Button();
            sqlCevirBtn = new Button();
            openFileDialog1 = new OpenFileDialog();
            tableNameTxt = new TextBox();
            label1 = new Label();
            sqlKodlariTxt = new RichTextBox();
            colStartRowTxt = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // excelAcBtn
            // 
            excelAcBtn.Location = new Point(226, 22);
            excelAcBtn.Name = "excelAcBtn";
            excelAcBtn.Size = new Size(562, 51);
            excelAcBtn.TabIndex = 0;
            excelAcBtn.Text = "Excel Dosyası Aç";
            excelAcBtn.UseVisualStyleBackColor = true;
            excelAcBtn.Click += excelAcBtn_Click;
            // 
            // sqlCevirBtn
            // 
            sqlCevirBtn.Location = new Point(505, 97);
            sqlCevirBtn.Name = "sqlCevirBtn";
            sqlCevirBtn.Size = new Size(283, 70);
            sqlCevirBtn.TabIndex = 1;
            sqlCevirBtn.Text = "Tabloyu SQL'e Çevir";
            sqlCevirBtn.UseVisualStyleBackColor = true;
            sqlCevirBtn.Click += sqlCevirBtn_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableNameTxt
            // 
            tableNameTxt.Location = new Point(357, 97);
            tableNameTxt.Name = "tableNameTxt";
            tableNameTxt.Size = new Size(130, 23);
            tableNameTxt.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(226, 100);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 3;
            label1.Text = "Tablo İsmi";
            // 
            // sqlKodlariTxt
            // 
            sqlKodlariTxt.Location = new Point(226, 198);
            sqlKodlariTxt.Name = "sqlKodlariTxt";
            sqlKodlariTxt.Size = new Size(562, 223);
            sqlKodlariTxt.TabIndex = 4;
            sqlKodlariTxt.Text = "";
            // 
            // colStartRowTxt
            // 
            colStartRowTxt.Location = new Point(357, 144);
            colStartRowTxt.Name = "colStartRowTxt";
            colStartRowTxt.Size = new Size(130, 23);
            colStartRowTxt.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(226, 148);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 9;
            label2.Text = "Kolon Başlangıç Satırı";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(colStartRowTxt);
            Controls.Add(sqlKodlariTxt);
            Controls.Add(label1);
            Controls.Add(tableNameTxt);
            Controls.Add(sqlCevirBtn);
            Controls.Add(excelAcBtn);
            Name = "Form1";
            Text = "Excel To SQL";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button excelAcBtn;
        private Button sqlCevirBtn;
        private OpenFileDialog openFileDialog1;
        private TextBox tableNameTxt;
        private Label label1;
        private RichTextBox sqlKodlariTxt;
        private TextBox colStartRowTxt;
        private Label label2;
    }
}