using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;
using System.Windows.Forms;

namespace GameEngine2D
{
    public class KeyboardManager
    {
        private static Microsoft.DirectX.DirectInput.Device keyboard;
        private static CustomKeyboardState oldState;
        private static CustomKeyboardState newState;

        public static void InitKeyboard(Control form)
        {
            keyboard = new Device(SystemGuid.Keyboard);
            keyboard.SetCooperativeLevel(form.FindForm(), CooperativeLevelFlags.NonExclusive | CooperativeLevelFlags.Background);
            keyboard.Acquire();
        }

        private class CustomKey
        {
            private Key k;
            private bool pressed;
            private bool held;

            public CustomKey(Key k)
            {
                this.k = k;
                this.pressed = false;
                this.held = false;
            }

            public Key GetKey() { return this.k; }
            public bool GetPressed() { return this.pressed; }
            public void SetPressed(bool pressed) { this.pressed = pressed; }
            public bool GetHeld() { return this.held; }
            public void SetHeld(bool held) { this.held = held; }
        }

        private static CustomKey[] keys = new CustomKey[] {
            new CustomKey(Key.W),
            new CustomKey(Key.A),
            new CustomKey(Key.S),
            new CustomKey(Key.D),
            new CustomKey(Key.LeftShift),
            new CustomKey(Key.Space),
        };

        private class CustomKeyboardState
        {
            private Key[] keys;

            public CustomKeyboardState(Microsoft.DirectX.DirectInput.Device keyboard)
            {
                keys = keyboard.GetPressedKeys();
            }

            public bool IsKeyDown(Key key)
            {
                bool down = false;

                foreach (Key k in keys)
                {
                    if (k == key)
                        down = true;
                }

                return down;
            }

            public bool IsKeyUp(Key key)
            {
                bool up = true;

                foreach (Key k in keys)
                {
                    if (k == key)
                    {
                        up = false;
                    }
                }

                return up;
            }
        }

        public static void Update()
        {
            newState = new CustomKeyboardState(keyboard);

            foreach (CustomKey k in keys)
            {
                if(newState.IsKeyDown(k.GetKey()))
                    k.SetHeld(true);
                if(newState.IsKeyUp(k.GetKey()))
                    k.SetHeld(false);

                if (newState.IsKeyDown(k.GetKey()) && oldState.IsKeyUp(k.GetKey()))
                    k.SetPressed(true);
                else
                    k.SetPressed(false);
            }

            oldState = newState;
        }

        public static bool IsKeyPressedOnce(Key key)
        {
            foreach (CustomKey k in keys)
            {
                if (k.GetKey() == key)
                {
                    return k.GetPressed();
                }
            }
            return false;
        }

        public static bool IsKeyHeld(Key key)
        {
            foreach (CustomKey k in keys)
            {
                if (k.GetKey() == key)
                {
                    return k.GetHeld();
                }
            }
            return false;
        }
    }
}
