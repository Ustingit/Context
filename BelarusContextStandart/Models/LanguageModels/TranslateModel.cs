using System;

namespace BelarusContextStandart.Models.LanguageModels
{
    public class TranslateModel
    {
        public static TranslateModel Default = new TranslateModel(LanguageConfiguration.DefaultFromLang.Id, 
            LanguageConfiguration.DefaultToLang.Id, string.Empty);

        public TranslateModel(Guid from, Guid to, string data)
        {
            FromLang = from;
            ToLang = to;
            Data = data;
        }

        public Guid FromLang { get; set; }

        public Guid ToLang { get; set; }

        public string Data { get; set; }

        public bool Reverse { get; set; }
    }
}