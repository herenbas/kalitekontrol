using Desko.EPass;
using Desko.Scan;
using DeskoScanSample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalitekontrol
{
    public partial class p_control : Form
    {
        public p_control()
        {
            InitializeComponent();
        }
        public Desko.Scan.Device device = null;

        public string mrz;
        public string[] mrzl;

        public string text_mrz;

        public string cihaz;
        private void p_control_Load(object sender, EventArgs e)
        {
            Desko.EPass.Framework.Instance.logEvent += Instance_logEvent;
        }

        private void Instance_logEvent(object sender, Framework.LoggingEventArgs e)
        {
            LogWriter logWriter = new LogWriter(e.LogMessage);
            logWriter.LogWrite(e.LogMessage);
            
        }

        public void readPassportBAC()
        {
            //OMNIKEY CardMan 5x21-CL 0


            Desko.EPass.Passport passport = Desko.EPass.Framework.Instance.GetPassport("DESKO GmbH SmartCard Reader 0", Desko.EPass.Types.ShareMode.Shared);
          


            

            //  Desko.EPass.Passport passport = Desko.EPass.Framework.Instance.GetPassport(cihaz, Desko.EPass.Types.ShareMode.Exclusive);


            try
            {
                if (passport == null)
                {
                    //Console.WriteLine("Error! Passport is null");
                    MessageBox.Show("DESKO YOK");

                    return;
                }

                try
                {
                    // Enter printed MRZ for accessing the passport
                    // Console.WriteLine("Enter MRZ of passport...");
                    //String mrz = richTextBox1.Text;
                    //Console.WriteLine("");


                    // Perform initialization and authentication


                    passport.Initialize(Desko.EPass.Types.ShareMode.Shared);
                    passport.Authenticate(Desko.EPass.Types.AuthenticationType.BAC, (mrzl[0].ToString() + mrzl[1].ToString()), Desko.EPass.Types.SecretType.MRZ);


                    // passport.Authenticate(Desko.EPass.Types.AuthenticationType.BAC, mrz, Desko.EPass.Types.SecretType.MRZ);




                    // Print passport details
                    // Console.WriteLine("EAC Support: {0} / AccessProtocol: {1} / ATR: {2}", passport.PassportInformation.EacVersion, passport.PassportInformation.AccessProtocol, passport.GetATR());


                    // Print available datagroups (stored in File COM)
                    int[] datagroups = passport.GetDatagroups(Desko.EPass.Types.FileType.COM);
                    // Console.WriteLine("Available datagroups:");
                    for (int i = 0; i < datagroups.Length; i++)
                    {
                        //Console.Write("{0}{1}", datagroups[i], (i == datagroups.Length - 1 ? System.Environment.NewLine + System.Environment.NewLine : ","));
                      //  label14.Text += datagroups[i].ToString() + "--";



                    }


                    // Read and print MRZ of RFID chip from DG1
                    String chipMrz = passport.GetMrz(1);
                    //   Console.WriteLine("MRZ on chip:{0},{1},{2}", System.Environment.NewLine, chipMrz, System.Environment.NewLine);

                    Clipboard.SetText(chipMrz);
                    MessageBox.Show("BAC ERİŞİMİ TAMAM!");

                    // Read and save facial image of RFID chip from DG2
                    // Could be more images in one DG -> choose the first image of array
                    Desko.EPass.BiometricImage chipImg = (passport.GetImages(2))[0];

                    if (chipImg != null)
                    {
                        // Console.WriteLine("Facial image on chip:");
                        //Console.WriteLine("Format: {0} / Subtype: {1}", chipImg.Format, chipImg.Subtype);

                        // Convert to PNG
                        chipImg = Desko.EPass.Framework.Instance.ConvertImage(chipImg, Desko.EPass.Types.ImageFormat.Png);

                        // BiometricImage contains a System.Drawing.Image...
                        System.Drawing.Image img = chipImg.Image;

                        // ... with this System.Drawing.Image object storing is made straightforward
                        img.Save(Path.Combine(Path.GetTempPath(), "chipImage.png"));

                        pictureBox1.Image = img;
                        label2.Text = passport.GetPersonalDetails().FullName;
                        label3.Text = passport.GetPersonalDetails().PlaceOfBirth;
                        label4.Text = passport.GetPersonalDetails().PersonalNumber;
                        label5.Text = passport.GetPersonalDetails().DocNumber;
                        label6.Text = passport.GetPersonalDetails().Profession;
                        label7.Text = passport.GetPersonalDetails().PermanentAddress;
                        label9.Text = passport.GetPersonalDetails().DateOfBirth;
                        // string aa = passport.GetDocumentDetails().IssuingAuthority;


                        //MessageBox.Show(passport.GetPersonalDetails().oth);
                      

                        //BERNA
                        //MessageBox.Show(aa);




                        label10.Text = passport.PassportInformation.EacVersion.ToString();
                        label11.Text = passport.PassportInformation.AccessProtocol.ToString();
                        //label12.Text = passport.GetDocumentDetails().IssuingAuthority;
                        label12.Text = passport.GetDocumentDetails().DateOfIssue;
                        //MessageBox.Show(passport.GetPersonalDetails().ToString());
                        //MessageBox.Show(passport.GetDocumentDetails().ToString());

                        // MessageBox.Show(passport.GetPersonalDetails().DateOfBirth.ToString());
                        //MessageBox.Show(passport.GetPersonalDetails().FullName);
                        //   label25.Text = passport.GetPersonalDetails().FullName.ToString();
                        // label26.Text= passport.GetPersonalDetails().OtherNames.ToString();
                        //   label27.Text = passport.GetPersonalDetails().PersonalNumber.ToString();
                        byte[] sonuc = passport.ReadDatagroup(11);

                        string result = System.Text.Encoding.UTF8.GetString(sonuc);

                     //   richTextBox3.Text = result;




                        MessageBox.Show(passport.PassportInformation.EacVersion.ToString()+"\n"+passport.PassportInformation.AccessProtocol.ToString());
                        




                    }
                }
                finally
                {
                    passport.Release();
                }
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }


        }
        public void HandleMrz(object sender, MrzEventArgs args)
        {
            //MessageBox.Show(args.Mrz.ToString());




            mrz = args.Mrz.Replace("\r", "\r\n") + "\r\n";
            mrz = args.Mrz;
             //  mrz = "P<TURORNEK<<ZEYNEP<<<<<<<<<<<<<<<<<<<<<<<<<<"+"\n"+ "U999998447TUR8408141F320421268792076074<<<00";

            // mrz = "P<TURORNEK<<ZEYNEP<<<<<<<<<<<<<<<<<<<<<<<<<<"+"\n"+ "U900292512TUR8408141F320302068776506260<<<70";
           rt_mrz.Text = mrz;
             mrzl = rt_mrz.Lines;




           // label6.Text = mrz;
            readPassportBAC();
            device.Snapshot.Perform();


            device.Snapshot.Infrared.GetClipping(Clipping.Document);
            //MessageBox.Show(mrz);

             device.Snapshot.Perform();
            doSnapshot();



        }


        public void RunForMrz()
        {
            rt_mrz.Text = mrz;
            // MessageBox.Show(mrz);

        }
        public void FeedbackGood()
        {
            // single beep to indicate successful OCR
            device.Feedback.Buzzer.HighTime = 200;
            device.Feedback.Buzzer.LowTime = 600;
            device.Feedback.Buzzer.Duration = 400;
            device.Feedback.Buzzer.Frequency = 880;
            device.Feedback.Led.Usage = Desko.Scan.LedUsage.Permanent;
            device.Feedback.Led.Color = Desko.Scan.Color.Red;
            device.Feedback.Led.Duration = 600;
            // basicLog.ThreadSafeAppendLine("Feedback GOOD.");
              //device.Feedback.Perform();
        }

        private void doSnapshot()
        {


            device.Snapshot.Reset();

            ScanLightSettings settings = null;
            ScanLightControl control = null;
            Buzzer bb = null;

            settings = scanLightSettings1;
            control = scanLightControl1;
            {
                Desko.Scan.ScanFlags flags = settings.ScanFlags;

                device.Snapshot.Infrared.Enabled = settings.checkUse.Checked;
                device.Snapshot.Infrared.Flags = flags;
                device.Snapshot.Infrared.ShutterWidthFactor = settings.ShutterWidthFactor;
                controlIr.Reset();
            }
            settings = scansettingsUv;

            {
                Desko.Scan.ScanFlags flags = settings.ScanFlags;

                device.Snapshot.Visible.Enabled = settings.checkUse.Checked;
                device.Snapshot.Visible.Flags = flags;
                device.Snapshot.Visible.ShutterWidthFactor = settings.ShutterWidthFactor;
                controlIr.Reset();
            }
            settings = scansettingsLight;
            control = controlIr;
            {
                Desko.Scan.ScanFlags flags = settings.ScanFlags;


                device.Snapshot.Ultraviolet.Enabled = settings.checkUse.Checked;
                device.Snapshot.Ultraviolet.Flags = flags;
                device.Snapshot.Ultraviolet.ShutterWidthFactor = settings.ShutterWidthFactor;

                controlIr.Reset();
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            Desko.Scan.Snapshot snapshot = device.Snapshot;


         
            FeedbackGood();
            device.RequestMrz();
            device.MrzAutoTriggerEnabled = true;
            
            RunForMrz();
            device.Snapshot.Infrared.GetClipping(Clipping.Document);
        
            doSnapshot();


            FeedbackGood();
            rt_mrz.SaveFile("mrz.txt");
        }

        private void p_control_Shown(object sender, EventArgs e)
        {
            Desko.EPass.Framework.Instance.InitializeFramework();

            device = new Desko.Scan.Device(null);
          

            device.Open();
            device.RaiseMrzEvent += HandleMrz;
            device.MrzAutoTriggerEnabled = true;
            device.RaiseSnapshotEvent += HandleSnapshot;
            device.RaiseSnapshotCompletedEvent += HandleSnapshotCompleted;

            
            timer1.Enabled = true;
            device.RaiseStateEvent += HandleStateChanged;


            device.MrzOnRequestEventsEnabled = true;

            FeedbackGood();


           
        }

        private void HandleStateChanged(object sender, StateEventArgs args)
        {
            if (args.State == CommState.Good)
            {
                lbl_desko_durum.Text = "BAĞLI";
            }
            else if (args.State == CommState.Pending)
            {
                lbl_desko_durum.Text = "BEKLENİYOR";
            }
            else if (args.State == CommState.Closed)
            {
                lbl_desko_durum.Text = "KAPANDI";
            }
        }

        private void HandleSnapshotCompleted(object sender, SnapshotCompletedEventArgs args)
        {

        }

        void HandleSnapshot(object sender, Desko.Scan.SnapshotEventArgs args)
        {


            Bitmap fullPane = args.GetClippedBitmap(Desko.Scan.Clipping.None);
            Bitmap croppedDocument = args.GetClippedBitmap(Desko.Scan.Clipping.Document);
            Bitmap croppedFace = args.GetClippedBitmap(Desko.Scan.Clipping.Face);

            ScanLightControl theControl = null;
            bool isMoved = false;
            switch (args.Light)
            {
                case Desko.Scan.Light.Infrared:
                    theControl = controlIr;



                    break;
                case Desko.Scan.Light.Visible:
                    theControl = scanLightControl1;


                    break;
                case Desko.Scan.Light.Ultraviolet:
                    theControl = controlUv;




                    break;
            }

            theControl.PaneImage = fullPane;
            theControl.DocumentImage = croppedDocument;
            theControl.FaceImage = croppedFace;
            theControl.Refresh();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (Desko.Scan.Runtime.HandleNextEvent(0)) { }
        }
        public byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
        private byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

           
            byte[] ImageData = new byte[fs.Length];

          
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            fs.Close();
            return ImageData; 
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                returnImage = Image.FromStream(ms);
            }
            return returnImage;
        }

       
       
      
       
        public bool performTA(Desko.EPass.Passport passport)
        {
            LoggingOptions options = new LoggingOptions();
            options.AddFlag(LogFlag.Authentication);
          
            
            

            try
            {



                MessageBox.Show(passport.GetMaxAPDUSize().ToString());


                passport.PerformTerminalAuthentication();


                label15.ForeColor = System.Drawing.Color.Green;
                byte[] data = passport.ReadDatagroup(3);
                

                if (data.Length<=18)
                {
                    MessageBox.Show("PARMAK İZİ YOK");
                    return true;
                }
                else
                {
                    string aa = Convert.ToBase64String(data, 0, data.Length);

                    


                    BiometricImage[] biometricImage = passport.GetImages(3);
                    


                    BiometricImage fp1 = biometricImage[0];
                    BiometricImage fp2 = biometricImage[1];

                    //PArmak izleri burada




                    Desko.EPass.BiometricImage biometric = Desko.EPass.Framework.Instance.ConvertImage(fp1, Desko.EPass.Types.ImageFormat.Jpeg);
                    Desko.EPass.BiometricImage biometric2 = Desko.EPass.Framework.Instance.ConvertImage(fp2, Desko.EPass.Types.ImageFormat.Jpeg);


                    pictureBox2.Image = biometric.Image;
                    pictureBox3.Image = biometric2.Image;
                    label22.Text = biometric.Subtype.ToString();
                    label23.Text = biometric.Subtype.ToString();






                    // string aaa = Convert.ToBase64String(data);

                    // MemoryStream ms = new MemoryStream(data);

                    return true;
                }   
                

              
            }
            catch (EPassException ex)
            {

                throw ex;

                return false;
            }
        }

        public bool performPA(Desko.EPass.Passport passport)
        {

            try
            {


                passport.PerformChipAuthentication();
                
                label13.ForeColor = System.Drawing.Color.Green;
                return true;
            }
            catch (EPassException ex)
            {

                MessageBox.Show(ex.ToString());
                return false;
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            openFileDialog1.ShowDialog();
            try
            {
                Desko.EPass.Passport passport = Desko.EPass.Framework.Instance.GetPassport("DESKO GmbH SmartCard Reader 0", Desko.EPass.Types.ShareMode.Shared);
              

                passport.Initialize(Desko.EPass.Types.ShareMode.Shared);
               
                string fullmrz = mrzl[0] + mrzl[1];

                passport.Authenticate(Desko.EPass.Types.AuthenticationType.BAC, fullmrz, Desko.EPass.Types.SecretType.MRZ); //-->BAC
                                                                                                                            //  passport.Authenticate(Desko.EPass.Types.AuthenticationType.PACE, fullmrz, Desko.EPass.Types.SecretType.MRZ, true);//-->SACScre

                passport.Authenticate(Desko.EPass.Types.AuthenticationType.PACE, fullmrz, Desko.EPass.Types.SecretType.MRZ);
                // string DVCA = @"C:\Users\Eren BAŞ\Documents\Sertifikalar\toTest\TRDVCAEPASS.cvc";
                // string CVCA = @"C:\Users\Eren BAŞ\Documents\Sertifikalar\toTest\TRCVCAEPASS.cvc";
                //// string IS = @"C:\Users\Eren BAŞ\Documents\Sertifikalar\toTest\17.cvc";
                // string pkcs8 = @"C:\Users\Eren BAŞ\Documents\Sertifikalar\toTest\eren.pkcs8";

                string DVCA = @"C:\toTests\TRDVCAEPASS.cvc";
                string CVCA = @"C:\toTests\TRCVCAEPASS.cvc";
                string IS = @"C:\toTests\17.cvc";
                string pkcs8 = @"C:\toTests\eren.pkcs8";


                //string DVCA = @"C:\toTests\TRDVCAEPASS.cvc";
                //string CVCA = @"C:\toTests\TRCVCAEPASS.cvc";
                //string IS = @"C:\toTests\IS_30082022.cvc";
                //string pkcs8 = @"C:\toTests\benim.pkcs8";

                //string DVCA = @"C:\serts\TRDVCAEPASS.cvc";
                //string CVCA = @"C:\serts\TRCVCAEPASS.cvc";
                //string IS = @"C:\serts\17.cvc";
                //string pkcs8 = @"C:\toTests\benim.pkcs8";
                // string DVCA_NVI = @"C:\Certificates\dvca\DVCAEPASS_NVI.cvc";
                // string CVCA_NVI = @"C:\Certificates\cvca\TRCVCAEPASS_NVI.cvc";
                //458869



                string GERCSCA = openFileDialog1.FileName;




                Desko.EPass.Certificates.Certificate CSCA_SONN = new Desko.EPass.Certificates.X509Certificate(StreamFile(GERCSCA));//success
                Desko.EPass.Certificates.CvCertificate DVCAC = new Desko.EPass.Certificates.CvCertificate(StreamFile(DVCA));
                Desko.EPass.Certificates.CvCertificate CVCAC = new Desko.EPass.Certificates.CvCertificate(StreamFile(CVCA));
                Desko.EPass.Certificates.CvCertificate ISC = new Desko.EPass.Certificates.CvCertificate(StreamFile(IS));



                 Desko.EPass.CertificateStore.Instance.AddCertificate(CSCA_SONN);
                 Desko.EPass.CertificateStore.Instance.AddCertificate(CVCAC);

                 Desko.EPass.CertificateStore.Instance.AddCertificate(DVCAC);
                  Desko.EPass.CertificateStore.Instance.AddCertificate(ISC);
                byte[] PK1 = FileToByteArray(pkcs8);
                ISC.SetCertificateKey(PK1);

                  // Desko.EPass.CertificateStore.Instance.SaveCertificateDatabase("CertDb");
                Desko.EPass.CertificateStore.Instance.LoadCertificateDatabase("CertDb");

                Desko.EPass.Framework.Instance.PassiveAuthenticationMode = Desko.EPass.Types.PassiveAuthenticationMode.LocalStorage;
                Desko.EPass.Framework.Instance.TerminalAuthenticationMode = Desko.EPass.Types.TerminalAuthenticationMode.LocalStorage;


                //  Desko.EPass.Framework.Instance.PassiveAuthenticationMode = Desko.EPass.Types.PassiveAuthenticationMode.LocalStorage;





                Thread.Sleep(1000);
               

              



               performPA(passport);
               performTA(passport);

                

                








                Desko.EPass.FileAuthenticationResults result = passport.CheckFileSignature(Desko.EPass.Types.FileType.SOD);

            











                label16.Text = "Cert sign check=" + result.DocumenttSignerCertificateSignatureCheck.ToString();
                label17.Text = "DOCUMENTSİGNERTRUESTSTATUS=" + result.DocumentSignerTrustStatus.ToString();
                label18.Text = "COUNTRY SIGNER CERTIFICATE VALIDTY: " + result.CountrySignerCertificateValidity.ToString();
                label19.Text = "DOCUMENT SIGNER CERT VALIDTY:" + result.DocumentSignerCertificateValidity.ToString();
                label20.Text = "DOCUMENT SIGNER TRUST STAT:" + result.DocumentSignerTrustStatus.ToString();
                label21.Text = "FILE SIGNATURE CHECK: " + result.FileSignatureCheck.ToString(); ;


                Desko.EPass.Certificates.RawCertificate certificate = passport.GetDocumentSignerCertificate(Desko.EPass.Types.FileType.SOD);
                File.WriteAllBytes(DateTime.Now.ToLongDateString()+"-DSCERT", certificate.RawData);


















                passport.Release();
            }

            catch (EPassException m)
            {
                throw m;
            }


        }
    }
}
