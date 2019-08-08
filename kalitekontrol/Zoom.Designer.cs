namespace DeskoScanSample
{
    partial class Zoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zoom));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonFill = new System.Windows.Forms.Button();
            this.buttonZoom = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelPane = new System.Windows.Forms.Panel();
            this.pictureZoom = new System.Windows.Forms.PictureBox();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panelPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonFill);
            this.panel1.Controls.Add(this.buttonZoom);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 594);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 46);
            this.panel1.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(232, 7);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 28);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonFill
            // 
            this.buttonFill.Location = new System.Drawing.Point(124, 7);
            this.buttonFill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(100, 28);
            this.buttonFill.TabIndex = 2;
            this.buttonFill.Text = "Fill";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // buttonZoom
            // 
            this.buttonZoom.Location = new System.Drawing.Point(16, 7);
            this.buttonZoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonZoom.Name = "buttonZoom";
            this.buttonZoom.Size = new System.Drawing.Size(100, 28);
            this.buttonZoom.TabIndex = 1;
            this.buttonZoom.Text = "1:1";
            this.buttonZoom.UseVisualStyleBackColor = true;
            this.buttonZoom.Click += new System.EventHandler(this.buttonZoom_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(967, 7);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 28);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelPane
            // 
            this.panelPane.AutoScroll = true;
            this.panelPane.Controls.Add(this.pictureZoom);
            this.panelPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPane.Location = new System.Drawing.Point(0, 0);
            this.panelPane.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPane.Name = "panelPane";
            this.panelPane.Size = new System.Drawing.Size(1083, 594);
            this.panelPane.TabIndex = 1;
            // 
            // pictureZoom
            // 
            this.pictureZoom.Location = new System.Drawing.Point(0, 0);
            this.pictureZoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureZoom.Name = "pictureZoom";
            this.pictureZoom.Size = new System.Drawing.Size(489, 353);
            this.pictureZoom.TabIndex = 0;
            this.pictureZoom.TabStop = false;
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "Bitmap (*.BMP)|*.bmp|JPEG(*.jpg)|.jpg|Portable Network Graphic (*.png)|*.png|GIF " +
    "(*.gif)|*.GIF|All files (*.*)|*.*";
            this.saveDialog.Title = "Save Image";
            // 
            // Zoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 640);
            this.Controls.Add(this.panelPane);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Zoom";
            this.Text = "PASAPORT RESMİ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Zoom_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panelPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelPane;
        public System.Windows.Forms.PictureBox pictureZoom;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.Button buttonZoom;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveDialog;
    }
}