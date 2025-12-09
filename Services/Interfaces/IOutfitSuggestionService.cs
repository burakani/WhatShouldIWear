namespace WhatShouldIWear.Services.Interfaces
{
    using WhatShouldIWear.Models;

    public interface IOutfitSuggestionService
    {
        Task<string> GetOutfitSuggestion(OutfitSuggestionRequestModel request);
    }
}
