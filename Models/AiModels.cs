using System.Text.Json.Serialization;

namespace WhatShouldIWear.Models
{
    public class AiModels
    {
        #region REQUEST MODELS
        public class GeminiRequest
        {
            [JsonPropertyName("contents")]
            public List<RequestContent> Contents { get; set; }
        }

        public class RequestContent
        {
            [JsonPropertyName("parts")]
            public List<Part> Parts { get; set; }
        }

        public class Part
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }
        }
        #endregion

        #region RESPONSE MODELS
        public class GeminiResponse
        {
            [JsonPropertyName("candidates")]
            public List<Candidate> Candidates { get; set; }
        }

        public class Candidate
        {
            [JsonPropertyName("content")]
            public ResponseContent Content { get; set; }
        }

        public class ResponseContent
        {
            [JsonPropertyName("parts")]
            public List<Part> Parts { get; set; }
        }
        #endregion
    }
}
