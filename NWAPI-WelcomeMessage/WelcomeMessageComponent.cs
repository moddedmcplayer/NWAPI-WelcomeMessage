namespace NWAPI_WelcomeMessage
{
    using PluginAPI.Core;
    using UnityEngine;

    public class WelcomeMessageComponent : MonoBehaviour
    {
        private Player player;
        private float ticks;
        private bool ready = false;
        private void Awake()
        {
            player = Player.Get(GetComponent<ReferenceHub>());
            ticks = Plugin.Singleton.Config.Delay;
            ready = true;
        }

        private void FixedUpdate()
        {
            if (!ready)
                return;
            if (ticks > 0)
            {
                ticks -= Time.fixedDeltaTime;
                return;
            }

            if(Plugin.Singleton.Config.UseBroadcasts)
                Broadcast.Singleton
                    .TargetAddElement(player.ReferenceHub.characterClassManager.connectionToClient, 
                        Plugin.Singleton.Config.WelcomeMessage.Replace("%playername%", player.Nickname), 
                        Plugin.Singleton.Config.Duration, Broadcast.BroadcastFlags.Normal);
            else
                player.ReceiveHint(Plugin.Singleton.Config.WelcomeMessage.Replace("%playername%", player.Nickname), Plugin.Singleton.Config.Duration);
            Destroy(this);
        }
    }
}