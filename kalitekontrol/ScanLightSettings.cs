using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeskoScanSample
{
    public partial class ScanLightSettings : UserControl
    {
        public ScanLightSettings()
        {
            InitializeComponent();
        }

        public Desko.Scan.ScanFlags ScanFlags
        {
            get
            {

                Desko.Scan.ScanFlags flags = Desko.Scan.ScanFlags.None;
                foreach (var f in listBoxScanFlags.SelectedItems)
                {
                    flags = (flags | (Desko.Scan.ScanFlags)f);
                }
                return flags;
            }
        }


        public double ShutterWidthFactor
        {
            get
            {
                return Double.Parse(textBoxShutterWidth.Text);
            }
        }


        void updateListBox()
        {
            listBoxScanFlags.Items.Clear();
            listBoxScanFlags.Items.Add(Desko.Scan.ScanFlags.AmbientFilter);
            listBoxScanFlags.Items.Add(Desko.Scan.ScanFlags.DocumentClipping);
            listBoxScanFlags.Items.Add(Desko.Scan.ScanFlags.FaceClipping);
            listBoxScanFlags.Items.Add(Desko.Scan.ScanFlags.LowResolution);
            listBoxScanFlags.Items.Add(Desko.Scan.ScanFlags.NoGlareReduction);
            listBoxScanFlags.Items.Add(Desko.Scan.ScanFlags.Gray);

            listBoxScanFlags.SelectedItems.Add(Desko.Scan.ScanFlags.AmbientFilter);
            if (light == Desko.Scan.Light.Infrared)
            {
                listBoxScanFlags.Items.Add(Desko.Scan.ScanFlags.CaptureMrz);
                listBoxScanFlags.SelectedItems.Add(Desko.Scan.ScanFlags.Gray);
            }

            if (light == Desko.Scan.Light.Ultraviolet)
            {
                listBoxScanFlags.Items.Add(Desko.Scan.ScanFlags.CheckUvReaction);
            }
        }

        private Desko.Scan.Light light = Desko.Scan.Light.Infrared;

        [Description("Light source"),Category("Data")]
        public Desko.Scan.Light Light
        {
            get { return light; }
            set
            {
                groupBox.Text = value.ToString();
                light = value;
                updateListBox();
            }
        }

        private void ScanLightSettings_Load(object sender, EventArgs e)
        {
        }

        private void textBoxShutterWidth_Validating(object sender, CancelEventArgs e)
        {
            double d = 0.0;
            if (!Double.TryParse(textBoxShutterWidth.Text, out d))
            {
                e.Cancel = true;
                textBoxShutterWidth.Text = (1.0).ToString();
            }
        }
    }
}
