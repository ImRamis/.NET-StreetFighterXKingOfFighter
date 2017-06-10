#region

using System;

#endregion

namespace StreetFighterXKingOfFighter
{
    internal interface IKeyboard
    {
        void One();
        void ForceDisable();
        void UpdateGui(object sender, EventArgs e);
    }
}