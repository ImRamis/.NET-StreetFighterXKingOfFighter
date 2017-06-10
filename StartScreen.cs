#region

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace StreetFighterXKingOfFighter
{
    public partial class StartScreen : Form
    {
        private static string _name = "choi";

        public static Bitmap Img = new Bitmap(@"Characters\afterflash\" + _name + ".png");

        public static Color[] Arr =
        {
            Color.DimGray, Color.Gray, Color.DarkGray, Color.Silver, Color.LightGray, Color.Gainsboro, Color.WhiteSmoke,
            Color.Gainsboro, Color.LightGray, Color.Silver, Color.DarkGray, Color.DimGray
        };

        private int _size = 40;
        private string _word;

        public int A;
        public string A1 = "Do You Thought the WAR was Over ??? ";
        public int A1Len;
        public int A2Len = 0;
        public int Currentframe;
        public bool Flash = false;
        public int I;
        public int Letter;
        public bool Loop = true;
        public int Maxframe;
        public int TotalFrames;
        public int X = 10;

        public StartScreen()
        {
            InitializeComponent();
        }

        public int XWidth { get; set; }

        private Bitmap _img
        {
            get
            {
                Img.MakeTransparent();
                return Img;
            }
        }

        //   public string directory = @"C:\Users\MBC\Desktop\Characters\poster";
        private void startscreen_Load(object sender, EventArgs e)
        {
            TotalFrames = _img.Width / 304;
            Maxframe = _img.Width / 304;
            progressBar1.Value = 70;
            A1Len = A1.Length - 1;
            BackColor = Color.Black;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
            if (progressBar1.Value != 100) return;
            timer1.Stop();
            timer2.Start();
            progressBar1.Visible = false;
            panel1.Paint += panel1_Paint;
        }

        // public int y = 5;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (Loop)
                Panel1Graphics(e.Graphics);
            if ((Loop == false) & (I < Arr.Length - 1))
            {
                FlashColour();
                timer2.Interval = 100;
            }
            if (Loop == false)
                Afterflash(e.Graphics);
            e.Graphics.DrawString("Press F1 for coin", new Font(FontFamily.GenericMonospace, 25), Brushes.DarkRed,
                new PointF(10, 10));
        }

        public void Afterflash(Graphics e)
        {
            e.DrawImage(_img, new Rectangle(250, 100, 304, 203), XWidth, 0, 224, 304, GraphicsUnit.Pixel);
            XWidth += 304;
            Currentframe++;
            if (Currentframe < TotalFrames) return;
            Currentframe = 0;
            XWidth = 0;
            switch (A)
            {
                case 1:
                {
                    _name = "choi";
                    break;
                }
                case 2:
                {
                    _name = "iori";
                    Img = new Bitmap(@"Characters\afterflash\" + _name + ".png");
                    break;
                }
                case 3:
                {
                    _name = "kim";
                    Img = new Bitmap(@"Characters\afterflash\" + _name + ".png");
                    break;
                }
                case 4:
                {
                    _name = "terry";
                    Img = new Bitmap(@"Characters\afterflash\" + _name + ".png");
                    break;
                }
            }
            A++;
        }

        public void Panel1Graphics(Graphics e)
        {
            if (Letter != A1.Length - 1 && _word == "You were Wrong")
                Loop = false;
            if (Letter != A1.Length - 1)
            {
                _word += A1[Letter];
                e.DrawString(_word, new Font(FontFamily.GenericSansSerif, _size, FontStyle.Bold, GraphicsUnit.Pixel),
                    Brushes.Silver, new Point(X, 50));
                Letter++;
                Thread.Sleep(50);
            }
            else
            {
                A1 = "You were Wrong.  ";
                FlashColour();
                Letter = 0;
                _word = null;
                timer2.Interval = 300;
                X = 250;
                _size = 60;
            }
        }

        public void FlashColour()
        {
            BackColor = Arr[I];
            Invalidate();
            Thread.Sleep(70);
            I++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
            Invalidate();
        }

        private void startscreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F1) return;
            new Form1().Show();
            Hide();
        }
    }
}