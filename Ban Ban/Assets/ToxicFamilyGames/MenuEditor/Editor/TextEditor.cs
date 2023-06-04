using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.UI;
using System.Xml;

namespace ToxicFamilyGames.MenuEditor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Text))]
    public class TextEditor : Editor
    {
        SerializedProperty id;
        private TMPro.TMP_Text tmp;
        private TranslateSettings ts;
        private void OnEnable()
        {
            id = serializedObject.FindProperty("id");
            tmp = ((Text)serializedObject.targetObject).gameObject.GetComponent<TMPro.TMP_Text>();
            ts = Resources.Load<TranslateSettings>("LanguageSettings");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(id);
            if (!ts.FindId(id.stringValue) && GUILayout.Button("ƒÓ·‡‚ËÚ¸ ÌÓ‚˚È id"))
            {
                XmlDocument xmlDoc = ts.GetDocument("ru");
                XmlElement texts = xmlDoc.DocumentElement;
                XmlElement text = xmlDoc.CreateElement("text");
                XmlAttribute idAttribute = xmlDoc.CreateAttribute("id");
                XmlText idText = xmlDoc.CreateTextNode(id.stringValue);
                XmlText innerText;

                if (tmp == null) innerText = xmlDoc.CreateTextNode("Õ≈“«Õ¿◊≈Õ»ﬂ!!!");
                else innerText = xmlDoc.CreateTextNode(tmp.text);

                idAttribute.AppendChild(idText);
                text.AppendChild(innerText);
                text.Attributes.Append(idAttribute);
                texts.AppendChild(text);
                xmlDoc.Save("Assets/ToxicFamilyGames/MenuEditor/Resources/Languages/ru.xml");
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}