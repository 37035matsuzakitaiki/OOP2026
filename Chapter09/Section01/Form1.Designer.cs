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
            dtpBirth = new DateTimePicker();
            取得 = new Button();
            tbOut = new TextBox();
            nudDay = new NumericUpDown();
            label1 = new Label();
            btBirthCalc = new Button();
            生年月日 = new Label();
            dateTimePicker1 = new DateTimePicker();
            tbOut2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            tbOut3 = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // dtpBirth
            // 
            dtpBirth.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpBirth.Location = new Point(36, 249);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(203, 39);
            dtpBirth.TabIndex = 0;
            // 
            // 取得
            // 
            取得.Location = new Point(301, 28);
            取得.Name = "取得";
            取得.Size = new Size(114, 39);
            取得.TabIndex = 1;
            取得.Text = "取得";
            取得.UseVisualStyleBackColor = true;
            取得.Click += button1_Click;
            // 
            // tbOut
            // 
            tbOut.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbOut.Location = new Point(119, 312);
            tbOut.Name = "tbOut";
            tbOut.Size = new Size(407, 39);
            tbOut.TabIndex = 2;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudDay.Location = new Point(175, 129);
            nudDay.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 46);
            nudDay.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(301, 137);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 4;
            label1.Text = "日後";
            // 
            // btBirthCalc
            // 
            btBirthCalc.Location = new Point(301, 247);
            btBirthCalc.Name = "btBirthCalc";
            btBirthCalc.Size = new Size(97, 41);
            btBirthCalc.TabIndex = 5;
            btBirthCalc.Text = "計算";
            btBirthCalc.UseVisualStyleBackColor = true;
            btBirthCalc.Click += btBirthCalc_Click;
            // 
            // 生年月日
            // 
            生年月日.AutoSize = true;
            生年月日.Location = new Point(49, 215);
            生年月日.Name = "生年月日";
            生年月日.Size = new Size(55, 15);
            生年月日.TabIndex = 6;
            生年月日.Text = "生年月日";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dateTimePicker1.Location = new Point(49, 28);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(203, 39);
            dateTimePicker1.TabIndex = 0;
            // 
            // tbOut2
            // 
            tbOut2.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbOut2.Location = new Point(119, 369);
            tbOut2.Name = "tbOut2";
            tbOut2.Size = new Size(407, 39);
            tbOut2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 329);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 7;
            label2.Text = "年齢";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 386);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 8;
            label3.Text = "経過日数";
            // 
            // tbOut3
            // 
            tbOut3.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbOut3.Location = new Point(119, 431);
            tbOut3.Multiline = true;
            tbOut3.Name = "tbOut3";
            tbOut3.Size = new Size(407, 93);
            tbOut3.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 457);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 9;
            label4.Text = "メモ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 568);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(生年月日);
            Controls.Add(btBirthCalc);
            Controls.Add(label1);
            Controls.Add(nudDay);
            Controls.Add(tbOut3);
            Controls.Add(tbOut2);
            Controls.Add(tbOut);
            Controls.Add(取得);
            Controls.Add(dateTimePicker1);
            Controls.Add(dtpBirth);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpBirth;
        private Button 取得;
        private TextBox tbOut;
        private NumericUpDown nudDay;
        private Label label1;
        private Button btBirthCalc;
        private Label 生年月日;
        private DateTimePicker dateTimePicker1;
        private TextBox tbOut2;
        private Label label2;
        private Label label3;
        private TextBox tbOut3;
        private Label label4;
    }
}
