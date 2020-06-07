using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BelarusContextStandart.Models.LanguageModels.Languages;
using Enum = BelarusContextStandart.Models.LanguageModels.Languages.Enum;

namespace BelarusContextStandart.Models.LanguageModels
{
    public class Language
    {
        public Language(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Language(Guid id, Enum lang)
        {
            Id = id;
            Name = lang.ToString();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}