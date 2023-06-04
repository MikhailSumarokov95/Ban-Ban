using System.Collections;
using TMPro;
using UnityEngine;

public class GuideLevel : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text text1;
    [SerializeField] private TMP_Text text2;

    private void OnEnable()
    {
        if (Progress.IsGuideCompleted())
        {
            Destroy(gameObject);
            return;
        }
        GameMode.OnSpawnedEnemies += SetChanceLoot;
        GameMode.OnWavesOver += StartText2;
    }
    
    private void OnDisable()
    {
        GameMode.OnSpawnedEnemies -= SetChanceLoot;
        GameMode.OnWavesOver -= StartText2;
    }

    private void Start()
    {
        text.gameObject.SetActive(false);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
    }

    private void SetChanceLoot(Life[] bots)
    {
        bots[^1].GetComponent<Loot>().GetOneHundredPercentChanceLoot();
        StartCoroutine(StartTextAndText1());
    }

    private IEnumerator StartTextAndText1()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        text.gameObject.SetActive(false);
        text1.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        text1.gameObject.SetActive(false);
    }

    private void StartText2()
    {
        text2.gameObject.SetActive(true);
        Progress.SaveGuideCompleted();
    }
}
