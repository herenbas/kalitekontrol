namespace DeskoScanSample
{
    partial class ScanLightSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.listBoxScanFlags = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkUse = new System.Windows.Forms.CheckBox();
            this.textBoxShutterWidth = new System.Windows.Forms.TextBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.listBoxScanFlags);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.checkUse);
            this.groupBox.Controls.Add(this.textBoxShutterWidth);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(177, 195);
            this.groupBox.TabIndex = 21;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Infrared";
            // 
            // listBoxScanFlags
            // 
            this.listBoxScanFlags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxScanFlags.FormattingEnabled = true;
            this.listBoxScanFlags.Location = new System.Drawing.Point(6, 39);
            this.listBoxScanFlags.Name = "listBoxScanFlags";
            this.listBoxScanFlags.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxScanFlags.Size = new System.Drawing.Size(165, 147);
            this.listBoxScanFlags.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "SW factor";
            // 
            // checkUse
            // 
            this.checkUse.AutoSize = true;
            this.checkUse.Checked = true;
            this.checkUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUse.Location = new System.Drawing.Point(9, 18);
            this.checkUse.Name = "checkUse";
            this.checkUse.Size = new System.Drawing.Size(45, 17);
            this.checkUse.TabIndex = 16;
            this.checkUse.Text = "Use";
            this.checkUse.UseVisualStyleBackColor = true;
            // 
            // textBoxShutterWidth
            // 
            this.textBoxShutterWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxShutterWidth.Location = new System.Drawing.Point(121, 17);
            this.textBoxShutterWidth.Name = "textBoxShutterWidth";
            this.textBoxShutterWidth.Size = new System.Drawing.Size(50, 20);
            this.textBoxShutterWidth.TabIndex = 18;
            this.textBoxShutterWidth.Text = "1";
            this.textBoxShutterWidth.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxShutterWidth_Validating);
            // 
            // ScanLightSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "ScanLightSettings";
            this.Size = new System.Drawing.Size(177, 195);
            this.Load += new System.EventHandler(this.ScanLightSettings_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        public System.Windows.Forms.ListBox listBoxScanFlags;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox checkUse;
        public System.Windows.Forms.TextBox textBoxShutterWidth;
    }
}
