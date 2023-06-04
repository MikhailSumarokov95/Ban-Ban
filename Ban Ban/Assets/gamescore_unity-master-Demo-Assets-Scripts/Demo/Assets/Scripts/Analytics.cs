using UnityEngine;
using GameScore;
public class Analytics : MonoBehaviour
{
    // Все методы вызываются через UI - Analytics
    // All methods are called via UI - Analytics
    public void Hit()
    {
        GS_Analytics.Hit("/example - url");
    }
    public void Goal()
    {
        GS_Analytics.Goal("Level", "5");
    }
}
