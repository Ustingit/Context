using Enum = BelarusContextStandart.Models.LanguageModels.Languages.Enum;

namespace BelarusContextStandart.Models.LanguageModels
{
    public class TranslateModel
    {
        public static TranslateModel Default = new TranslateModel(LanguageConfiguration.DefaultFromLang, 
            LanguageConfiguration.DefaultToLang, string.Empty);

        public TranslateModel(Enum from, Enum to, string data, bool reverse = false)
        {
            FromLang = from;
            ToLang = to;
            Data = data;
            Reverse = reverse;
        }

        public Enum FromLang { get; set; }

        public Enum ToLang { get; set; }

        public string Data { get; set; }

        public bool Reverse { get; set; }
    }
}