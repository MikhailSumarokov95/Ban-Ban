using UnityEngine;
using GameScore;
using InfimaGames.LowPolyShooterPack;
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
        //if (!Progress.IsGuideCompleted()) StartGame();
    }

    public void StartSurvivalGame() => SceneManager.LoadScene(3);

    public void StartWaveGame() => SceneManager.LoadScene(2);
}
