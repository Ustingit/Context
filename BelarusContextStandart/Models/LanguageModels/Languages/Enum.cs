using System.ComponentModel;

namespace BelarusContextStandart.Models.LanguageModels.Languages
{
    public enum Enum
    {
        Belarus = 1,
        Russian = 2,
        English = 3,
        Ukrainian = 4,
        Polish = 5,
        
        [Description(Helpers.Web.EnumDescriptionDropDownList.IgnoreAttributeName)]
        UnknownLanguage = 6
    }
}