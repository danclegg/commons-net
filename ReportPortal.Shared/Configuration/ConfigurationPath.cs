﻿namespace ReportPortal.Shared.Configuration
{
    public static class ConfigurationPath
    {
        public static readonly string KeyDelimeter = ":";

        public static readonly string ServerUrl = $"Server{KeyDelimeter}Url";
        public static readonly string ServerProject = $"Server{KeyDelimeter}Project";
        public static readonly string ServerAuthenticationUuid = $"Server{KeyDelimeter}Authentication{KeyDelimeter}Uuid";

        public static readonly string LaunchName = $"Launch{KeyDelimeter}Name";
        public static readonly string LaunchDescription = $"Launch{KeyDelimeter}Description";
        public static readonly string LaunchDebugMode = $"Launch{KeyDelimeter}DebugMode";
        public static readonly string LaunchTags = $"Launch{KeyDelimeter}Tags";
    }
}
