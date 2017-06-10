#region

using System.Drawing;

#endregion

namespace StreetFighterXKingOfFighter
{
    internal interface ICharacter
    {
        void StanceSelect();
        void StanceSelect(string location, CharacterBody stance);
        void NextFrame(Graphics _object, int height, int width);
    }
}