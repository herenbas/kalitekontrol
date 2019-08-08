using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeskoScanSample;

namespace kalitekontrol
{
    public partial class ScanLightControl : UserControl
    {

        #region ---- Private Variables -----------------------------------------------------
        Desko.Scan.Light scanLight = Desko.Scan.Light.Infrared;

        #endregion

        #region ---- Private Methods -----------------------------------------------------

        public ScanLightControl()
        {
            InitializeComponent();

            tabControl.SelectedIndex = 1; // show doc clipping as default
        }

        private void ScanLightControl_Load(object sender, EventArgs e)
        {
            tabControl.TabPages.Clear();
        }

        /// <summary>
        /// Get picture box for respective clipping.
        /// </summary>
        /// <param name="clipping">The clipping</param>
        /// <returns>picture box for clipping</returns>
        PictureBox GetBoxForClipping(Desko.Scan.Clipping clipping)
        {

            PictureBox theBox = null;
            switch (clipping)
            {
                case Desko.Scan.Clipping.None:
                    theBox = PicturePane;
                    break;
                case Desko.Scan.Clipping.Document:
                    theBox = PictureDoc;
                    break;
                case Desko.Scan.Clipping.Face:
                    theBox = PictureFace;
                    break;
                default:
                    theBox = PicturePane;
                    break;
            }
            return theBox;
        }

        TabPage GetTabForClipping(Desko.Scan.Clipping clipping)
        {
            switch (clipping)
            {
                case Desko.Scan.Clipping.None:
                    return tabPane;
                case Desko.Scan.Clipping.Document:
                    return tabDoc;
                case Desko.Scan.Clipping.Face:
                    return tabFace;
                default:
                    return tabPane;
            }
        }


        Zoom zoom = new Zoom();
        private void picture_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            if (picture.Image == null)
                return;

            zoom.pictureZoom.Image = picture.Image;
            zoom.pictureZoom.Left = 0;
            zoom.pictureZoom.Top = 0;
            zoom.pictureZoom.Width = picture.Image.Width;
            zoom.pictureZoom.Height = picture.Image.Height;
            zoom.pictureZoom.SizeMode = PictureBoxSizeMode.Zoom;
            zoom.pictureZoom.Dock = DockStyle.Fill;

            zoom.ShowDialog();
        }

        #endregion

        #region ---- Public Attributes -----------------------------------------------------

        /// <summary>
        /// The scan light identifying this control.
        /// </summary>
        [Description("Scan light."), Category("Data")]
        public Desko.Scan.Light ScanLight
        {
            set
            {
                scanLight = value;
            }

            get
            {
                return scanLight;
            }
        }
        //--------------------------------------------------------------------------------

        /// <summary>
        /// The full pane image.
        /// </summary>
        [Description("The full pane image."), Category("Data")]
        public Image PaneImage
        {
            get { return GetImage(Desko.Scan.Clipping.None); }
            set { SetImage(Desko.Scan.Clipping.None, value); }
        }

        /// <summary>
        /// The document-clipped image.
        /// </summary>
        [Description("The document-clipped image."), Category("Data")]
        public Image DocumentImage
        {
            get { return GetImage(Desko.Scan.Clipping.Document); }
            set { SetImage(Desko.Scan.Clipping.Document, value); }
        }

        /// <summary>
        /// The face-clipped image.
        /// </summary>
        [Description("The face-clipped image."), Category("Data")]
        public Image FaceImage
        {
            get { return GetImage(Desko.Scan.Clipping.Face); }
            set { SetImage(Desko.Scan.Clipping.Face, value); }
        }
        #endregion

        #region ---- Public Methods -----------------------------------------------------
        
        /// <summary>
        /// Clear all images and reset to defaults.
        /// </summary>
        public void Reset()
        {
            PicturePane.Image = null;
            PicturePane.Cursor = System.Windows.Forms.Cursors.Default;
            PictureFace.Image = null;
            PictureFace.Cursor = System.Windows.Forms.Cursors.Default;
            PictureDoc.Image = null;
            PictureDoc.Cursor = System.Windows.Forms.Cursors.Default;
            tabControl.TabPages.Clear();
        }


        /// <summary>
        /// Get image of a specific clipping.
        /// </summary>
        /// <param name="clipping">Clipping type.</param>
        /// <returns>Image of respective clipping type. Maybe null</returns>
        public Image GetImage(Desko.Scan.Clipping clipping)
        {
            return GetBoxForClipping(clipping).Image;
        }

        /// <summary>
        /// Set an image with a specific clipping.
        /// </summary>
        /// <param name="clipping">The type of clipping the image inhibits.</param>
        /// <param name="image">The image object. Maybe null.</param>
        public void SetImage(Desko.Scan.Clipping clipping, Image image)
        {
            PictureBox box = GetBoxForClipping(clipping);

            TabPage tab = GetTabForClipping(clipping);
            if (image == null)
            {
                box.Image = null;
                box.Cursor = System.Windows.Forms.Cursors.Default;

                if (tabControl.TabPages.Contains(tab))
                    tabControl.TabPages.Remove(tab);
            }
            else
            {
                box.Image = image;
                box.Cursor = (image == null ? System.Windows.Forms.Cursors.Default : System.Windows.Forms.Cursors.Hand);
                if (!tabControl.TabPages.Contains(tab))
                    tabControl.TabPages.Insert(tabControl.TabPages.Count, tab);

                
                if (DocumentImage != null)
                {
                    tabControl.SelectedTab = tabDoc;
                }
                else
                {
                    tabControl.SelectedTab = tabPane;
                }
            }

        }

        #endregion



        

      


    }
}
