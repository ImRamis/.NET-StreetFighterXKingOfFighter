#region

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace StreetFighterXKingOfFighter
{
    internal class Time
    {
        private int _size = 30;
        private int _time2 = 20;
        public Form Outer;
        public Panel Panel;
        public int Textx = 150;
        public int Texty = 50;
        public Timer Tim = new Timer();

        public Time(Form faram, Panel panel)
        {
            Panel = panel;
            Panel.Paint += panel_Paint;
            Outer = faram;
            Tim.Start();
            Tim.Interval = 500;
            Tim.Tick += timer1_Tick;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Method(e.Graphics);
        }

        public void Method(Graphics ponka)
        {
            ponka.DrawString(_time2.ToString(),
                new Font(FontFamily.GenericSansSerif, _size, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.IndianRed,
                new PointF(Textx, Texty));
            if (_time2 >= 10) return;
            _size += 3;
            Textx -= 5;
            Texty -= 5;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Panel.Invalidate();
            _time2--;
            if (_time2 < 1)
                Tim.Stop();
        }
    }
}