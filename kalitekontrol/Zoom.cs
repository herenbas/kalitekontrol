/*
    (c) DESKO GmbH 2014

    The Licensee acknowledges and agrees that the Software and Documentation
    (the "Confidential Information") is confidential and proprietary to
    the Licensor and the Licensee hereby agrees to use the Confidential
    Information only as permitted by the full license agreement between
    the two parties, to maintain the confidentiality of the Confidential
    Information and not to disclose the confidential information, or any part
    thereof, to any other person, firm or corporation. The Licensee
    acknowledges that disclosure of the Confidential Information may give rise
    to an irreparable injury to the Licensor in-adequately compensable in
    damages.  Accordingly the Licensor may seek (without the posting of any
    bond or other security) injunctive relief against the breach of the forgoing
    undertaking of confidentiality and non-disclosure, in addition to any other
    legal remedies which may be available, and the licensee consents to the
    obtaining of such injunctive relief.  All of the undertakings and
    obligations relating to confidentiality and non-disclosure, whether
    contained in this section or elsewhere in this agreement, shall survive
    the termination or expiration of this agreement for a period of five (5)
    years.

    The Licensor agrees that any information or data received from the Licensee
    in connection with the performance of the support agreement relating to this
    software shall be confidential, will be used only in connection with the
    performance of the Licensor's obligations hereunder, and will not be
    disclosed to third parties.

    Information regarding the software may be provided to the Licensee's outside
    auditors and attorneys only to the extent required by their respective
    functions.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeskoScanSample
{
    public partial class Zoom : Form
    {
        public Zoom()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            pictureZoom.SizeMode = PictureBoxSizeMode.Zoom;
            pictureZoom.Dock = DockStyle.Fill;
        }

        private void buttonZoom_Click(object sender, EventArgs e)
        {
            pictureZoom.SizeMode = PictureBoxSizeMode.Normal;
            pictureZoom.Dock = DockStyle.None;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try 
            { 
                if (DialogResult.OK != saveDialog.ShowDialog())
                    return;

                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                if (saveDialog.FileName.ToLower().EndsWith(".jpg"))
                {
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                }
                if (saveDialog.FileName.ToLower().EndsWith(".jpeg"))
                {
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                }
                else if (saveDialog.FileName.ToLower().EndsWith(".bmp"))
                {
                    format = System.Drawing.Imaging.ImageFormat.Bmp;
                }
                else if (saveDialog.FileName.ToLower().EndsWith(".png"))
                {
                    format = System.Drawing.Imaging.ImageFormat.Png;
                }
                else if (saveDialog.FileName.ToLower().EndsWith(".gif"))
                {
                    format = System.Drawing.Imaging.ImageFormat.Gif;
                }
                pictureZoom.Image.Save(saveDialog.FileName, format);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Zoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                buttonClose_Click(sender,e);
            }
            else if (e.KeyCode == Keys.S)
            {
                buttonSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F)
            {
                buttonFill_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D1)
            {
                buttonZoom_Click(sender, e);
            }
        }

   
    }
}
