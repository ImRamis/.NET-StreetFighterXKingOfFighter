#region

using System;
using System.Windows.Forms;

#endregion

namespace StreetFighterXKingOfFighter
{
    internal interface IGameController
    {
        void CharacterPos(object sender, EventArgs e);
        void Graphics();
        void Drawing(object sender, PaintEventArgs e);
    }
}