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
        public GenericConsoleButton()
        {
            this.ConsoleName = ConsoleNameEnum.NONE;
            this.KeyName = GenericKeyNameEnum.NONE;
            this.KeyState = ConsoleKeyStateEnum.NONE;
        }

        #endregion
    }
}
