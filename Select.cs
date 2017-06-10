#region

using System.Drawing;

#endregion

namespace StreetFighterXKingOfFighter
{
    internal class Select : CharacterMain
    {
        public Select(string character) : base(character)
        {
            StanceSelect();
        }

        public override CharacterBody Stance
        {
            get
            {
                if (Stanced == base.Stance.ToString()) return base.Stance;
                Stanced = base.Stance.ToString();
                StanceSelect(Stanced, base.Stance);
                return base.Stance;
            }
        }

        public sealed override void StanceSelect()
        {
            if (PosLeft)
            {
                Stance = CharacterBody.Idle;
                Body = new Bitmap(@"Characters\" + Name + @"\Idle.png");
                Body.MakeTransparent();
                Body.RotateFlip(RotateFlipType.RotateNoneFlipX);
                TotalFrames = Body.Width / Width;
            }
            else
            {
                Stance = CharacterBody.Idle;
                Body = new Bitmap(@"Characters\" + Name + @"\Idle.png");
                Body.MakeTransparent();
                TotalFrames = Body.Width / Width;
            }
        }

        public override void StanceSelect(string location, CharacterBody stance)
        {
            if (PosLeft)
            {
                Stance = stance;
                Body = new Bitmap(@"Characters\" + Name + @"\" + location + ".png");
                Body.MakeTransparent();
                Body.RotateFlip(RotateFlipType.RotateNoneFlipX);
                TotalFrames = Body.Width / Width;
            }
            else
            {
                Stance = stance;
                Body = new Bitmap(@"Characters\" + Name + @"\" + location + ".png");
                Body.MakeTransparent();
                TotalFrames = Body.Width / Width;
            }
        }
    }
}