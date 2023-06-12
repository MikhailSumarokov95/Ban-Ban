using GameScore;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GSLoader : MonoBehaviour {

    void Start() {
        StartCoroutine(WaitSDK());
    }

    IEnumerator WaitSDK() {
        if (!Application.isEditor) {
            while (!GSConnect.ProductsReady) {
                yield return null;
            }
        }
        //yield return new WaitForSeconds(1.0f);
        SceneManager.LoadSceneAsync(1);
        if (!Application.isEditor) PlayerPrefs.SetString("selectedLanguage", GS_Language.Current());
    }
}