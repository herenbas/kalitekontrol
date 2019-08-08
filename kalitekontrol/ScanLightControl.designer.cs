namespace kalitekontrol
{
    partial class ScanLightControl
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPane = new System.Windows.Forms.TabPage();
            this.PicturePane = new System.Windows.Forms.PictureBox();
            this.tabDoc = new System.Windows.Forms.TabPage();
            this.PictureDoc = new System.Windows.Forms.PictureBox();
            this.tabFace = new System.Windows.Forms.TabPage();
            this.PictureFace = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicturePane)).BeginInit();
            this.tabDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDoc)).BeginInit();
            this.tabFace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureFace)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPane);
            this.tabControl.Controls.Add(this.tabDoc);
            this.tabControl.Controls.Add(this.tabFace);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(214, 286);
            this.tabControl.TabIndex = 6;
            // 
            // tabPane
            // 
            this.tabPane.Controls.Add(this.PicturePane);
            this.tabPane.Location = new System.Drawing.Point(4, 22);
            this.tabPane.Name = "tabPane";
            this.tabPane.Padding = new System.Windows.Forms.Padding(3);
            this.tabPane.Size = new System.Drawing.Size(206, 260);
            this.tabPane.TabIndex = 0;
            this.tabPane.Text = "BUYUK RESIM";
            this.tabPane.UseVisualStyleBackColor = true;
            // 
            // PicturePane
            // 
            this.PicturePane.BackColor = System.Drawing.SystemColors.ControlText;
            this.PicturePane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicturePane.Cursor = System.Windows.Forms.Cursors.Default;
            this.PicturePane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicturePane.Location = new System.Drawing.Point(3, 3);
            this.PicturePane.Name = "PicturePane";
            this.PicturePane.Size = new System.Drawing.Size(200, 254);
            this.PicturePane.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicturePane.TabIndex = 1;
            this.PicturePane.TabStop = false;
            this.PicturePane.Click += new System.EventHandler(this.picture_Click);
            // 
            // tabDoc
            // 
            this.tabDoc.Controls.Add(this.PictureDoc);
            this.tabDoc.Location = new System.Drawing.Point(4, 22);
            this.tabDoc.Name = "tabDoc";
            this.tabDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoc.Size = new System.Drawing.Size(206, 260);
            this.tabDoc.TabIndex = 1;
            this.tabDoc.Text = "Doc";
            this.tabDoc.UseVisualStyleBackColor = true;
            // 
            // PictureDoc
            // 
            this.PictureDoc.BackColor = System.Drawing.SystemColors.ControlText;
            this.PictureDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureDoc.Location = new System.Drawing.Point(3, 3);
            this.PictureDoc.Name = "PictureDoc";
            this.PictureDoc.Size = new System.Drawing.Size(200, 254);
            this.PictureDoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureDoc.TabIndex = 2;
            this.PictureDoc.TabStop = false;
            this.PictureDoc.Click += new System.EventHandler(this.picture_Click);
            // 
            // tabFace
            // 
            this.tabFace.Controls.Add(this.PictureFace);
            this.tabFace.Location = new System.Drawing.Point(4, 22);
            this.tabFace.Name = "tabFace";
            this.tabFace.Size = new System.Drawing.Size(206, 260);
            this.tabFace.TabIndex = 2;
            this.tabFace.Text = "Face";
            this.tabFace.UseVisualStyleBackColor = true;
            // 
            // PictureFace
            // 
            this.PictureFace.BackColor = System.Drawing.SystemColors.ControlText;
            this.PictureFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureFace.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureFace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureFace.Location = new System.Drawing.Point(0, 0);
            this.PictureFace.Name = "PictureFace";
            this.PictureFace.Size = new System.Drawing.Size(206, 260);
            this.PictureFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureFace.TabIndex = 2;
            this.PictureFace.TabStop = false;
            this.PictureFace.Click += new System.EventHandler(this.picture_Click);
            // 
            // ScanLightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "ScanLightControl";
            this.Size = new System.Drawing.Size(214, 286);
            this.Load += new System.EventHandler(this.ScanLightControl_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicturePane)).EndInit();
            this.tabDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureDoc)).EndInit();
            this.tabFace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPane;
        private System.Windows.Forms.TabPage tabDoc;
        private System.Windows.Forms.TabPage tabFace;
        public System.Windows.Forms.PictureBox PicturePane;
        public System.Windows.Forms.PictureBox PictureDoc;
        public System.Windows.Forms.PictureBox PictureFace;
    }
}
