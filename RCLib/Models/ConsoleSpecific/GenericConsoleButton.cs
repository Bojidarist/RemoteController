namespace RCLib.Models.ConsoleSpecific
{
    /// <summary>
    /// A generic button
    /// </summary>
    public class GenericConsoleButton : IConsoleButton
    {
        #region Public properties

        /// <summary>
        /// The name of the console this button is from
        /// </summary>
        public ConsoleNameEnum ConsoleName { get; set; }

        /// <summary>
        /// The name of this button
        /// </summary>
        public GenericKeyNameEnum KeyName { get; set; }

        /// <summary>
        /// The state of this button
        /// </summary>
        public ConsoleKeyStateEnum KeyState { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="consoleName">The name of the console this button is from</param>
        /// <param name="keyName">The name of this button</param>
        /// <param name="keyState">The state of this button</param>
        public GenericConsoleButton(ConsoleNameEnum consoleName = ConsoleNameEnum.NONE,
                                    GenericKeyNameEnum keyName = GenericKeyNameEnum.NONE,
                                    ConsoleKeyStateEnum keyState = ConsoleKeyStateEnum.NONE)
        {
            this.ConsoleName = consoleName;
            this.KeyName = keyName;
            this.KeyState = keyState;
        }

        #endregion
    }
}
