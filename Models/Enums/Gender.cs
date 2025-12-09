namespace WhatShouldIWear.Models.Enums
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        None = 0,
        Male = 1,
        Female = 2,
    }
}
