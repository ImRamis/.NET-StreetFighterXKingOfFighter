#region

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

#endregion

namespace StreetFighterXKingOfFighter
{
    internal class GameController : IGameController
    {
        public static CharacterMain Player1 = new Select(Form1.Player1);
        public static CharacterMain Player2 = new Select(Form1.Player2);
        private readonly GameForm _mainForm;
        private readonly Bitmap _stage = new Bitmap(@"Characters\stage1.jpg");
        private long _frameCount;
        private bool _k;
        private DateTime _lastCheckTime = DateTime.Now;

        private int _m = 60;

        public GameController(GameForm mainForm)
        {
            Player1.Player = "Player 1";
            Player2.Player = "Player 2";
            Player1.Hp = 400;
            Player2.Hp = 400;
            _mainForm = mainForm;
            Player1.PosLeft = false;
            Player2.PosLeft = true;
            var keyboard1 = new Keyboard(mainForm, Player1.ConfigKeys, true);
            var Keyboard2 = new Keyboard(mainForm, Player2.ConfigKeys, false);
            Player1.StanceSelect();
            Player2.StanceSelect();
            Player2.X = 440;
            Graphics();
            var verifyPos = new Timer();
            verifyPos.Tick += CharacterPos;
            verifyPos.Start();
            mainForm.FormClosed += forceExit;
            var timer = new Timer {Interval = 1000};
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void CharacterPos(object sender, EventArgs e)
        {
            if (Player1.X > Player2.X)
            {
                Player1.PosLeft = true;
                Player2.PosLeft = false;
            }
            if (Player2.X > Player1.X)
            {
                Player1.PosLeft = false;
                Player2.PosLeft = true;
            }
        }

        public void Graphics()
        {
            var gameGraphics = new Timer();
            gameGraphics.Tick += gameGraphics_Tick;
            _mainForm.dB_Panel1.Paint += Drawing;
            gameGraphics.Interval = 50;
            gameGraphics.Start();
        }

        public void Drawing(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_stage, new Point(-300, -180));
            Player1.NextFrame(e.Graphics, 250, 400);
            Player2.NextFrame(e.Graphics, 250, 400);
            if (_k == false)
            {
                var game1 = new Game(Player1);
                var game = new Game(Player2);
                _k = true;
            }
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(10, 10, 400, 50));
            e.Graphics.FillRectangle(Brushes.Green, new RectangleF(10, 10, Player1.Hp, 50));

            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(520, 10, 400, 50));
            e.Graphics.FillRectangle(Brushes.Green, new RectangleF(520, 10, Player2.Hp, 50));
            e.Graphics.FillEllipse(Brushes.Ivory, new RectangleF(427, 10, 50, 50));
            e.Graphics.FillEllipse(Brushes.Khaki, new RectangleF(447, 10, 50, 50));
            e.Graphics.FillEllipse(Brushes.IndianRed, new RectangleF(437, 10, 50, 50));
            e.Graphics.DrawString(_m.ToString(), new Font("Verdana", 20f), Brushes.Wheat, 440, 20);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _m--;
            if (_m != 0) return;
            if (Player1.Hp > Player2.Hp)
                MessageBox.Show(@"Player 1 Wins");
            else if (Player2.Hp > Player1.Hp)
                MessageBox.Show(@"Player 2 Wins");
            else
                MessageBox.Show(@"Draw!");
        }

        private void forceExit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gameGraphics_Tick(object sender, EventArgs e)
        {
            _mainForm.Text = GetFps() + @"FPS";
            OnMapUpdated();
            _mainForm.dB_Panel1.Invalidate();
        }

        private void OnMapUpdated()
        {
            Interlocked.Increment(ref _frameCount);
        }

        private int GetFps()
        {
            var secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
            var count = Interlocked.Exchange(ref _frameCount, 0);
            var fps = count / secondsElapsed;
            _lastCheckTime = DateTime.Now;
            return (int) fps;
        }
    }
}