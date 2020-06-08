using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using BelarusContextStandart.Models.LanguageModels;
using BelarusContextStandart.Models.LanguageModels.Languages;
using BelarusContextStandart.Parsers;
using Enum = BelarusContextStandart.Models.LanguageModels.Languages.Enum;

namespace BelarusContextStandart.Models.TemporaryLanguageData
{
    public class TempDataProvider
    {
        private static readonly Guid belLangId = Guid.Parse("D4D0F4AC-ECEC-4446-BDD3-BBC5A8D489F0");
        private static readonly Guid rusLangId = Guid.Parse("4E5B4496-6960-407B-AD4A-5DC7B5392FE3");
        private static readonly Guid engLangId = Guid.Parse("FC118C73-0E92-4176-B341-4601F89156F9");

        private static readonly Guid unknownLangId = Guid.Parse("ED19E8D9-C492-4441-A7CB-B5D327273F71");

        public static readonly Dictionary<Guid, Language> Langs = new Dictionary<Guid, Language>
        {
            { belLangId, new Language(belLangId, Enum.Belarus) },
            { rusLangId, new Language(rusLangId, Enum.Russian) },
            { engLangId, new Language(engLangId, Enum.English) },
            { unknownLangId, new Language(unknownLangId, Enum.UnknownLanguage) }
        };

        public static Language Get(Enum lang)
        {
            switch (lang)
            {
                case Enum.Belarus:
                    return Langs[belLangId];
                case Enum.Russian:
                    return Langs[rusLangId];
                case Enum.English:
                    return Langs[engLangId];
                default:
                    throw new InvalidOperationException("unknown language");
            }
        }

        public static SearchResult GetTranslation(TranslateModel data)
        {
            var tempSearch = "мне";
            var result = new List<string>();

            if (true) // !string.IsNullOrEmpty(data?.Data)
            {
                foreach (var file in FileParser.GetFiles())
                {
                    foreach (var row in File.ReadAllLines(file.FullName))
                    {
                        if (row.Contains(tempSearch))
                        {
                            var startIndex = row.IndexOf(tempSearch, StringComparison.CurrentCultureIgnoreCase);

                            var from = (startIndex - 15) < 0 ? 0 : startIndex - 15;
                            var to = (startIndex + 15) < (row.Length - 1) ? startIndex + 15 : row.Length - 1;
                            var length = (from + 15) < (row.Length - 1) ? 15 : row.Length - 1;

                            result.Add(row.Substring(from, length));
                        }
                    }
                }
            }

            return SearchResult.GetEmpty();
        }
    }
}