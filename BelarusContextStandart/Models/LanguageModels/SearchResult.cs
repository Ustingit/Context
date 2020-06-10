using System;

namespace BelarusContextStandart.Models.LanguageModels
{
    public class SearchResult
    {
        public SearchResult(string[] data)
        {
            Data = data;
        }

        public static SearchResult GetEmpty()
        {
            return new SearchResult(Array.Empty<string>());
        }

        public string[] Data { get; }

        public int Count => Data.Length;

        public bool IsEmpty => Data != null && Data.Length == 0;
    }
}