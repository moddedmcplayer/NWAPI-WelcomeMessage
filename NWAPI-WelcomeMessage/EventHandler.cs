namespace NWAPI_WelcomeMessage
{
    using MEC;
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;

    public class EventHandler
    {
        [PluginEvent(ServerEventType.PlayerJoined)]
        public void OnPlayerJoin(Player player)
        {
            Timing.CallDelayed(1f, () =>
            {
                player.GameObject.AddComponent<WelcomeMessageComponent>();
            });
        }
    }
}