namespace WhatShouldIWear.Models
{
    using System.Text.Json.Serialization;
    using WhatShouldIWear.Models.Enums;

    public class OutfitSuggestionResponseModel
    {
        [JsonPropertyName("outfitName")]
        public string OutfitName { get; set; }

        [JsonPropertyName("items")]
        public List<string> Items { get; set; }

        [JsonPropertyName("reasoning")]
        public string Reasoning { get; set; }
    }
}
