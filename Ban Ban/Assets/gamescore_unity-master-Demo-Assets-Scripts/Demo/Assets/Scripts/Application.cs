using UnityEngine;
using TMPro;
using GameScore;

namespace MirraGames
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _desc;
        [SerializeField] private TMP_Text _image;
        [SerializeField] private TMP_Text _url;
#if !UNITY_EDITOR && UNITY_WEBGL
    private void Start()
    {
        ApplicationInit();
    }
#endif
        private void ApplicationInit()
        {
            _title.text = GS_App.Title();
            _desc.text = GS_App.Description();
            _image.text = GS_App.ImageUrl();
            _url.text = GS_App.Url();

            Console.Instance.Log("App Title: " + GS_App.Title());
            Console.Instance.Log("App Description: " + GS_App.Description());
            Console.Instance.Log("App Image: " + GS_App.ImageUrl());
            Console.Instance.Log("App Url: " + GS_App.Url());
        }
    }
}