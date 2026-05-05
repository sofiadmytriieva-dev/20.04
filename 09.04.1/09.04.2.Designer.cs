namespace _09._04._2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lstLines = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Location = new System.Drawing.Point(86, 172);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(100, 31);
            this.txtSearchWord.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(86, 106);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(231, 36);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Шукати у файлі";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(510, 93);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(250, 25);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Результат з\'явиться тут";
            // 
            // lstLines
            // 
            this.lstLines.FormattingEnabled = true;
            this.lstLines.ItemHeight = 25;
            this.lstLines.Location = new System.Drawing.Point(113, 281);
            this.lstLines.Name = "lstLines";
            this.lstLines.Size = new System.Drawing.Size(120, 79);
            this.lstLines.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstLines);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchWord);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ListBox lstLines;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

