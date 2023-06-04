using UnityEngine;
using TMPro;
using GameScore;
public class LanguageContoller : MonoBehaviour
{
    [SerializeField] private TMP_Text _lang;
    [SerializeField] private TMP_Dropdown _langDropdown;

    private string _language;

#if !UNITY_EDITOR && UNITY_WEBGL
    private void Start()
    {
        LanguageInit();
    }
#endif
    private void LanguageInit()
    {
        _language = GS_Language.Current();

        switch (_language)
        {
            case "en":
                Console.Instance.Language("en");
                _lang.text = "EN";
                _langDropdown.value = 0;
                break;

            case "ru":
                Console.Instance.Language("ru");
                _lang.text = "RU";
                _langDropdown.value = 1;
                break;

            case "fr":
                Console.Instance.Language("fr");
                _lang.text = "FR";
                _langDropdown.value = 2;
                break;

            case "it":
                Console.Instance.Language("it");
                _lang.text = "IT";
                _langDropdown.value = 3;
                break;

            case "de":
                Console.Instance.Language("de");
                _lang.text = "DE";
                _langDropdown.value = 4;
                break;

            case "es":
                Console.Instance.Language("es");
                _lang.text = "ES";
                _langDropdown.value = 5;
                break;

            case "zh":
                Console.Instance.Language("zh");
                _lang.text = "ZH";
                _langDropdown.value = 6;
                break;

            case "pt":
                Console.Instance.Language("pt");
                _lang.text = "PT";
                _langDropdown.value = 7;
                break;

            case "ko":
                Console.Instance.Language("ko");
                _lang.text = "KO";
                _langDropdown.value = 8;
                break;

            case "ja":
                Console.Instance.Language("ja");
                _lang.text = "JA";
                _langDropdown.value = 9;
                break;
        }
    }
    public void ChoseLanguage(int languageIndex)
    {
        switch (languageIndex)
        {
            case 0:
                GS_Language.Change(Language.en);
                _lang.text = "EN";
                break;
            case 1:
                GS_Language.Change(Language.ru);
                _lang.text = "RU";
                break;
            case 2:
                GS_Language.Change(Language.fr);
                _lang.text = "FR";
                break;
            case 3:
                GS_Language.Change(Language.it);
                _lang.text = "IT";
                break;

            case 4:
                GS_Language.Change(Language.de);
                _lang.text = "DE";
                break;

            case 5:
                GS_Language.Change(Language.es);
                _lang.text = "ES";
                break;

            case 6:
                GS_Language.Change(Language.zh);
                _lang.text = "ZH";
                break;

            case 7:
                GS_Language.Change(Language.pt);
                _lang.text = "PT";
                break;

            case 8:
                GS_Language.Change(Language.ko);
                _lang.text = "KO";
                break;

            case 9:
                GS_Language.Change(Language.ja);
                _lang.text = "JA";
                break;
        }
    }
}
