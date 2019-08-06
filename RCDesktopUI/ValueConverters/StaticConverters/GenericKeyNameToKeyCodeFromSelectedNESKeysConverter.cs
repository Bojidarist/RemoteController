using System;
using AutoSharp;
using RCLib.Models;
using RCDesktopUI.SelectedControllerKeys;

namespace RCDesktopUI.ValueConverters
{
    public static class GenericKeyNameToKeyCodeFromSelectedNESKeysConverter
    {
        /// <summary>
        /// Converts the <see cref="GenericKeyNameEnum"/> to <see cref="KeyboardKeyCodes"/>
        /// from <see cref="SelectedNESKeys"/>
        /// </summary>
        public static KeyboardKeyCodes Convert(GenericKeyNameEnum keyName)
        {
            switch (keyName)
            {
                case GenericKeyNameEnum.LEFTARROW:
                    return SelectedNESKeys.LEFTARROW;
                case GenericKeyNameEnum.RIGHTARROW:
                    return SelectedNESKeys.RIGHTARROW;
                case GenericKeyNameEnum.UPARROW:
                    return SelectedNESKeys.UPARROW;
                case GenericKeyNameEnum.DOWNARROW:
                    return SelectedNESKeys.DOWNARROW;
                case GenericKeyNameEnum.SELECT:
                    return SelectedNESKeys.SELECT;                    
                case GenericKeyNameEnum.START:
                    return SelectedNESKeys.START;
                case GenericKeyNameEnum.A:
                    return SelectedNESKeys.A;
                case GenericKeyNameEnum.B:
                    return SelectedNESKeys.B;
                default:
                    throw new ArgumentException("Not a valid key for convertion!");
            }
        }
    }
}
