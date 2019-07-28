namespace RCLib.Models.ConsoleSpecific
{
    /// <summary>
    /// A generic button
    /// </summary>
    public class GenericConsoleButton : IConsoleButton
    {
        public ConsoleNameEnum ConsoleName { get; set; } = ConsoleNameEnum.NONE;
        public GenericKeyNameEnum KeyName { get; set; } = GenericKeyNameEnum.NONE;
        public ConsoleKeyStateEnum KeyState { get; set; } = ConsoleKeyStateEnum.NONE;
    }
}
