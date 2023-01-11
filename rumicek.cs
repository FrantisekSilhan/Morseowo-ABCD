using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morseovka
{
    internal class rumicek
    {
        private Dictionary<string, string> _morseCodeDictionary = new Dictionary<string, string>
        {
            {"A", ".-"}, {"B", "-..."}, {"C", "-.-."}, {"D", "-.."}, {"E", "."},
            {"F", "..-."}, {"G", "--."}, {"H", "...."}, {"CH", "----"}, {"I", ".."}, {"J", ".---"},
            {"K", "-.-"}, {"L", ".-.."}, {"M", "--"}, {"N", "-."}, {"O", "---"},
            {"P", ".--."}, {"Q", "--.-"}, {"R", ".-."}, {"S", "..."}, {"T", "-"},
            {"U", "..-"}, {"V", "...-"}, {"W", ".--"}, {"X", "-..-"}, {"Y", "-.--"},
            {"Z", "--.."},
            {"0", "-----"}, {"1", ".----"}, {"2", "..---"}, {"3", "...--"},
            {"4", "....-"}, {"5", "....."}, {"6", "-...."}, {"7", "--..."},
            {"8", "---.."}, {"9", "----."},
            {".", ".-.-.-"}, {",", "--..--"}, {"?", "..--.."}, {"!", "-.-.--"},
            {"/", "-..-."}, {"(", "-.--."}, {")", "-.--.-"}, {"&", ".-..."},
            {":", "---..."}, {";", "-.-.-."}, {"=", "-...-"}, {"+", ".-.-."},
            {"-", "-....-"}, {"_", "..--.-"}, {"$", "...-..-"},
            {"@", ".--.-."}, {" ", ""}, {"", " "}
        };

        private Dictionary<string, string> reversedDictionary => _morseCodeDictionary.ToDictionary(x => x.Value, x => x.Key);

        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
        public string Encode(string text)
        {
            string oktext = RemoveDiacritics(text);
            string result = "";
            bool idkcodelam = false;
            for (int i = 0; i < oktext.Length; i++)
            {
                if (idkcodelam)
                {
                    idkcodelam = false;
                } else
                {
                    try
                    {
                        if (oktext[i].ToString().ToUpper() == "C" && oktext[i + 1].ToString().ToUpper() == "H")
                        {
                            result += _morseCodeDictionary["CH"] + "/";
                            idkcodelam = true;
                        }
                        else
                        {
                            result += _morseCodeDictionary[oktext[i].ToString().ToUpper()] + "/";
                        }
                    }
                    catch
                    {
                        result += _morseCodeDictionary[oktext[i].ToString().ToUpper()] + "/";
                    }
                }
            }
            return result;
        }

        public string Decode(string text)
        {
;           string result = "";

            string[] oktext = text.Split("/");

            foreach (var i in oktext)
            {
                result += reversedDictionary[i];
            }

            return result;
        }
    }
}
