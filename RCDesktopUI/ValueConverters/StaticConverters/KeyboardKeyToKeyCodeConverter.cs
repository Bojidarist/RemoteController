using RCLib.Models;
using System;
using AutoSharp;

namespace RCDesktopUI.ValueConverters
{
    public static class KeyboardKeyToKeyCodeConverter
    {
        /// <summary>
        /// Converts the <see cref="KeyboardKeysEnum"/> to <see cref="KeyboardKeyCodes"/>
        /// </summary>
        public static KeyboardKeyCodes Convert(KeyboardKeysEnum keyboardKey)
        {
            switch (keyboardKey)
            {
                case KeyboardKeysEnum.A:
                    return KeyboardKeyCodes.VK_KEY_A;
                case KeyboardKeysEnum.B:
                    return KeyboardKeyCodes.VK_KEY_B;
                case KeyboardKeysEnum.C:
                    return KeyboardKeyCodes.VK_KEY_C;
                case KeyboardKeysEnum.D:
                    return KeyboardKeyCodes.VK_KEY_D;
                case KeyboardKeysEnum.E:
                    return KeyboardKeyCodes.VK_KEY_E;
                case KeyboardKeysEnum.F:
                    return KeyboardKeyCodes.VK_KEY_F;
                case KeyboardKeysEnum.G:
                    return KeyboardKeyCodes.VK_KEY_G;
                case KeyboardKeysEnum.H:
                    return KeyboardKeyCodes.VK_KEY_H;
                case KeyboardKeysEnum.I:
                    return KeyboardKeyCodes.VK_KEY_I;
                case KeyboardKeysEnum.J:
                    return KeyboardKeyCodes.VK_KEY_J;
                case KeyboardKeysEnum.K:
                    return KeyboardKeyCodes.VK_KEY_K;
                case KeyboardKeysEnum.L:
                    return KeyboardKeyCodes.VK_KEY_L;
                case KeyboardKeysEnum.M:
                    return KeyboardKeyCodes.VK_KEY_M;
                case KeyboardKeysEnum.N:
                    return KeyboardKeyCodes.VK_KEY_N;
                case KeyboardKeysEnum.O:
                    return KeyboardKeyCodes.VK_KEY_O;
                case KeyboardKeysEnum.P:
                    return KeyboardKeyCodes.VK_KEY_P;
                case KeyboardKeysEnum.Q:
                    return KeyboardKeyCodes.VK_KEY_Q;
                case KeyboardKeysEnum.R:
                    return KeyboardKeyCodes.VK_KEY_R;
                case KeyboardKeysEnum.S:
                    return KeyboardKeyCodes.VK_KEY_S;
                case KeyboardKeysEnum.T:
                    return KeyboardKeyCodes.VK_KEY_T;
                case KeyboardKeysEnum.U:
                    return KeyboardKeyCodes.VK_KEY_U;
                case KeyboardKeysEnum.V:
                    return KeyboardKeyCodes.VK_KEY_V;
                case KeyboardKeysEnum.W:
                    return KeyboardKeyCodes.VK_KEY_W;
                case KeyboardKeysEnum.X:
                    return KeyboardKeyCodes.VK_KEY_X;
                case KeyboardKeysEnum.Y:
                    return KeyboardKeyCodes.VK_KEY_Y;
                case KeyboardKeysEnum.Z:
                    return KeyboardKeyCodes.VK_KEY_Z;
                default:
                    throw new ArgumentException("Not a valid key for convertion!");
            }
        }
    }
}
