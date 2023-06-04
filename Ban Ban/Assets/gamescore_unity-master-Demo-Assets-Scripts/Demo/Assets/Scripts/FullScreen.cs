using UnityEngine;
using GameScore;
public class FullScreen : MonoBehaviour
{
    // Все методы вызываются через UI - Fullscreen
    // All methods are called via UI - Fullscreen

    public void OpenFullscreen()
    {
        GS_Fullscreen.Open();
    }

    public void CloseFullscreen()
    {
        GS_Fullscreen.Close();
    }

    public void ToggleFullscreen()
    {
        GS_Fullscreen.Toggle();
    }
}
