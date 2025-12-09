namespace WhatShouldIWear.Models
{
    using WhatShouldIWear.Models.Enums;

    public class OutfitSuggestionRequestModel
    {
        public Gender Gender { get; set; }

        public Occasion Occasion { get; set; }

        public Style Style { get; set; }

        public string City { get; set; }
    }
}
