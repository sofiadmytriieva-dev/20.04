namespace WinFormsApp1
{
    partial class Form1
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
            picMeme = new PictureBox();
            btnPrevious = new Button();
            btnNext = new Button();
            ((System.ComponentModel.ISupportInitialize)picMeme).BeginInit();
            SuspendLayout();
            // 
            // picMeme
            // 
            picMeme.Location = new Point(210, 79);
            picMeme.Name = "picMeme";
            picMeme.Size = new Size(353, 215);
            picMeme.TabIndex = 0;
            picMeme.TabStop = false;
            picMeme.Click += pictureBox1_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(58, 382);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 23);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "назад";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click_1;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(697, 382);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 2;
            btnNext.Text = "вперед";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(picMeme);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picMeme).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picMeme;
        private Button btnPrevious;
        private Button btnNext;
    }
}
