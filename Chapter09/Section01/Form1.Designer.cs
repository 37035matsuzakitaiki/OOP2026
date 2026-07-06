namespace Section01 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            dtpDate = new DateTimePicker();
            取得 = new Button();
            tbOut = new TextBox();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(36, 28);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(203, 39);
            dtpDate.TabIndex = 0;
            // 
            // 取得
            // 
            取得.Location = new Point(342, 28);
            取得.Name = "取得";
            取得.Size = new Size(114, 39);
            取得.TabIndex = 1;
            取得.Text = "取得";
            取得.UseVisualStyleBackColor = true;
            取得.Click += button1_Click;
            // 
            // tbOut
            // 
            tbOut.Location = new Point(57, 144);
            tbOut.Name = "tbOut";
            tbOut.Size = new Size(100, 23);
            tbOut.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 554);
            Controls.Add(tbOut);
            Controls.Add(取得);
            Controls.Add(dtpDate);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDate;
        private Button 取得;
        private TextBox tbOut;
    }
}
