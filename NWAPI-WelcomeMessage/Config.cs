namespace NWAPI_WelcomeMessage
{
    using System.ComponentModel;

    public class Config
    {
        [Description("The message to display to players when they join the server.")]
        public string WelcomeMessage { get; set; } = "Welcome %playername%!";
        [Description("The duration of the message in seconds.")]
        public ushort Duration { get; set; } = 5;
    }
}