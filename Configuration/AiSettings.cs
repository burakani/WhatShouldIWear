namespace WhatShouldIWear.Configuration
{
    public class AiSettings
    {
        public string ApiKey { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public int TimeoutSeconds { get; set; } = 30;
        public string PromptPrefix { get; set; } = string.Empty;
    }
}
