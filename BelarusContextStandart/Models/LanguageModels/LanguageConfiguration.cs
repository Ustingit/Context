using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BelarusContextStandart.Models.TemporaryLanguageData;
using Enum = BelarusContextStandart.Models.LanguageModels.Languages.Enum;

namespace BelarusContextStandart.Models.LanguageModels
{
    public static class LanguageConfiguration
    {
        public static Language DefaultFromLang = TempDataProvider.Get(Enum.Russian);

        public static Language DefaultToLang = TempDataProvider.Get(Enum.Belarus);
    }
}