using UnityEngine;
using GameScore;
public class Socials : MonoBehaviour
{
    // Все методы вызываются через UI - Socials
    // All methods are called via UI - Socials

    public void Share()
    {
        GS_Socials.Share("Text");
    }

    public void Invite()
    {
        GS_Socials.Invite("Text", "url", "image");
    }

    public void Post()
    {
        GS_Socials.Share("Text", "url", "image");
    }

    public void JoinCommunity()
    {
        GS_Socials.JoinCommunity();
    }
}
