using Desko.Mrz;
using Desko.Scan;
using DeskoScanSample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle;
using System.Runtime.InteropServices;
using Desko.EPass.Types;

namespace kalitekontrol
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        public Desko.Scan.Device device = null;

        public string mrz;
        public string[] mrzl;

        public string text_mrz;

        public string cihaz;
      
        private void button1_Click(object sender, EventArgs e)
        {
            readPassportBAC();
        }
        public void readPassportBAC()
        {
            //OMNIKEY CardMan 5x21-CL 0

          

           Desko.EPass.Passport passport = Desko.EPass.Framework.Instance.GetPassport("DESKO GmbH SmartCard Reader 0", Desko.EPass.Types.ShareMode.Exclusive);

               

            
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
                    String mrz = richTextBox1.Text;
                    //Console.WriteLine("");


                    // Perform initialization and authentication


                    passport.Initialize(Desko.EPass.Types.ShareMode.Direct);
                    passport.Authenticate(Desko.EPass.Types.AuthenticationType.BAC, (mrzl[0].ToString() + mrzl[1].ToString()), Desko.EPass.Types.SecretType.MRZ);


                    // Print passport details
                    // Console.WriteLine("EAC Support: {0} / AccessProtocol: {1} / ATR: {2}", passport.PassportInformation.EacVersion, passport.PassportInformation.AccessProtocol, passport.GetATR());


                    // Print available datagroups (stored in File COM)
                    int[] datagroups = passport.GetDatagroups(Desko.EPass.Types.FileType.COM);
                    // Console.WriteLine("Available datagroups:");
                    for (int i = 0; i < datagroups.Length; i++)
                    {
                        //Console.Write("{0}{1}", datagroups[i], (i == datagroups.Length - 1 ? System.Environment.NewLine + System.Environment.NewLine : ","));
                        label14.Text += datagroups[i].ToString() + "--";



                    }


                    // Read and print MRZ of RFID chip from DG1
                    String chipMrz = passport.GetMrz(1);
                    //   Console.WriteLine("MRZ on chip:{0},{1},{2}", System.Environment.NewLine, chipMrz, System.Environment.NewLine);

                    Clipboard.SetText(chipMrz);
                    MessageBox.Show("Test");

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
                        //label2.Text = passport.GetPersonalDetails().FullName;
                        //label3.Text = passport.GetPersonalDetails().PlaceOfBirth;
                        //label4.Text = passport.GetPersonalDetails().PersonalNumber;
                        //label5.Text = passport.GetPersonalDetails().DocNumber;
                        //label6.Text = passport.GetPersonalDetails().Profession;
                        //label7.Text = passport.GetPersonalDetails().PermanentAddress;
                        //label9.Text = passport.GetPersonalDetails().DateOfBirth;
                        //label10.Text = passport.PassportInformation.EacVersion.ToString();
                        //label11.Text = passport.PassportInformation.AccessProtocol.ToString();
                        ////label12.Text = passport.GetDocumentDetails().IssuingAuthority;
                        //label13.Text = passport.GetDocumentDetails().DateOfIssue;

                       // MessageBox.Show(passport.GetPersonalDetails().DateOfBirth.ToString());
                        //MessageBox.Show(passport.GetPersonalDetails().FullName);
                        label25.Text = passport.GetPersonalDetails().FullName.ToString();
                       // label26.Text= passport.GetPersonalDetails().OtherNames.ToString();
                        label27.Text = passport.GetPersonalDetails().PersonalNumber.ToString();
                     byte[] sonuc =    passport.ReadDatagroup(11);

                     string result = System.Text.Encoding.UTF8.GetString(sonuc);

                     richTextBox3.Text = result;

                        


                        //MessageBox.Show(passport.PassportInformation.EacVersion.ToString());





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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void HandleMrz(object sender, MrzEventArgs args)
        {
            //MessageBox.Show(args.Mrz.ToString());




            // mrz = args.Mrz.Replace("\r", "\r\n") + "\r\n";
             mrz = args.Mrz;
          //  mrz = "PDTURKASAPOGLU<<GOKHAN<<<<<<<<<<<<<<<<<<<<<<P900280947TUR4503314M280331933271506666<<<34";


            richTextBox1.Text = mrz;
            mrzl = richTextBox1.Lines;




            label6.Text = mrz;
            readPassportBAC();
            device.Snapshot.Perform();

            device.Snapshot.Infrared.GetClipping(Clipping.Document);
            //MessageBox.Show(mrz);

            // device.Snapshot.Perform();
            doSnapshot();



        }


        public void RunForMrz()
        {
            richTextBox1.Text = mrz;
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
            //  basicLog.ThreadSafeAppendLine("Feedback GOOD.");
            device.Feedback.Perform();
        }

        private void doSnapshot()
        {


            device.Snapshot.Reset();

            ScanLightSettings settings = null;
            ScanLightControl control = null;

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
            control = controlUv;
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
        private void button2_Click(object sender, EventArgs e)
        {
            Desko.Scan.Snapshot snapshot = device.Snapshot;


            //  device = new Desko.Scan.Device(null);
            //device.Open();
            FeedbackGood();
            device.RequestMrz();
            device.MrzAutoTriggerEnabled = true;
            RunForMrz();
            device.Snapshot.Infrared.GetClipping(Clipping.Document);
            //MessageBox.Show(mrz);

            // device.Snapshot.Perform();
            doSnapshot();


            FeedbackGood();
            richTextBox1.SaveFile("mrz.txt");







        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // device.Open();
            Desko.EPass.Framework.Instance.InitializeFramework();
            device = new Desko.Scan.Device(null);
            //persistentMemory.InitializeThis(device);

            // device.RaiseStateEvent += HandleStateChanged;

            device.Open();
            device.RaiseMrzEvent += HandleMrz;
            device.MrzAutoTriggerEnabled = true;
            device.RaiseSnapshotEvent += HandleSnapshot;
            device.RaiseSnapshotCompletedEvent += HandleSnapshotCompleted;
            
            //buttonDeviceOpen.Enabled = true;
            //buttonDeviceClose.Enabled = true;
            timer1.Enabled = true;
            device.RaiseStateEvent += HandleStateChanged;


            device.MrzOnRequestEventsEnabled = true;

            FeedbackGood();
            

            //if (Desko.Scan.CommState.Good == CommState.Good)
            //{
            //    label1.Text = "CİHAZ BAĞLI";
            //    label1.ForeColor = System.Drawing.Color.Green;
            //}
            //else if (Desko.Scan.CommState.Unplugged == CommState.Unplugged)
            //{
            //    label1.Text = "CİHAZ BAĞLI DEĞİL";
            //    label1.ForeColor = System.Drawing.Color.Red;
            //}
            //else if (Desko.Scan.CommState.Pending == CommState.Pending)
            //{

            //    label1.Text = "CİHAZ BEKLEMEDE";
            //}
        }

        private void HandleStateChanged(object sender, StateEventArgs args)
        {
            if (args.State==CommState.Good)
            {
                label1.Text = "BAĞLI";
            }
            else if (args.State==CommState.Pending)
            {
                label1.Text = "BEKLENİYOR";
            }
            else if (args.State == CommState.Closed)
            {
                label1.Text = "KAPANDI";
            }
        }

        private void HandleSnapshotCompleted(object sender, SnapshotCompletedEventArgs args)
        {

        }

        void HandleSnapshot(object sender, Desko.Scan.SnapshotEventArgs args)
        {

            //   basicLog.ThreadSafeAppendLine("Handling snapshot " + args.Light.ToString() + " START.");

            Bitmap fullPane = args.GetClippedBitmap(Desko.Scan.Clipping.None);
            Bitmap croppedDocument = args.GetClippedBitmap(Desko.Scan.Clipping.Document);
            Bitmap croppedFace = args.GetClippedBitmap(Desko.Scan.Clipping.Face);
            //basicLog.ThreadSafeAppendLine("Scans available: Full(" + (fullPane != null ? "yes" : "no") + ") Doc(" + (croppedDocument != null ? "yes" : "no") + ") Face(" + (croppedFace != null ? "yes" : "no") + ").");

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

        private void controlIr_Load(object sender, EventArgs e)
        {

        }

        private void scanLightControl1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                Desko.EPass.Passport passport = Desko.EPass.Framework.Instance.GetPassport("DESKO GmbH SmartCard Reader 0", Desko.EPass.Types.ShareMode.Exclusive);

                passport.Initialize(Desko.EPass.Types.ShareMode.Shared);
                string fullmrz = mrzl[0] + mrzl[1];
              

                string gercsca = @"C:\Users\hayreddin.bas\Documents\PASAPORT_SERTIFIKA_EGM_CALISMA\PROD\CSCAV1DER.cer";
                string gercscacer = @"C:\Users\hayreddin.bas\Documents\PASAPORT_SERTIFIKA_EGM_CALISMA\PROD\CSCAV1.cer";
                string gercscacrt = @"C:\Users\hayreddin.bas\Documents\PASAPORT_SERTIFIKA_EGM_CALISMA\PROD\CSCAV1DER.crt";

                string oldcsca = @"C:\Users\hayreddin.bas\Desktop\tubitak toplantı\CSCA-2016\CSCA2016DER.cer";

                string testyencsca = @"C:\Users\hayreddin.bas\Desktop\keys\pasaport sertifikaları\TEST\TESTCSCADER.cer";

                string link = @"D:\dışişleri\Link.cer";

                string bulg = @"C:\Users\hayreddin.bas\Downloads\bg_csca_16042014\bulg.cer";


                string certson = @"C:\Users\hayreddin.bas\Desktop\RSA PROD\RSADERCSCA.cer";


                string named = @"C:\Users\hayreddin.bas\Documents\muhammet-CSCALAR\csca - named.der";

                string expl = @"C:\Users\hayreddin.bas\Documents\muhammet-CSCALAR\csca - explicit.der";


                string CSCA_SON = @"C:\Users\hayreddin.bas\Desktop\keys\pasaport sertifikaları\PROD\CSCATR_S1.cer";

                string Link_Son = @"C:\Users\hayreddin.bas\Desktop\keys\pasaport sertifikaları\PROD\CSCA-link-certificate2016-2018.crl";

                string DVCA = @"C:\Users\hayreddin.bas\Documents\silnecekprod\TRDVCAEPASS.cvc";

                string iscert = @"C:\Users\hayreddin.bas\Documents\yeni_is\16.cvc";

                string is_key = @"C:\Users\hayreddin.bas\Documents\yeni_is\pk2.pkcs8";

                Desko.EPass.Framework fr = new Desko.EPass.Framework();
                fr.TerminalAuthenticationMode = Desko.EPass.Types.TerminalAuthenticationMode.LocalStorage;
                fr.PassiveAuthenticationMode = Desko.EPass.Types.PassiveAuthenticationMode.LocalStorage;
               // Desko.EPass.Framework.Instance.PassiveAuthenticationMode = Desko.EPass.Types.PassiveAuthenticationMode.LocalStorage;
                //Desko.EPass.Framework.Instance.TerminalAuthenticationMode = Desko.EPass.Types.TerminalAuthenticationMode.LocalStorage;
               
                //TerminalType type = new TerminalType();
                //type = TerminalType.AuthenticationTerminal;
                //device.AbortLongTermOperation();








                Desko.EPass.Certificates.Certificate CSCA_SONN = new Desko.EPass.Certificates.X509Certificate(StreamFile(gercsca));//success

                Desko.EPass.Certificates.Certificate csca_expl = new Desko.EPass.Certificates.X509Certificate(StreamFile(expl));//success

                Desko.EPass.Certificates.Certificate CSCA_named = new Desko.EPass.Certificates.X509Certificate(StreamFile(named));//success

                Desko.EPass.Certificates.Certificate DVCA_cert = new Desko.EPass.Certificates.CvCertificate(StreamFile(DVCA));
                Desko.EPass.Certificates.CvCertificate is_certf = new Desko.EPass.Certificates.CvCertificate(StreamFile(iscert));

                


                Desko.EPass.CertificateStore.Instance.AddCertificate(CSCA_SONN);
                Desko.EPass.CertificateStore.Instance.AddCertificate(DVCA_cert);
                Desko.EPass.CertificateStore.Instance.AddCertificate(is_certf);

                byte[] pk1 = FileToByteArray(is_key);

                //Desko.EPass.Certificates.CvCertificate cert = new Desko.EPass.Certificates.CvCertificate(pk);
                // Desko.EPass.Certificates.CvCertificate cert1 = new Desko.EPass.Certificates.CvCertificate(pk1);
                // Desko.EPass.CertificateStore.Instance.AddCertificate(cert1);

                is_certf.SetCertificateKey(pk1);

                //successs


                 Desko.EPass.CertificateStore.Instance.SaveCertificateDatabase("certdb1");
                // Desko.EPass.CertificateStore.Instance.LoadCertificateDatabase("certdb1");




                // byte[] pk = FileToByteArray(testcert4);
                
                //certificate1.GetChildCertificates();


                // string pks = System.Text.Encoding.UTF8.GetString(pk);

              //  text_mrz = "P<TURKARADEMIR<<APTI<<<<<<<<<<<<<<<<<<<<<<<<PL19827683TUR6306243M200214512345678901<<<00";

                passport.Authenticate(Desko.EPass.Types.AuthenticationType.BAC, fullmrz, Desko.EPass.Types.SecretType.MRZ); //-->BAC

               // passport.PerformTerminalAuthentication();
                passport.PerformChipAuthentication();
                passport.Authenticate(Desko.EPass.Types.AuthenticationType.PACE, fullmrz, Desko.EPass.Types.SecretType.MRZ);//-->SAC
                label11.Text = passport.PassportInformation.AccessProtocol.ToString();
                //45947186788


               
                //  passport.SetMaxAPDUSize(512);
             
                //////string aa = passport.PassportInformation.AccessProtocol.ToS0ö2tring();label26




                //--------------------------BUARADA SUCCESS DÖNMESİ LAZIM-------------------------


                // MessageBox.Show(aa);
                
              //  passport.PerformTerminalAuthentication();
                // List<Desko.EPass.Certificates.RawCertificate> cers = new List<Desko.EPass.Certificates.RawCertificate>();

                
                

                //cers.Add(new De);
                Desko.EPass.FileAuthenticationResults result = passport.CheckFileSignature(Desko.EPass.Types.FileType.SOD);
                
                MessageBox.Show(result.FileSignatureCheck.ToString());
               
                //label15.Text ="Cert sign check="+ result.DocumenttSignerCertificateSignatureCheck.ToString();
                label19.Text = "DOCUMENTSİGNERTRUESTSTATUS=" + result.DocumentSignerTrustStatus.ToString();
                label20.Text = "COUNTRY SIGNER CERTIFICATE VALIDTY: "+result.CountrySignerCertificateValidity.ToString();
                label21.Text = "DOCUMENT SIGNER CERT VALIDTY:"+result.DocumentSignerCertificateValidity.ToString();
                label22.Text = "DOCUMENT SIGNER TRUST STAT:"+result.DocumentSignerTrustStatus.ToString();
                label23.Text = "FILE SIGNATURE CHECK: "+result.FileSignatureCheck.ToString(); ;
                

                Desko.EPass.Certificates.RawCertificate certificate = passport.GetDocumentSignerCertificate(Desko.EPass.Types.FileType.SOD);
                File.WriteAllBytes("certDS2NewPROD", certificate.RawData);
                
               
















                passport.Release();
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }

        


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

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return ImageData; //return the byte data
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Desko.EPass.Passport passport = Desko.EPass.Framework.Instance.GetPassport(cihaz, Desko.EPass.Types.ShareMode.Direct);

            passport.Initialize(Desko.EPass.Types.ShareMode.Shared);
            string fullmrz = mrzl[0] + mrzl[1];


            string CSCA_SON = @"C:\Users\hayreddin.bas\Desktop\keys\pasaport sertifikaları\PROD\CSCATR_S1.cer";
      
           


            string DVCA = @"C:\Users\hayreddin.bas\Documents\silnecekprod\TRDVCAEPASS.cvc";

            string iscert = @"C:\Users\hayreddin.bas\Documents\yeni_is\16.cvc";

            string is_key = @"C:\Users\hayreddin.bas\Documents\yeni_is\pk2.pkcs8";

            Desko.EPass.Certificates.X509Certificate TESTCSCA = new Desko.EPass.Certificates.X509Certificate(FileToByteArray(CSCA_SON));
            Desko.EPass.Certificates.CvCertificate DVCAC = new Desko.EPass.Certificates.CvCertificate(FileToByteArray(DVCA));
            Desko.EPass.Certificates.CvCertificate certyirmic = new Desko.EPass.Certificates.CvCertificate(FileToByteArray(iscert));


            Desko.EPass.CertificateStore.Instance.AddCertificate(TESTCSCA);
            Desko.EPass.CertificateStore.Instance.AddCertificate(DVCAC);
            Desko.EPass.CertificateStore.Instance.AddCertificate(certyirmic);
            
            
            byte[] pk = FileToByteArray(is_key);
            certyirmic.SetCertificateKey(pk);
           
            
            Desko.EPass.Certificates.CertificateInformation info=  certyirmic.CertificateInformation;
            MessageBox.Show(info.ToString());
            Desko.EPass.Certificates.CertificateInformation info1 = TESTCSCA.CertificateInformation;
            MessageBox.Show(info1.ToString());
            Desko.EPass.Certificates.CertificateInformation info2 = DVCAC.CertificateInformation;
            MessageBox.Show(info2.ToString());
            
           
           
            CertificateHolderRole role = new CertificateHolderRole();
            role = CertificateHolderRole.DomesticDV;

            

           

            Desko.EPass.CertificateStore.Instance.SaveCertificateDatabase("certdbnew");
            Desko.EPass.CertificateStore.Instance.LoadCertificateDatabase("certdbnew");
          
          //  byte [] key_data =   certyirmic.GetPrivateKey();

           

            TerminalAuthenticationMode mode = new TerminalAuthenticationMode();

            mode = TerminalAuthenticationMode.LocalStorage;

            Desko.EPass.Framework.Instance.GetPassportReaderList();
            Desko.EPass.Framework.Instance.TerminalAuthenticationMode = Desko.EPass.Types.TerminalAuthenticationMode.LocalStorage;
            Desko.EPass.Framework.Instance.PassiveAuthenticationMode = Desko.EPass.Types.PassiveAuthenticationMode.LocalStorage;
            Desko.EPass.Types.TerminalType type = TerminalType.InspectionSystem;
            

           
            passport.Authenticate(Desko.EPass.Types.AuthenticationType.BAC, fullmrz, Desko.EPass.Types.SecretType.MRZ,true); //-->BAC
            
          
           // passport.PerformChipAuthentication();
            passport.Authenticate(Desko.EPass.Types.AuthenticationType.PACE, fullmrz, Desko.EPass.Types.SecretType.MRZ,true);//-->SAC
          //  passport.Authenticate(Desko.EPass.Types.AuthenticationType.PACE,Encoding.Default.GetString(, Desko.EPass.Types.SecretType.CAN);//-->SAC
            //Desko.EPass.Framework.Instance.TerminalAuthenticationMode = TerminalAuthenticationMode.LocalStorage;
          
            passport.PerformTerminalAuthentication();


        }

        private void button5_Click(object sender, EventArgs e)
        {

            
            Desko.EPass.Passport passport = Desko.EPass.Framework.Instance.GetPassport(cihaz, Desko.EPass.Types.ShareMode.Exclusive);

            passport.Initialize(Desko.EPass.Types.ShareMode.Direct);
            passport.Authenticate(Desko.EPass.Types.AuthenticationType.BAC, (mrzl[0].ToString() + mrzl[1].ToString()), Desko.EPass.Types.SecretType.MRZ);
            string  size = Convert.ToBase64String( passport.ReadFile(Desko.EPass.Types.FileType.SOD));



            

         




        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            string[] readerList = Desko.EPass.Framework.Instance.GetPassportReaderList();

            foreach (var item in readerList)
            {
                richTextBox1.Text = item.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Desko.EPass.Passport passport = Desko.EPass.Framework.Instance.GetPassport(cihaz, Desko.EPass.Types.ShareMode.Shared);
            Desko.EPass.Passport passport = Desko.EPass.Framework.Instance.GetPassport("DESKO GmbH SmartCard Reader 0", Desko.EPass.Types.ShareMode.Exclusive);
            Desko.EPass.Certificates.RawCertificate certificate = passport.GetDocumentSignerCertificate(FileType.SOD);
            File.WriteAllBytes("certDSPROD", certificate.RawData);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();    //Clear if any old value is there in Clipboard        
            Clipboard.SetText(mrzl[0].ToString()+mrzl[1].ToString()); //Copy text to Clipboard
            //string strClip = Clipboard.GetText();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string[] readerList = Desko.EPass.Framework.Instance.GetPassportReaderList();

            foreach (var item in readerList)
            {
                MessageBox.Show(item.ToString());
                cihaz = item.ToString();
            }
        }
    }
}
