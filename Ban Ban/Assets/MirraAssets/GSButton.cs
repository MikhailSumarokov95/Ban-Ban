using GameScore;
using UnityEngine;

public class GSButton : MonoBehaviour
{
    public void ShowMidgameAd() =>
        GSConnect.ShowMidgameAd();

    public void ShowRewardedAd(string reward) =>
        GSConnect.ShowRewardedAd(reward);

    //public void Purchase(PurchaseTag tag) =>
    //    GSConnect.Purchase(tag);

    public void OpenLeaderboard() =>
        GS_Leaderboard.Open(withMe: WithMe.first);

    public void OpenCollection(string tag) =>
        GS_GamesCollections.Open(tag);

    public void ShareGame() =>
        GS_Socials.Share();
}