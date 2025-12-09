namespace WhatShouldIWear.Services.Interfaces
{
    public interface IAiService
    {
        Task<string> GetOutfitRecommendationAsync(string prompt);
    }
}
