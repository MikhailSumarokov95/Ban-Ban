using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RewardGame : MonoBehaviour
{
    [SerializeField] private int factorMoney = 3;
    [SerializeField] private TMP_Text moneyPerWaveText;
    [SerializeField] private Button doubleRewardButton;
    private int _moneyPerWave;

    private void OnEnable()
    {
        doubleRewardButton.gameObject.SetActive(true);
        CountRewardPerWave(1); 
    }

    public void CountRewardPerWave(int factor)
    {
        _moneyPerWave = GameMode.Instance.CountKilledEnemyForWave * factor * factorMoney;
        moneyPerWaveText.text = _moneyPerWave.ToString();
    }

    public void RewardPerWave()
    {
        Money.MakeMoney(_moneyPerWave);
        _moneyPerWave = 0;
    }

    public void TryRewardDoubleMoney()
    {
        doubleRewardButton.gameObject.SetActive(false);
        GSConnect.ShowRewardedAd(GSConnect.DoubleMoneyReward);
    }
}