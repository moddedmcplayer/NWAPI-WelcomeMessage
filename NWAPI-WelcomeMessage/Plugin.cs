namespace NWAPI_WelcomeMessage
{
    using PluginAPI.Core.Attributes;
    using PluginAPI.Events;

    public class Plugin
    {
        public static Plugin Singleton;

        [PluginEntryPoint("WelcomeMessage", "1.1.2", "Displays a welcome message when users join.", "moddedmcplayer")]
        public void Enabled()
        {
            Singleton = this;
            EventManager.RegisterEvents(this, new EventHandler());
        }

        [PluginUnload]
        public void Disabled()
        {
            EventManager.UnregisterEvents<EventHandler>(this);
        }

        [PluginConfig]
        public Config Config;
    }
}