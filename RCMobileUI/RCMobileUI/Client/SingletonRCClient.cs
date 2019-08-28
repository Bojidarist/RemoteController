using RCLib.Client;

namespace RCMobileUI.Client
{
    /// <summary>
    /// A singleton <see cref="RCClient"/>
    /// </summary>
    static class SingletonRCClient
    {
        /// <summary>
        /// The client
        /// </summary>
        public static RCClient SingleRCClient { get; } = new RCClient();
    }
}
