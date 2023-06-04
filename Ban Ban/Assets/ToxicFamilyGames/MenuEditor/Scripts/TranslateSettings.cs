using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

namespace ToxicFamilyGames.MenuEditor
{
    public class TranslateSettings : ScriptableObject
    {
        public string SelectedLanguage
        {
            get { return PlayerPrefs.GetString("selectedLanguage", startLanguage); }
            set { PlayerPrefs.SetString("selectedLanguage", value); }
        }
        [SerializeField] private string startLanguage = "ru";
        [SerializeField] private string[] languages = { "ru", "en", "tr" };
        private XmlDocument[] documents;

        private void Init()
        {
            documents = new XmlDocument[languages.Length];
            for (int i = 0; i < languages.Length; i++)
            {
                documents[i] = new XmlDocument();
#if !UNITY_EDITOR
                TextAsset file = Resources.Load<TextAsset>("Languages/" + languages[i]);
                if (file == null)
                {
                    throw new UnityException("‘айл Resources/Languages/" + languages[i] + ".xml не найден!");
                }
                documents[i].LoadXml(file.text);
#else
                documents[i].Load("Assets/ToxicFamilyGames/MenuEditor/Resources/Languages/" + languages[i]+ ".xml");
#endif
            }
        }

        [ContextMenu("SwitchLanguage")]
        public void SwitchLanguage()
        {
            SelectedLanguage = languages[(GetIndex(SelectedLanguage) + 1) % languages.Length];
            Text[] texts = GameObject.FindObjectsOfType<Text>();
            foreach (Text text in texts)
            {
                text.Init();
            }
        }

        public bool FindInnerText(string atributeValue, out string innerText)
        {
            XmlDocument doc = GetDocument();
            XmlElement texts = doc.DocumentElement;
            if (texts != null)
            {
                foreach (XmlElement text in texts)
                {
                    XmlNode id = text.Attributes.GetNamedItem("id");
                    if (id.Value == atributeValue)
                    {
                        innerText = text.InnerText;
                        return true;
                    }
                }
                innerText = "Ќ≈Ќј…ƒ≈Ќќ!!!";
                return false;
            }
            throw new UnityException(SelectedLanguage + ".xml не найден!");
        }

        public bool FindId(string value)
        {
            XmlDocument doc = GetDocument();
            XmlElement texts = doc.DocumentElement;
            if (texts != null)
            {
                foreach (XmlElement text in texts)
                {
                    XmlNode id = text.Attributes.GetNamedItem("id");
                    if (id.Value == value)
                    {
                        return true;
                    }
                }
                return false;
            }
            throw new UnityException(SelectedLanguage + ".xml не найден!");
        }

        private int GetIndex(string lang)
        {
            for (int i = 0; i < languages.Length; i++)
            {
                if (languages[i].Equals(lang))
                    return i;
            }
            Debug.LogError("язык " + lang + " в TranslateSettings не найден!");
            return 0;
        }

        public XmlDocument GetDocument(string lang)
        {
            return GetDocument(GetIndex(lang));
        }

        public XmlDocument GetDocument(int id)
        {
            if (documents == null) Init();
            return documents[id];
        }

        public XmlDocument GetDocument()
        {
            return GetDocument(SelectedLanguage);
        }
    }
}