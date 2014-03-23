namespace ReceiptScanSandbox
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmdSetupScanner = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.imageBox1 = new Cyotek.Windows.Forms.ImageBox();
            this.chkShowOptimizedImage = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.chkContrast = new System.Windows.Forms.CheckBox();
            this.chkStraighten = new System.Windows.Forms.CheckBox();
            this.chkCrop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Scan Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Open Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmdSetupScanner
            // 
            this.cmdSetupScanner.Location = new System.Drawing.Point(12, 70);
            this.cmdSetupScanner.Name = "cmdSetupScanner";
            this.cmdSetupScanner.Size = new System.Drawing.Size(180, 23);
            this.cmdSetupScanner.TabIndex = 2;
            this.cmdSetupScanner.Text = "Setup Scanner";
            this.cmdSetupScanner.UseVisualStyleBackColor = true;
            this.cmdSetupScanner.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Choose Scanner";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 128);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(180, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(180, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // imageBox1
            // 
            this.imageBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox1.Location = new System.Drawing.Point(198, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(374, 337);
            this.imageBox1.TabIndex = 6;
            // 
            // chkShowOptimizedImage
            // 
            this.chkShowOptimizedImage.AutoSize = true;
            this.chkShowOptimizedImage.Location = new System.Drawing.Point(12, 186);
            this.chkShowOptimizedImage.Name = "chkShowOptimizedImage";
            this.chkShowOptimizedImage.Size = new System.Drawing.Size(66, 17);
            this.chkShowOptimizedImage.TabIndex = 7;
            this.chkShowOptimizedImage.Text = "Optimize";
            this.chkShowOptimizedImage.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(83, 232);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown1.TabIndex = 8;
            // 
            // chkContrast
            // 
            this.chkContrast.AutoSize = true;
            this.chkContrast.Location = new System.Drawing.Point(12, 235);
            this.chkContrast.Name = "chkContrast";
            this.chkContrast.Size = new System.Drawing.Size(65, 17);
            this.chkContrast.TabIndex = 9;
            this.chkContrast.Text = "Contrast";
            this.chkContrast.UseVisualStyleBackColor = true;
            // 
            // chkStraighten
            // 
            this.chkStraighten.AutoSize = true;
            this.chkStraighten.Location = new System.Drawing.Point(12, 258);
            this.chkStraighten.Name = "chkStraighten";
            this.chkStraighten.Size = new System.Drawing.Size(74, 17);
            this.chkStraighten.TabIndex = 10;
            this.chkStraighten.Text = "Straighten";
            this.chkStraighten.UseVisualStyleBackColor = true;
            // 
            // chkCrop
            // 
            this.chkCrop.AutoSize = true;
            this.chkCrop.Location = new System.Drawing.Point(12, 281);
            this.chkCrop.Name = "chkCrop";
            this.chkCrop.Size = new System.Drawing.Size(48, 17);
            this.chkCrop.TabIndex = 11;
            this.chkCrop.Text = "Crop";
            this.chkCrop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.chkCrop);
            this.Controls.Add(this.chkStraighten);
            this.Controls.Add(this.chkContrast);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.chkShowOptimizedImage);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cmdSetupScanner);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cmdSetupScanner;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private Cyotek.Windows.Forms.ImageBox imageBox1;
        private System.Windows.Forms.CheckBox chkShowOptimizedImage;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox chkContrast;
        private System.Windows.Forms.CheckBox chkStraighten;
        private System.Windows.Forms.CheckBox chkCrop;
    }
}

