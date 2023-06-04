using TMPro;
using UnityEngine;
using GameScore;
public class LeaderboardScoped : MonoBehaviour
{
    [SerializeField] private TMP_Text _rating;
    [SerializeField] private TMP_InputField _variantInputField;
    [SerializeField] private TMP_InputField _levelInputField;
    [SerializeField] private TMP_InputField _expInputField;
    private string _variant = "level_20";
    private int _level;
    private int _exp;


    private void OnEnable()
    {
        GS_LeaderboardScoped.OnFetchPlayerRating += OnPlayerRating;
    }
    private void OnDisable()
    {
        GS_LeaderboardScoped.OnFetchPlayerRating -= OnPlayerRating;
    }

#if !UNITY_EDITOR && UNITY_WEBGL
    private void Start()
    {
        GS_LeaderboardScoped.FetchPlayerRating("LEVEL", _variant);
    }
#endif

    private void OnPlayerRating(string tag, int value)
    {
        _rating.text = value.ToString();
    }


    public void OpenTop()
    {
        GS_LeaderboardScoped.Open("Leaderboard_idOrTag", _variant);
    }

    public void PublishScore()
    {
        GS_LeaderboardScoped.PublishRecord("Leaderboard_idOrTag", _variant, true, "key_level", _level, "key_exp", _exp);
    }

    public void OnValueChangedVariant(string variant)
    {
        _variant = _variantInputField.text;
    }

    public void OnValueChangedLevel(int score)
    {
        var tempLevel = _levelInputField.text;
        _level = int.Parse(tempLevel);
    }

    public void OnValueChangedExp(int exp)
    {
        var tempExp = _expInputField.text;
        _exp = int.Parse(tempExp);
    }
}
