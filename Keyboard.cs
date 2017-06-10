#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace StreetFighterXKingOfFighter
{
    internal class Keyboard : IKeyboard
    {
        public static bool DisableJump1;
        public static bool DisableJump2;

        private readonly IDictionary<Keys, bool> _isKeyDown;
        private readonly GameForm _mainForm;
        private readonly bool _player1;
        private ConfigPlayer _myKeys;

        public Keyboard()
        {
        }

        public Keyboard(GameForm mainForm, ConfigPlayer keyboardSetting, bool player1)
        {
            _mainForm = mainForm;
            _player1 = player1;
            _myKeys = keyboardSetting;

            var timer = new Timer
            {
                Interval = 20
            };
            timer.Tick += UpdateGui;
            timer.Start();

            _isKeyDown = new Dictionary<Keys, bool>
            {
                {keyboardSetting.Up, false},
                {keyboardSetting.Down, false},
                {keyboardSetting.Left, false},
                {keyboardSetting.Right, false},
                {keyboardSetting.A, false},
                {keyboardSetting.B, false},
                {keyboardSetting.C, false},
                {keyboardSetting.D, false}
            };

            mainForm.KeyDown += Remember;
            mainForm.KeyUp += Forget;
        }

        public void One()
        {
            if (_isKeyDown[_myKeys.Up])
                GameController.Player1.Stance = CharacterBody.Jump;
            if (_isKeyDown[_myKeys.Left])
                GameController.Player1.Stance = CharacterBody.Left;
            if (_isKeyDown[_myKeys.Right])
                GameController.Player1.Stance = CharacterBody.Right;
            if (_isKeyDown[_myKeys.Down])
                GameController.Player1.Stance = CharacterBody.Duck;
            if (_isKeyDown[_myKeys.Up] && _isKeyDown[_myKeys.Right])
                GameController.Player1.Stance = CharacterBody.Jumpright;
            if (_isKeyDown[_myKeys.Left] && _isKeyDown[_myKeys.Up])
                GameController.Player1.Stance = CharacterBody.Jumpleft;
            if (_isKeyDown[_myKeys.A])
                GameController.Player1.Stance = CharacterBody.LowPunch;
            if (_isKeyDown[_myKeys.B])
                GameController.Player1.Stance = CharacterBody.LowKick;
            if (_isKeyDown[_myKeys.C])
                GameController.Player1.Stance = CharacterBody.HighPunch;
            if (_isKeyDown[_myKeys.D])
                GameController.Player1.Stance = CharacterBody.HighKick;
        }

        public void ForceDisable()
        {
            while (true)
            {
                if (_player1)
                {
                    if (!DisableJump1) return;
                    GameController.Player1.Stance = CharacterBody.Idle;
                    _isKeyDown[GameController.Player1.ConfigKeys.Up] = false;
                    DisableJump1 = false;
                    if (GameController.Player1.Stance != CharacterBody.Jump) return;
                    DisableJump1 = true;
                    continue;
                }
                if (DisableJump2)
                {
                    GameController.Player2.Stance = CharacterBody.Idle;
                    _isKeyDown[GameController.Player2.ConfigKeys.Up] = false;
                    DisableJump2 = false;
                    if (GameController.Player2.Stance == CharacterBody.Jump)
                    {
                        DisableJump2 = true;
                        continue;
                    }
                }
                break;
            }
        }

        public void UpdateGui(object sender, EventArgs e)
        {
            ForceDisable();
            if (_player1)
            {
                One();
                GameForm.key1.Text = _isKeyDown[_myKeys.Up] ? "Up" : "";
                GameForm.key1.Text += _isKeyDown[_myKeys.Down] ? "Down" : "";
                GameForm.key1.Text += _isKeyDown[_myKeys.Left] ? "Left" : "";
                GameForm.key1.Text += _isKeyDown[_myKeys.Right] ? "Right" : "";
                GameForm.key1.Text += _isKeyDown[_myKeys.A] ? "A" : "";
                GameForm.key1.Text += _isKeyDown[_myKeys.B] ? "B" : "";
                GameForm.key1.Text += _isKeyDown[_myKeys.C] ? "C" : "";
                GameForm.key1.Text += _isKeyDown[_myKeys.D] ? "D" : "";
                //         Form1.key1.Text += OpenClass.player1.stance.ToString();
            }
            else
            {
                Two();
                GameForm.key2.Text = _isKeyDown[_myKeys.Up] ? "Up" : "";
                GameForm.key2.Text += _isKeyDown[_myKeys.Down] ? "Down" : "";
                GameForm.key2.Text += _isKeyDown[_myKeys.Left] ? "Left" : "";
                GameForm.key2.Text += _isKeyDown[_myKeys.Right] ? "Right" : "";
                GameForm.key2.Text += _isKeyDown[_myKeys.A] ? "A" : "";
                GameForm.key2.Text += _isKeyDown[_myKeys.B] ? "B" : "";
                GameForm.key2.Text += _isKeyDown[_myKeys.C] ? "C" : "";
                GameForm.key2.Text += _isKeyDown[_myKeys.D] ? "D" : "";
            }
        }

        private void Remember(object sender, KeyEventArgs e)
        {
            if (_player1)
            {
                if ((GameController.Player1.Stance != CharacterBody.Jump) &
                    (GameController.Player1.Stance != CharacterBody.Jumpright) &
                    (GameController.Player1.Stance != CharacterBody.Jumpleft))
                    _isKeyDown[e.KeyCode] = true;
            }
            else
            {
                if ((GameController.Player2.Stance != CharacterBody.Jump) &
                    (GameController.Player2.Stance != CharacterBody.Jumpright) &
                    (GameController.Player2.Stance != CharacterBody.Jumpleft))
                    _isKeyDown[e.KeyCode] = true;
            }
        }

        private void Forget(object sender, KeyEventArgs e)
        {
            if (_player1)
            {
                if (e.KeyCode == GameController.Player1.ConfigKeys.Up &&
                    _isKeyDown[GameController.Player1.ConfigKeys.Up])
                {
                }
                else
                {
                    _isKeyDown[e.KeyCode] = false;
                    if ((e.KeyCode != GameController.Player1.ConfigKeys.A) &
                        (e.KeyCode != GameController.Player1.ConfigKeys.B) &
                        (e.KeyCode != GameController.Player1.ConfigKeys.C) &
                        (e.KeyCode != GameController.Player1.ConfigKeys.D))
                        GameController.Player1.Stance = CharacterBody.Idle;
                }
            }
            else
            {
                if (e.KeyCode == GameController.Player2.ConfigKeys.Up &&
                    _isKeyDown[GameController.Player2.ConfigKeys.Up])
                {
                }
                else
                {
                    _isKeyDown[e.KeyCode] = false;
                    if ((e.KeyCode != GameController.Player2.ConfigKeys.A) &
                        (e.KeyCode != GameController.Player2.ConfigKeys.B) &
                        (e.KeyCode != GameController.Player2.ConfigKeys.C) &
                        (e.KeyCode != GameController.Player2.ConfigKeys.D))
                        GameController.Player2.Stance = CharacterBody.Idle;
                }
            }
        }

        private void Two()
        {
            if (_isKeyDown[_myKeys.Up])
                GameController.Player2.Stance = CharacterBody.Jump;
            if (_isKeyDown[_myKeys.Left])
                GameController.Player2.Stance = CharacterBody.Left;
            if (_isKeyDown[_myKeys.Right])
                GameController.Player2.Stance = CharacterBody.Right;
            if (_isKeyDown[_myKeys.Down])
                GameController.Player2.Stance = CharacterBody.Duck;
            if (_isKeyDown[_myKeys.Up] && _isKeyDown[_myKeys.Right])
                GameController.Player2.Stance = CharacterBody.Jumpright;
            if (_isKeyDown[_myKeys.Left] && _isKeyDown[_myKeys.Up])
                GameController.Player2.Stance = CharacterBody.Jumpleft;
            if (_isKeyDown[_myKeys.A])
                GameController.Player2.Stance = CharacterBody.LowPunch;
            if (_isKeyDown[_myKeys.B])
                GameController.Player2.Stance = CharacterBody.LowKick;
            if (_isKeyDown[_myKeys.C])
                GameController.Player2.Stance = CharacterBody.HighPunch;
            if (_isKeyDown[_myKeys.D])
                GameController.Player2.Stance = CharacterBody.HighKick;
        }
    }
}