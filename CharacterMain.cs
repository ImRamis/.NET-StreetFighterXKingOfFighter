#region

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace StreetFighterXKingOfFighter
{
    internal abstract class CharacterMain : ICharacter
    {
        public Bitmap Body;
        public ConfigPlayer ConfigKeys = new ConfigPlayer();
        protected int Frame;
        public int Hp;
        public Rectangle PlayerPosition;
        public string Stanced;
        protected int TotalFrames;
        public int X = 0;
        public int Y = 300;

        protected CharacterMain(string character)
        {
            Height = 224;
            Width = 304;
            XWidth = 40;
            Name = character;
        }

        public bool Animated { get; set; }
        public int Height { get; }
        public int Width { get; }
        public bool PosLeft { get; set; }
        public int XWidth { get; set; }

        public string Name { get; set; }

        public string Player { get; set; }
        public virtual CharacterBody Stance { get; set; }
        public abstract void StanceSelect();
        public abstract void StanceSelect(string location, CharacterBody stance);

        public virtual void NextFrame(Graphics _object, int height, int width)
        {
            PlayerPosition = new Rectangle(X, Y, height, width);
            _object.DrawImage(Body, PlayerPosition, XWidth, 0, 224, 304, GraphicsUnit.Pixel);
            XWidth += Width;
            Frame++;
            if (Frame < TotalFrames) return;
            Frame = 0;
            XWidth = 40;
            if (Player == "Player 1")
            {
                if ((GameController.Player1.Stance == CharacterBody.LowKick) |
                    (GameController.Player1.Stance == CharacterBody.HighPunch) |
                    (GameController.Player1.Stance == CharacterBody.HighKick) |
                    (GameController.Player1.Stance == CharacterBody.LowPunch) |
                    (GameController.Player1.Stance == CharacterBody.TookHit))
                    GameController.Player1.Stance = CharacterBody.Idle;
                if (GameController.Player1.Stance == CharacterBody.Drop)
                {
                    MessageBox.Show(@"Player 2 Won!");
                    Environment.Exit(1);
                }
            }
            else if (Player == "Player 2")
            {
                if ((GameController.Player2.Stance == CharacterBody.LowKick) |
                    (GameController.Player2.Stance == CharacterBody.HighPunch) |
                    (GameController.Player2.Stance == CharacterBody.HighKick) |
                    (GameController.Player2.Stance == CharacterBody.LowPunch) |
                    (GameController.Player2.Stance == CharacterBody.TookHit))
                    GameController.Player2.Stance = CharacterBody.Idle;
                if (GameController.Player2.Stance == CharacterBody.Drop)
                {
                    MessageBox.Show(@"Player 1 Won!");
                    Environment.Exit(1);
                }
            }
        }
    }
}