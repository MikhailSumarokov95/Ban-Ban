using UnityEngine;
using GameScore;

public class AchievementsButton : MonoBehaviour
{
    // Все эти методы вызываются через UI - Achievements
    // All this methods are called via UI - Achievements
    public void AchievementsOpen()
    {
        AchievementsManager.OpenAchievementsTable();
    }

    //public void AchievementsFetch()
    //{
    //    GS_Achievements.Fetch();
    //}

    //public void AchievementsUnlock(string idOrTag)
    //{
    //    // Tag - COINS
    //    GS_Achievements.Unlock(idOrTag);
    //}

    //public void AchievementSetProgress()
    //{ 
    //}
}
