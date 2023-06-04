using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml;

namespace ToxicFamilyGames.MenuEditor
{
    public class Text : MonoBehaviour
    {
        [SerializeField]
        public string id;
        private string text;
        private TMPro.TMP_Text tmp;
        private TranslateSettings settings;

        private void Awake()
        {
            if (id.Equals("")) id = gameObject.name;
            tmp = GetComponent<TMP_Text>();
            settings = Resources.Load<TranslateSettings>("LanguageSettings");
        }

        private void OnEnable()
        {
            Init();
        }

        private string value = "";
        public void SetValue<T>(T value)
        {
            ReloadText();
            this.value = value.ToString();
            tmp.text = string.Format(tmp.text, this.value);
        }

        public void ReloadText()
        {
            tmp.text = text;
        }
        public void Init()
        {
            if (settings.FindInnerText(id, out text))
            {
                SetValue(value);
                return;
            }
            throw new UnityException("Перевод " + id + " в файле " + settings.SelectedLanguage + ".xml не найден!");
        }

        
    }
}