namespace NWAPI_WelcomeMessage
{
    using Hints;
    using MEC;
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using PluginAPI.Events;

    public class Plugin
    {
        [PluginEntryPoint("WelcomeMessage", "1.1.1", "Displays a welcome message when users join.", "moddedmcplayer")]
        void Enabled()
        {
            EventManager.RegisterEvents(this);
        }

        [PluginEvent(ServerEventType.PlayerJoined)]
        void OnPlayerJoin(Player player)
        {
            Timing.CallDelayed(4f, () =>
            {
                if(Config.UseBroadcasts)
                    Broadcast.Singleton.TargetAddElement(player.ReferenceHub.characterClassManager.connectionToClient, Config.WelcomeMessage.Replace("%playername%", player.Nickname), Config.Duration, Broadcast.BroadcastFlags.Normal);
                else
                    player.ReceiveHint(Config.WelcomeMessage.Replace("%playername%", player.Nickname), Config.Duration);
            });
        }

        [PluginConfig]
        public Config Config;
    }
}