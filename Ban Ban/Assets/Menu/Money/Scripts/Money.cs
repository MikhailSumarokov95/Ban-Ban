using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;

    public static int AmountOfMoney { get { return Progress.GetMoney(); } set { Progress.SetMoney(value); } }

    private void OnEnable()
    {
        SetTextMoney();
        Progress.OnNewSaveMoney += SetTextMoney;
    }

    private void OnDisable()
    {
        Progress.OnNewSaveMoney -= SetTextMoney;
    }

    public static bool SpendMoney(int value)
    {
        if (AmountOfMoney < value) return false;
        else
        {
            AmountOfMoney -= value;
            return true;
        }
    }

    public static void MakeMoney(int value)
    {
        AmountOfMoney += value;
    }

    public void TryReward()
    {
        GSConnect.ShowRewardedAd(GSConnect.MoneyReward);
    }
    
    public void SetTextMoney()
    {
        moneyText.text = AmountOfMoney.ToString();
    }
}
