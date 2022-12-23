namespace NWAPI_WelcomeMessage
{
    using System.ComponentModel;

    public class Config
    {
        [Description("The message to display to players when they join the server.")]
        public string WelcomeMessage { get; set; } = "Welcome %playername%!";
        [Description("The duration of the message in seconds.")]
        public ushort Duration { get; set; } = 5;
        [Description("Whether or not to use broacasts. If false, hints will be used instead")]
        public bool UseBroadcasts { get; set; } = true;
    }
}