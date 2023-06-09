using UnityEngine;
using GameScore;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Awake()
    {
        if (!Application.isEditor) PlayerPrefs.SetString("selectedLanguage", GS_Language.Current());
        if (!Progress.IsSetDefaultWeapons())
        {
            FindObjectOfType<ShopAttachment>(true).SetDefaultSetting();
            FindObjectOfType<AmmunitionShop>(true).ReplenishAmmunition();
        }
        FindObjectOfType<SkinsShop>(true).Start();
    }

    public void StartSurvivalGame() => SceneManager.LoadScene(3);

    public void StartWaveGame() => SceneManager.LoadScene(2);
}
