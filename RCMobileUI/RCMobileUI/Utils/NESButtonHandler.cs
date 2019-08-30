using RCLib.Models;
using RCLib.Models.ConsoleSpecific;

namespace RCMobileUI.Utils
{
    public class NESButtonHandler
    {
        #region Public properties

        /// <summary>
        /// The A button
        /// </summary>
        public IConsoleButton A { get; set; }

        /// <summary>
        /// The B button
        /// </summary>
        public IConsoleButton B { get; set; }

        /// <summary>
        /// The SELECT button
        /// </summary>
        public IConsoleButton Select { get; set; }

        /// <summary>
        /// The START button
        /// </summary>
        public IConsoleButton Start { get; set; }

        /// <summary>
        /// The LEFT button
        /// </summary>
        public IConsoleButton Left { get; set; }

        /// <summary>
        /// The RIGHT button
        /// </summary>
        public IConsoleButton Right { get; set; }

        /// <summary>
        /// The UP button
        /// </summary>
        public IConsoleButton Up { get; set; }

        /// <summary>
        /// The DOWN button
        /// </summary>
        public IConsoleButton Down { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NESButtonHandler()
        {
            this.InitButtons();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize all buttons
        /// </summary>
        private void InitButtons()
        {
            this.A = new GenericConsoleButton(ConsoleNameEnum.NES, GenericKeyNameEnum.A, ConsoleKeyStateEnum.NONE);
            this.B = new GenericConsoleButton(ConsoleNameEnum.NES, GenericKeyNameEnum.B, ConsoleKeyStateEnum.NONE);
            this.Select = new GenericConsoleButton(ConsoleNameEnum.NES, GenericKeyNameEnum.SELECT, ConsoleKeyStateEnum.NONE);
            this.Start = new GenericConsoleButton(ConsoleNameEnum.NES, GenericKeyNameEnum.START, ConsoleKeyStateEnum.NONE);
            this.Left = new GenericConsoleButton(ConsoleNameEnum.NES, GenericKeyNameEnum.LEFTARROW, ConsoleKeyStateEnum.NONE);
            this.Right = new GenericConsoleButton(ConsoleNameEnum.NES, GenericKeyNameEnum.RIGHTARROW, ConsoleKeyStateEnum.NONE);
            this.Up = new GenericConsoleButton(ConsoleNameEnum.NES, GenericKeyNameEnum.UPARROW, ConsoleKeyStateEnum.NONE);
            this.Down = new GenericConsoleButton(ConsoleNameEnum.NES, GenericKeyNameEnum.DOWNARROW, ConsoleKeyStateEnum.NONE);
        }

        #endregion
    }
}
