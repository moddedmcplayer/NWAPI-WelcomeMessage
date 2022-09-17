namespace NWAPI_WelcomeMessage
{
    using MEC;
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;

    public class Plugin
    {
        [PluginEntryPoint("WelcomeMessage", "1.0.0", "Displays a welcome message when users join.", "moddedmcplayer")]
        void Enabled()
        {
        }

        [PluginEvent(ServerEventType.PlayerJoined)]
        void OnPlayerJoin(Player player)
        {
            Timing.CallDelayed(1f, () =>
            {
                player.SendBroadcast(Config.WelcomeMessage.Replace("%playername", player.Nickname), Config.Duration);
            });
        }

        [PluginConfig]
        public Config Config;
    }
}