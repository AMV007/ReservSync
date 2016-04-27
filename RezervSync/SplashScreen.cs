using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.ComponentModel;

namespace RezervSync
{
    public static class SplashScreen
    {
        public static Image[] BackImages = new Image[]{  
                                        RezervSync.Properties.Resources.activesync_round_image2
                                     };
        static SplashForm splashForm = null;
        static Thread splashThread = null;

        //	internally used as a thread function - showing the form and
        //	starting the messageloop for it
        static void ShowThread()
        {
            splashForm = new SplashForm(BackImages[(new Random()).Next(BackImages.Length - 1)], null, rotatePicture);
            Application.Run(splashForm);
        }

        //	public Method to show the SplashForm
        static bool rotatePicture = false;
        static public void Show(bool RotatePicture)
        {
            if (splashThread != null)
                return;
            rotatePicture=RotatePicture;

            splashThread = new Thread(new ThreadStart(SplashScreen.ShowThread));
            splashThread.IsBackground = true;
            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();
        }

        static public void Show()
        {
            Show(false);
        }

        //	public Method to hide the SplashForm
        static public void Close()
        {
            if (splashThread == null) return;
            if (splashForm == null) return;

            try
            {
                splashForm.Invoke(new MethodInvoker(splashForm.Close));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            splashThread = null;
            splashForm = null;
        }

        public class SplashForm : System.Windows.Forms.Form
        {
            private System.ComponentModel.Container components = null;

            Graphics InternalGraphics=null;
            DateTime StartTime;

            Image SourceImage = null;            
            private static BackgroundWorker RotatePictureWorker = null;
            ManualResetEvent ImageGet = new ManualResetEvent(true);

            
            public SplashForm(Image BackImage, string Filename, bool RotatePicture)
            {
                this.SuspendLayout();

                this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
                this.ControlBox = false;
                this.ShowInTaskbar = false;
                this.TopMost = true;
                this.Enabled = false;
                this.AllowTransparency = false;
                this.AllowDrop = false;
                this.AutoSize = false;
                this.AutoValidate = AutoValidate.Disable;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Name = "SplashForm";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Opacity = 0.8;


                this.BackColor = Color.WhiteSmoke;
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);

                this.TransparencyKey = this.BackColor;                

                if (BackImage == null && !string.IsNullOrEmpty(Filename))
                {
                    try
                    {
                        BackImage = Image.FromFile(Filename);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Couldn't load splash image, splash.bmp");
                    }
                }

                rotatePicture = RotatePicture;
                if (BackImage != null)
                {
                    if (ImageGet.WaitOne())
                    {
                        this.BackgroundImage = BackImage;                        
                        this.ClientSize = BackImage.Size;
                        this.Region = new Region();
                        InternalGraphics = this.CreateGraphics();                        

                        if (RotatePicture)
                        {
                            SourceImage = BackImage;
                            RotatePictureWorker = new BackgroundWorker();
                            RotatePictureWorker.DoWork += new DoWorkEventHandler(RotatePictureWorker_DoWork);
                            RotatePictureWorker.WorkerSupportsCancellation = true;
                            RotatePictureWorker.RunWorkerAsync();
                        }
                        ImageGet.Set();                        
                    }
                }
                
                StartTime = DateTime.Now;
                this.ResumeLayout(false);                
            }

            public static Bitmap RotateRoundImageUsingGraphics(Image image, float angle)
            {                
                // angle fomt 0 to 360
                if (angle > 360)
                {
                    angle = angle - (((int)(angle / 360)) * 360);
                }
                if (angle == 360) angle = 0;

                Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);

                using (Graphics g = Graphics.FromImage(rotatedBmp))
                {
                    // так как при трансформации изображения возникают белые области, то обрезаем картинку
                    System.Drawing.Drawing2D.GraphicsPath xx = new System.Drawing.Drawing2D.GraphicsPath();
                    xx.AddEllipse(1, 1, image.Width-2, image.Height-2);
                    g.Clip = new Region(xx);                  
                    
                    g.RotateTransform(angle);

                    double HalfWidth = image.Width / 2, HalfHeight=image.Height/2,
                          PosX = 0, PosY = 0;  
                    double theta = ((double)angle+45.0) * Math.PI / 180.0;
                    double sqrt2 = Math.Sqrt(2.0);
                    
                    PosX = -HalfWidth + (Math.Sin(theta) * HalfWidth * sqrt2);
                    PosY = -HalfWidth + (Math.Cos(theta) * HalfHeight * sqrt2);                    

                    g.DrawImage(image, (float)PosX, (float)PosY, image.Width, image.Height);

                    g.Dispose();
                }
                
                return rotatedBmp;
            }


            
            void RotatePictureWorker_DoWork(object sender, DoWorkEventArgs e)
            {                
                float angle = 0;
                while (!RotatePictureWorker.CancellationPending)
                {
                    Thread.Sleep(50);
                    angle +=10;                    

                    if (ImageGet.WaitOne())
                    {
                        this.BackgroundImage = RotateRoundImageUsingGraphics(SourceImage, angle);                        
                        ImageGet.Set();                       
                    }                    
                }
            }          
            
            void StopRotate()
            {
                if (RotatePictureWorker != null)
                {
                    while (RotatePictureWorker.IsBusy)
                    {
                        RotatePictureWorker.CancelAsync();
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
            }

            protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
            {                
                StopRotate();
                TimeSpan TimeDiff = DateTime.Now - StartTime;
                Thread.Sleep((int)Math.Max(0, 500 - TimeDiff.TotalMilliseconds));                
                base.OnClosing(e);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            void Redraw(Graphics e, Rectangle Rect)
            {
                if (this.BackgroundImage != null)
                {
                    if (ImageGet.WaitOne())
                    {   
                        //e.Clear(Color.White);
                        e.DrawImage(this.BackgroundImage, Rect);
                        ImageGet.Set();
                    }
                }
            }

            
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                base.OnPaintBackground(e);                
                //Redraw(e.Graphics, e.ClipRectangle);                       
            }           

            protected override void OnResize(EventArgs e)
            {
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                
            }
        }
    }
}
