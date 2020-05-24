using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Setting 
{
    public static class Language {
        public static List<string> LanguageList = new List<string>();

        private static int _langIndex = 3;

        public static void nextLang()
        {
            _langIndex++;
            if (_langIndex > LanguageList.Count - 1)
                _langIndex = 0;
        }

        public static void preLang() 
        {
            _langIndex--;
            if (_langIndex < 0)
                _langIndex = LanguageList.Count - 1;
        }

        public static string GetCurrentLanguage() {
            return LanguageList[_langIndex];
        }
    }
}
