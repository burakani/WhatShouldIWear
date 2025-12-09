namespace WhatShouldIWear.Models.Enums
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Style
    {
        Minimalist = 0,
        Trendy = 1,
        Classic = 2,
        Vintage = 3,
        Streetwear = 4
    }
}
