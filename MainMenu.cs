#region

using System;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace StreetFighterXKingOfFighter
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            SetDefaultP1();
            SetDefaultP2();
        }

        public void SetDefaultP1()
        {
            GameController.Player1.ConfigKeys.Up = Keys.Up;
            GameController.Player1.ConfigKeys.Down = Keys.Down;
            GameController.Player1.ConfigKeys.Left = Keys.Left;
            GameController.Player1.ConfigKeys.Right = Keys.Right;
            GameController.Player1.ConfigKeys.A = Keys.A;
            GameController.Player1.ConfigKeys.B = Keys.S;
            GameController.Player1.ConfigKeys.C = Keys.D;
            GameController.Player1.ConfigKeys.D = Keys.F;
        }

        public void SetDefaultP2()
        {
            GameController.Player2.ConfigKeys.Up = Keys.I;
            GameController.Player2.ConfigKeys.Down = Keys.K;
            GameController.Player2.ConfigKeys.Left = Keys.J;
            GameController.Player2.ConfigKeys.Right = Keys.L;
            GameController.Player2.ConfigKeys.A = Keys.D5;
            GameController.Player2.ConfigKeys.B = Keys.D6;
            GameController.Player2.ConfigKeys.C = Keys.D7;
            GameController.Player2.ConfigKeys.D = Keys.D8;
        }

        private void keysSet_Click(object sender, EventArgs e)
        {
            DisableControls(false);
            var a = sender as Button;
            a.Text = @"Press";
            KeyDown += (s, ew) =>
            {
                switch (a.Name)
                {
                    case "p1Up":
                        GameController.Player1.ConfigKeys.Up = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p1Down":
                        GameController.Player1.ConfigKeys.Down = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p1Left":
                        GameController.Player1.ConfigKeys.Left = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p1Right":
                        GameController.Player1.ConfigKeys.Right = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p1A":
                        GameController.Player1.ConfigKeys.A = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p1B":
                        GameController.Player1.ConfigKeys.B = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p1C":
                        GameController.Player1.ConfigKeys.C = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p1D":
                        GameController.Player1.ConfigKeys.D = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p2Up":
                        GameController.Player2.ConfigKeys.Up = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p2Down":
                        GameController.Player2.ConfigKeys.Down = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p2Left":
                        GameController.Player2.ConfigKeys.Left = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p2Right":
                        GameController.Player2.ConfigKeys.Right = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p2A":
                        GameController.Player2.ConfigKeys.A = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p2B":
                        GameController.Player2.ConfigKeys.B = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p2C":
                        GameController.Player2.ConfigKeys.C = ew.KeyCode;
                        SetText(a, ew);
                        break;
                    case "p2D":
                        GameController.Player2.ConfigKeys.D = ew.KeyCode;
                        SetText(a, ew);
                        break;
                }
                Events.Dispose();
            };
        }

        private void SetText(Control a, KeyEventArgs ew)
        {
            a.Text = ew.KeyCode.ToString();
            DisableControls(true);
        }

        private void DisableControls(bool enable)
        {
            if (!enable)
                foreach (var item in Controls.OfType<Button>())
                    item.Enabled = false;
            else
                foreach (var item in Controls.OfType<Button>())
                    item.Enabled = true;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            new GameForm().Show();
            Hide();
        }

        private void ForceExit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}