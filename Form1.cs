#region

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

#endregion

namespace StreetFighterXKingOfFighter
{
    public partial class Form1 : Form, IComma
    {
        public static string Charactername = "ken";
        public static string Player1;
        public static string Player2;
        private int _startx = 200;
        private int _starty = 200;
        public bool Afterclick = true;
        public Bitmap[,] Arr = new Bitmap[3, 3];
        protected Bitmap Body;
        public int Clicktimes;
        public int Currentframe;
        public int Frame;
        public bool G = true;
        public bool Hover1 = true;
        public bool Hoverselect2;
        public Bitmap Img = new Bitmap(@"Characters\" + Charactername + @"\idle.png");
        public Bitmap Imgrotate = new Bitmap(@"Characters\" + Charactername + @"\idle.png");
        public bool Inverse = true;

        public int Locx = 0;
        public int Maxframe;
        public PictureBox[,] Pic = new PictureBox[3, 3];
        public bool Player2Move = false;
        public bool Select2 = true;
        public bool Sizeprob;
        public int TotalFrames;
        public int X;
        public int X1 = 0;
        public int Y1 = 300;

        public Form1()
        {
            InitializeComponent();
            var time1 = new Time(this, panel3);
            //this.Close();
            TotalFrames = Img.Width / 304;
            Maxframe = Img.Width / 304;
            Height1 = 224;
            Width1 = 304;
            var time = new Time(this, panel3);
            XWidth = 0;
            Body = new Bitmap(@"Characters\athena\idle.png");
            Body.MakeTransparent();
        }

        public int XWidth { get; set; }
        public int Height1 { get; }
        public int Width1 { get; }

        public int a { get; set; } = -50;

        public Bitmap Img2
        {
            get
            {
                Img.MakeTransparent();
                return Img;
            }
            set => Img = value;
        }

        public Bitmap Img3
        {
            get
            {
                Imgrotate.MakeTransparent();
                return Imgrotate;
            }
            set => Imgrotate = value;
        }

        public void Callcharacter(PictureBox use)
        {
            if (use == Pic[0, 0]) Charactername = Character.Ken.ToString();
            if (use == Pic[0, 1]) Charactername = Character.Kyo.ToString();
            if (use == Pic[0, 2]) Charactername = Character.Iori.ToString();
            if (use == Pic[1, 0]) Charactername = Character.Athena.ToString();
            if (use == Pic[1, 1]) Charactername = Character.Terry.ToString();
            if (use == Pic[1, 2]) Charactername = Character.Kim.ToString();
            if (use == Pic[2, 0]) Charactername = Character.Mai.ToString();
            if (use == Pic[2, 1]) Charactername = Character.Goentiz.ToString();
            if (use == Pic[2, 2]) Charactername = Character.Choi.ToString();
        }

        public void Sizeinc(PictureBox t)
        {
            for (var i = 0; i < 5; i++)
            {
                t.Location = new Point(t.Location.X - 1, t.Location.Y - 1);
                t.Width += 2;
                t.Height += 2;
                Thread.Sleep(10);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackgroundImage = new Bitmap(@"1.jpg");
            var k = new Timer();
            k.Tick += k_Tick;
            k.Interval = 70;
            k.Start();
            var poster = 0;

            for (var j = 0; j <= 2; j++)
            {
                for (var i = 0; i <= 2; i++)
                {
                    Arr[j, i] = new Bitmap(@"poster\" + poster + ".png");
                    poster++;
                    Arr[j, i].MakeTransparent(Color.White);
                    Pic[j, i] = new PictureBox
                    {
                        BackgroundImage = Arr[j, i],
                        Location = new Point(_startx, _starty),
                        Size = new Size(100, 70)
                    };
                    _startx += 180;
                    Pic[j, i].MouseHover += picture_MouseHover;
                    Pic[j, i].MouseLeave += picture_MouseLeave;
                    Pic[j, i].BackgroundImageLayout = ImageLayout.Stretch;
                    Pic[j, i].Click += image_click;
                    Controls.Add(Pic[j, i]);
                }
                _startx = 200;
                _starty += 90;
            }
            _starty = 200;
            panel1.Paint += panel1_Paint;
            panel2.Paint += panel2_Paint;
            panel2.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (Select2)
            {
                Img3 = new Bitmap(@"Characters\" + Charactername + @"\idle.png");
                Hoverselect2 = false;
                Select2 = false;
            }
            CreateGraphics2(e.Graphics);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (Hover1)
                if (Afterclick)
                {
                    Img2 = new Bitmap(@"Characters\" + Charactername + @"\idle.png");
                    Hover1 = false;
                }
            CreateGraphics(e.Graphics);
        }

        private void image_click(object sender, EventArgs e)
        {
            var use = sender as PictureBox;
            Clicktimes++;
            if (Clicktimes == 2)
            {
                Player2 = Charactername;
                Close();
                new MainMenu().Show();
            }
            else
            {
                Player1 = Charactername;
            }
            panel2.Visible = true;
            Afterclick = false;
        }

        public void CreateGraphics2(Graphics e)
        {
            Img3.RotateFlip(RotateFlipType.RotateNoneFlipX);
            e.DrawImage(Img3, new Rectangle(-100, 0, 304, 203), XWidth, 0, 224, 304, GraphicsUnit.Pixel);
            XWidth += 304;
            Frame++;
            if (Frame < TotalFrames) return;
            Frame = 0;
            XWidth = 0;
        }

        public void CreateGraphics(Graphics e)
        {
            var myrec2 = new Rectangle(-100, 0, 304, 203);
            e.DrawImage(Img2, myrec2, new Rectangle(X, 0, 224, 304), GraphicsUnit.Pixel);
            X += 304;
            Currentframe++;
            if (Currentframe < Maxframe) return;
            Currentframe = 0;
            X = 0;
        }

        private void picture_MouseLeave(object sender, EventArgs e)
        {
            var use = sender as PictureBox;
            if (!Sizeprob) return;
            use.Size = new Size(100, 70);
            use.Location = new Point(use.Location.X + 5, use.Location.Y + 5);
            Sizeprob = false;
        }

        private void k_Tick(object sender, EventArgs e)
        {
            Img3.RotateFlip(RotateFlipType.RotateNoneFlipX);
            panel1.Invalidate();
            panel2.Invalidate();
        }

        private void picture_MouseHover(object sender, EventArgs e)
        {
            var use = sender as PictureBox;
            Callcharacter(use);

            if (Afterclick)
                Hoverselect2 = true;
            Hover1 = true;
            if (G)
            {
                Sizeinc(use);
                G = true;
            }
            Sizeprob = true;
            Select2 = true;
        }

        private void Form1_KeyDown(object panda, KeyEventArgs e)
        {
        }
    }
}