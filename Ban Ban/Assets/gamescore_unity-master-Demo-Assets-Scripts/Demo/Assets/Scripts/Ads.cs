using UnityEngine;
using GameScore;
public class Ads : MonoBehaviour
{
    // Все методы вызываются через UI - Ads
    // All methods are called via UI - Ads

    public void ShowFullscreen()
    {
        GS_Ads.ShowFullscreen();
    }

    public void ShowReward(string idOrTag)
    {
        //Tag COIN
        GS_Ads.ShowRewarded(idOrTag);
    }

    public void ShowPreloader()
    {
        GS_Ads.ShowPreloader();
    }

    public void ShowSticky()
    {
        GS_Ads.ShowSticky();
    }

    public void RefreshSticky()
    {
        GS_Ads.RefreshSticky();
    }

    public void CloseSticky()
    {
        GS_Ads.CloseSticky();
    }
}
