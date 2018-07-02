namespace IntroWinForms
{
    partial class MainForm
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.pbcSource = new System.Windows.Forms.PictureBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.pbxDest = new System.Windows.Forms.PictureBox();
            this.lstConverts = new System.Windows.Forms.ListBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtGamma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbcSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDest)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(29, 28);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = ",Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pbcSource
            // 
            this.pbcSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbcSource.Location = new System.Drawing.Point(147, 28);
            this.pbcSource.Name = "pbcSource";
            this.pbcSource.Size = new System.Drawing.Size(397, 447);
            this.pbcSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbcSource.TabIndex = 2;
            this.pbcSource.TabStop = false;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(29, 57);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(100, 23);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Преобразовать";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // pbxDest
            // 
            this.pbxDest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxDest.Location = new System.Drawing.Point(550, 28);
            this.pbxDest.Name = "pbxDest";
            this.pbxDest.Size = new System.Drawing.Size(421, 447);
            this.pbxDest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxDest.TabIndex = 4;
            this.pbxDest.TabStop = false;
            // 
            // lstConverts
            // 
            this.lstConverts.FormattingEnabled = true;
            this.lstConverts.Location = new System.Drawing.Point(29, 94);
            this.lstConverts.Name = "lstConverts";
            this.lstConverts.Size = new System.Drawing.Size(100, 121);
            this.lstConverts.TabIndex = 5;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(29, 240);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(100, 20);
            this.txtC.TabIndex = 6;
            // 
            // txtGamma
            // 
            this.txtGamma.Location = new System.Drawing.Point(29, 281);
            this.txtGamma.Name = "txtGamma";
            this.txtGamma.Size = new System.Drawing.Size(100, 20);
            this.txtGamma.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "C:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Gamma:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 488);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGamma);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.lstConverts);
            this.Controls.Add(this.pbxDest);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.pbcSource);
            this.Controls.Add(this.btnOpen);
            this.Name = "MainForm";
            this.Text = "Image Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pbcSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.PictureBox pbcSource;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.PictureBox pbxDest;
        private System.Windows.Forms.ListBox lstConverts;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtGamma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

