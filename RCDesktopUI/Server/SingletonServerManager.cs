using RCLib.Server;

namespace RCDesktopUI.Server
{
    /// <summary>
    /// A singleton ServerManager
    /// </summary>
    static class SingletonServerManager
    {
        /// <summary>
        /// The server manager
        /// </summary>
        public static ServerManager SingleServerManager { get; } = new ServerManager(8910);
    }
}
