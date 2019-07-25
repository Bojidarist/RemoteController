namespace RCLib.Models
{
    /// <summary>
    /// A button from a console
    /// </summary>
    public interface IConsoleButton
    {
        /// <summary>
        /// The name of the console this button is from
        /// </summary>
        ConsoleNameEnum ConsoleName { get; set; }

        /// <summary>
        /// The name of the key
        /// </summary>
        GenericKeyNameEnum KeyName { get; set; }

        /// <summary>
        /// The current state of the key
        /// </summary>
        ConsoleKeyStateEnum KeyState { get; set; }
    }
}
