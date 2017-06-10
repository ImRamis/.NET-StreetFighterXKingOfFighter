#region

using System.Windows.Forms;

#endregion

namespace StreetFighterXKingOfFighter
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            IGameController m = new GameController(this);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}