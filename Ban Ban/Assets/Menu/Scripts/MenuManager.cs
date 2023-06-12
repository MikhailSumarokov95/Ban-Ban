using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Awake()
    {
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
