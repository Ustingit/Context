using Enum = BelarusContextStandart.Models.LanguageModels.Languages.Enum;

namespace BelarusContextStandart.Models.LanguageModels
{
    public static class LanguageConfiguration
    {
        public static Enum DefaultFromLang = Enum.Russian;

        public static Enum DefaultToLang = Enum.Belarus;
    }
}