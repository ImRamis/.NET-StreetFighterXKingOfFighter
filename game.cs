#region

using System;
using System.Windows.Forms;

#endregion

namespace StreetFighterXKingOfFighter
{
    internal class Game : Keyboard, IGame
    {
        private readonly CharacterMain _player;
        private bool _colLeft, _colRight;
        private int _jumpDistance = 50;

        public Game(CharacterMain player)
        {
            _player = player;
            var actionLoop = new Timer {Interval = 30};
            actionLoop.Tick += GameMove;
            actionLoop.Start();
        }

        public void GameMove(object sender, EventArgs e)
        {
            if (GameController.Player1.Hp < 10)
                GameController.Player1.Stance = CharacterBody.Drop;
            if (GameController.Player2.Hp < 10)
                GameController.Player2.Stance = CharacterBody.Drop;
            switch (_player.Stance)
            {
                case CharacterBody.Idle:
                    break;
                case CharacterBody.Right:
                    if (CheckCollision.CheckIntersection() | _colLeft)
                    {
                        if (_player.X < 700)
                            _player.X += 5;
                    }
                    else
                    {
                        _colRight = true;
                        _colLeft = false;
                    }
                    break;
                case CharacterBody.Left:
                    if (CheckCollision.CheckIntersection() | _colRight)
                    {
                        if (_player.X > 0)
                            _player.X -= 5;
                    }
                    else
                    {
                        _colRight = false;
                        _colLeft = true;
                    }
                    break;
                case CharacterBody.Jump:
                    _player.Y -= _jumpDistance;
                    _jumpDistance -= 5;
                    if (_player.Y > 250)
                    {
                        _player.Stance = CharacterBody.Idle;
                        if (_player.Player == "Player 1")
                            DisableJump1 = true;
                        else
                            DisableJump2 = true;
                        _jumpDistance = 50;
                    }
                    break;
                case CharacterBody.Jumpleft:
                    _player.Y -= _jumpDistance;
                    if (CheckCollision.CheckIntersection())
                        _player.X -= 10;
                    _jumpDistance -= 5;
                    if (_player.Y > 250)
                    {
                        if (_player.Player == "Player 1")
                            DisableJump1 = true;
                        else
                            DisableJump2 = true;
                        _jumpDistance = 50;
                        _player.Stance = CharacterBody.Idle;
                    }
                    break;
                case CharacterBody.Jumpright:
                    _player.Y -= _jumpDistance;
                    if (CheckCollision.CheckIntersection())
                        _player.X += 10;
                    _jumpDistance -= 5;
                    if (_player.Y > 250)
                    {
                        if (_player.Player == "Player 1")
                            DisableJump1 = true;
                        else
                            DisableJump2 = true;
                        _jumpDistance = 50;
                        _player.Stance = CharacterBody.Idle;
                    }
                    break;
                case CharacterBody.JumpPunch:
                    _player.Y -= _jumpDistance;
                    _jumpDistance -= 5;
                    if (_player.Y > 250)
                    {
                        if (_player.Player == "Player 1")
                            DisableJump1 = true;
                        else
                            DisableJump2 = true;
                        _jumpDistance = 50;
                        _player.Stance = CharacterBody.Idle;
                    }
                    break;
                case CharacterBody.JumpKick:
                    _player.Y -= _jumpDistance;
                    _jumpDistance -= 5;
                    if (_player.Y > 250)
                    {
                        if (_player.Player == "Player 1")
                            DisableJump1 = true;
                        else
                            DisableJump2 = true;
                        _jumpDistance = 50;
                        _player.Stance = CharacterBody.Idle;
                    }
                    break;
                case CharacterBody.Duck:
                    break;
                case CharacterBody.LowPunch:
                    if (!CheckCollision.CheckIntersection())
                        if (_player.Player == "Player 1")
                        {
                            GameController.Player2.Hp -= 1;
                            GameController.Player2.Stance = CharacterBody.TookHit;
                        }
                        else
                        {
                            GameController.Player1.Hp -= 1;
                            GameController.Player1.Stance = CharacterBody.TookHit;
                        }
                    break;
                case CharacterBody.HighPunch:
                    if (!CheckCollision.CheckIntersection())
                        if (_player.Player == "Player 1")
                        {
                            GameController.Player2.Hp -= 2;
                            GameController.Player2.Stance = CharacterBody.TookHit;
                        }
                        else
                        {
                            GameController.Player1.Hp -= 2;
                            GameController.Player1.Stance = CharacterBody.TookHit;
                        }
                    break;
                case CharacterBody.LowKick:
                    if (!CheckCollision.CheckIntersection())
                        if (_player.Player == "Player 1")
                        {
                            GameController.Player2.Hp -= 1;
                            GameController.Player2.Stance = CharacterBody.TookHit;
                        }
                        else
                        {
                            GameController.Player1.Hp -= 1;
                            GameController.Player1.Stance = CharacterBody.TookHit;
                        }
                    break;
                case CharacterBody.HighKick:
                    if (!CheckCollision.CheckIntersection())
                        if (_player.Player == "Player 1")
                        {
                            GameController.Player2.Hp -= 2;
                            GameController.Player2.Stance = CharacterBody.TookHit;
                        }
                        else
                        {
                            GameController.Player1.Hp -= 2;
                            GameController.Player1.Stance = CharacterBody.TookHit;
                        }
                    break;
                case CharacterBody.Special1:
                    break;
                case CharacterBody.Special2:
                    break;
                case CharacterBody.Desperation:
                    break;
                case CharacterBody.ThrowFront:
                    break;
                case CharacterBody.ThrowBack:
                    break;
                case CharacterBody.TookHit:
                    if (_player.Animated)
                        _player.Stance = CharacterBody.Idle;
                    break;
                case CharacterBody.Drop:
                    break;
                case CharacterBody.Dead:
                    break;
                case CharacterBody.Win:
                    break;
                case CharacterBody.Lose:
                    break;
            }
        }
    }
}