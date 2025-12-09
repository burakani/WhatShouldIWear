namespace WhatShouldIWear.Models.Enums
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Occasion
    {
        Casual = 0,
        Business = 1,
        Sport = 2,
        Wedding = 3,
        Party = 4,
        Travel = 5
    }
}
