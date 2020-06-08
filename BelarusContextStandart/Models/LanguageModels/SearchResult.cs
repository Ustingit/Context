using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public string[] Data { get; set; }

        public int Count => Data.Length;

        public bool IsEmpty => Data != null && Data.Length == 0;
    }
}