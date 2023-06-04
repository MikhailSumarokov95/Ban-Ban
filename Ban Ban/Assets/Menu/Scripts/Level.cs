using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField] private TMP_Text currentLevelText;

    public static int CurrentLevel { get { return Progress.GetLevel(); } set { Progress.SetLevel(value); } }

    private void Start()
    {
        if (currentLevelText != null) 
            currentLevelText.text = CurrentLevel.ToString();
    }

    [ContextMenu("NextLevel")]
    public static void NextLevel()
    {
        CurrentLevel++;
    }
}
