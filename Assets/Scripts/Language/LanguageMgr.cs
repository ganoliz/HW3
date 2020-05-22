using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageMgr : MonoBehaviour
{
    private static LanguageMgr instance = null;
    public static LanguageMgr Instance {
        get { return instance; }
    }

    [SerializeField] private SystemLanguage language;

    private Dictionary<string, Dictionary<string, string>> LanguageDict = new Dictionary<string, Dictionary<string, string>>();

    private void Awake()
    {
        instance = this;
        loadAllLanguages();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Setting.Language.nextLang();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Setting.Language.preLang();
        }
    }

    private void loadAllLanguages()
    {
        string path = "Language/";
        TextAsset[] TAs = Resources.LoadAll<TextAsset>(path);

        for (int i = 0; i < TAs.Length; i++)
        {
            LanguageDict.Add(TAs[i].name, loadLanguage(TAs[i]));
            Setting.Language.LanguageList.Add(TAs[i].name);
        }
    }

    private Dictionary<string, string> loadLanguage(TextAsset ta) {
        Dictionary<string, string> Dict = new Dictionary<string, string>();

        if (ta == null)
        {
            Debug.Log("no language text");
            return null;
        }
        string[] lines = ta.text.Split('\n');
        for(int i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
                continue;
            string[] kv = lines[i].Split(':');
            Dict.Add(kv[0], kv[1]);
//            Debug.Log(string.Format("key:{0}, value:{1}", kv[0], kv[1]));
        }
        return Dict;
    }

    public string GetText(string key)
    {
        string lang = Setting.Language.GetCurrentLanguage();
        if (LanguageDict.ContainsKey(lang))
        {
            Dictionary<string, string> tempDict = LanguageDict[lang];
            if (tempDict.ContainsKey(key))
                return tempDict[key];
            else
                return string.Empty;
        }
        else
        {
            return string.Empty;
        }
    }
}
