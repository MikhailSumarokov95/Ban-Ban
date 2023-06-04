using TMPro;
using UnityEngine;
using GameScore;

public class Game : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        GS_Game.OnPause += OnPaused;
        GS_Game.OnResume += OnResumed;
    }

    private void OnDisable()
    {
        GS_Game.OnPause -= OnPaused;
        GS_Game.OnResume -= OnResumed;
    }

    private void OnPaused()
    {
        // Time.TimeScale = 0
        // Audio OFF
        _text.text = "Paused";
    }

    private void OnResumed()
    {
        // Time.TimeScale = 1
        // Audio ON
        _text.text = "Resumed";
    }

}
