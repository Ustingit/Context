using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BelarusContextStandart.Parsers
{
    public class FileParser
    {
        private const string defaultPath = "~/App_Data/TranslationData/";

        public static FileInfo[] GetFiles(string path = defaultPath, string pattern = "*.txt")
        {
            DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(path));

            return dir.GetFiles(pattern);
        }
    }
}