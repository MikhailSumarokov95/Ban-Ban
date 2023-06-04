using UnityEngine;
using TMPro;
using GameScore;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private TMP_Text _rankPosition;

    private void OnEnable()
    {
        GS_Leaderboard.OnLeaderboardFetchPlayer += OnRankRefresh;
    }

    private void OnDisable()
    {
        GS_Leaderboard.OnLeaderboardFetchPlayer -= OnRankRefresh;
    }

    public void OpenTop()
    {
        string OrderBy = "level,vip";

        GS_Leaderboard.Open(OrderBy);
    }

    public void OpenTop10()
    {
        //Top 10 with me
        string OrderBy = "level,gold";

        GS_Leaderboard.Open(OrderBy, Order.DESC, 10, WithMe.first, "rank", "rank,level");
    }

    public void OpenTop25()
    {
        string OrderBy = "gold";

        GS_Leaderboard.Open(OrderBy, Order.DESC, 25, WithMe.none, "level,gold,class,rank", "level,gold,class,rank");
    }

    public void RenderTop5()
    {
        string OrderBy = "level,gold";
        string Tag = "Level - Gold";

        GS_Leaderboard.Fetch(Tag, OrderBy, Order.DESC, 5);
    }

    public void Refresh()
    {
        string OrderBy = "level,gold";
        string Tag = "Level - Gold";

        GS_Leaderboard.FetchPlayerRating(Tag, OrderBy);
    }

    private void OnRankRefresh(string tag, int playerRating)
    {
        _rankPosition.text = playerRating.ToString();
    }

}
