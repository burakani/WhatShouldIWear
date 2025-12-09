namespace WhatShouldIWear.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Text.Json;
    using WhatShouldIWear.Models;
    using WhatShouldIWear.Services.Interfaces;

    [ApiController]
    [Route("api/[controller]")]
    public class OutfitController : ControllerBase
    {
        private readonly IOutfitSuggestionService _outfitSuggestionService;

        public OutfitController(IOutfitSuggestionService outfitSuggestionService)
        {
            _outfitSuggestionService = outfitSuggestionService;
        }

        [HttpPost]
        [Route("suggestion")]
        public async Task<IActionResult> GetOutfitSuggestion([FromBody] OutfitSuggestionRequestModel request)
        {
            var jsonResponseString = await _outfitSuggestionService.GetOutfitSuggestion(request);

            if (string.IsNullOrEmpty(jsonResponseString) || !jsonResponseString.Trim().StartsWith("{"))
            {
                return BadRequest("No suggestion.");
            }

            try
            {
                var responseObj = JsonSerializer.Deserialize<OutfitSuggestionResponseModel>(jsonResponseString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Ok(responseObj);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Response Error: {ex.Message}");
            }
        }
    }
}
