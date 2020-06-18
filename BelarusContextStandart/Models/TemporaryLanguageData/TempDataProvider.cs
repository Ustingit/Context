using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using BelarusContextStandart.Models.LanguageModels;
using BelarusContextStandart.Models.LanguageModels.Languages;
using BelarusContextStandart.Parsers;
using Enum = BelarusContextStandart.Models.LanguageModels.Languages.Enum;

namespace BelarusContextStandart.Models.TemporaryLanguageData
{
    public class TempDataProvider
    {
        private const int RowLength = 100;

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
            var result = new List<string>();

            if (!string.IsNullOrEmpty(data?.Data))
            {
                foreach (var file in FileParser.GetFiles())
                {
                    foreach (var row in File.ReadAllLines(file.FullName))
                    {
                        if (row.Contains(data.Data))
                        {
                            var startIndex = row.IndexOf(data.Data, StringComparison.CurrentCultureIgnoreCase);

                            var from = (startIndex - 25) < 0 ? 0 : startIndex - 25;
                            var length = (from + RowLength) < (row.Length - 1) 
                                ? RowLength 
                                : row.Length - 1;



                            //Regex.Split(originalString, @"(?<=[.,;])")
                            var separators = new [] { '!', '.', '?' };
                            var sentences = Regex.Split(row, @"(?<=[.;?!])");
                            var sentencesAsList = sentences.ToList();
                            var sentenceWitItem = sentencesAsList.FirstOrDefault(x => x.Contains(data.Data));
                            var indexOfSentence = sentencesAsList.IndexOf(sentenceWitItem);
                            
                            var sb4 = new StringBuilder();
                            if (indexOfSentence <= sentences.Length / 2)
                            {
                                for (var i = indexOfSentence; i <= sentences.Length - 1; i++)
                                {
                                    if (sb4.Length <= RowLength && !string.IsNullOrEmpty(sentences[i]) && sentences[i].Length != 1)
                                    {
                                        sb4.Append(sentences[i]);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                var reversedList = new List<string>();

                                for (var i = indexOfSentence; i >= 0; i--)
                                {
                                    var isWithoutText = !string.IsNullOrEmpty(sentences[i]) && sentences[i].Length != 1;

                                    if (isWithoutText && reversedList.Sum(x => x.Length) <= RowLength)
                                    {
                                        reversedList.Add(sentences[i]);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                reversedList.Reverse();
                                foreach (var x in reversedList)
                                {
                                    sb4.Append(x);
                                }
                            }
                            result.Add(sb4.ToString());

                            /* 
                            if (sentenceWitItem?.Length < RowLength)
                            {
                                var sb = new StringBuilder();
                                var isReversed = false;
                                List<string> reversedResult = null;
                                
                                while (sb.Length < RowLength)
                                {
                                    var isLessThanHalf = indexOfSentence <= sentences.Length / 2;
                                    if (!isLessThanHalf)
                                    {
                                        isReversed = true;
                                        reversedResult = reversedResult ?? new List<string>(sentences.Length);
                                    }

                                    if(indexOfSentence == 0)
                                    {
                                        if (isLessThanHalf)
                                        {
                                            sb.Append(sentenceWitItem);
                                            indexOfSentence++;
                                        }
                                        else
                                        {
                                            reversedResult.Add(sentenceWitItem);
                                            indexOfSentence--;
                                        }

                                        continue;
                                    }

                                    if (indexOfSentence != 0 && isLessThanHalf)
                                    {
                                        sb.Append(sentences[indexOfSentence++]);
                                    }

                                    if (indexOfSentence != 0 && !isLessThanHalf)
                                    {
                                        reversedResult.Add(sentences[indexOfSentence--]);
                                    }
                                }

                                if (!isReversed)
                                {
                                    result.Add(sb.ToString());
                                }
                                else
                                {
                                    reversedResult.Reverse();
                                    var reversedSb = new StringBuilder();

                                    foreach (var x in reversedResult)
                                    {
                                        reversedSb.Append(x);
                                    }

                                    result.Add(reversedSb.ToString());
                                }
                            }
                            else
                            {
                                result.Add(sentenceWitItem);
                            } */
                            //result.Add(row.Substring(from, length));
                        }
                    }
                }

                return new SearchResult(result.ToArray());
            }

            return SearchResult.GetEmpty();
        }
    }
}