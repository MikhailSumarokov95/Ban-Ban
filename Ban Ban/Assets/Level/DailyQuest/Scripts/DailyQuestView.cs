using TMPro;
using UnityEngine;
using static DailyQuest;

public class DailyQuestView : MonoBehaviour
{
    [SerializeField] private Name nameQuest; 
    [SerializeField] private TMP_Text textProgress;
    [SerializeField] private TMP_Text textTargetProgress;
    [SerializeField] private TMP_Text textCompleted;

    private void OnEnable()
    {
        if (DailyProgress[nameQuest] >= Instance.TargetValue[nameQuest])
        {
            textCompleted.transform.parent.gameObject.SetActive(true);
            textProgress.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            textCompleted.transform.parent.gameObject.SetActive(false);
            textProgress.transform.parent.gameObject.SetActive(true);
            textProgress.text = DailyProgress[nameQuest].ToString();
        }
    }

    private void Awake()
    {
        textTargetProgress.text = "/" + Instance.TargetValue[nameQuest];
    }
}
