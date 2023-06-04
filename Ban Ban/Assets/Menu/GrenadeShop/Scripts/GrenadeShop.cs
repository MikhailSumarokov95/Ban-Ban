using System;
using UnityEngine;
using TMPro;

public class GrenadeShop : MonoBehaviour
{
    public Action OnBought;
    [SerializeField] private TMP_Text currentCountText;
    [SerializeField] private int price;
    [SerializeField] private int maxCount = 10;
    [SerializeField] private GameObject addGrenadeImage;

    private int _currentCount;
    public int CurrentCount
    {
        get
        {
            return _currentCount;
        }
        set
        {
            _currentCount = value;
            if (currentCountText != null)
                currentCountText.text = _currentCount.ToString();
            Progress.SetGrenades(_currentCount);
            OnBought?.Invoke();
        }
    }

    private void OnEnable()
    {
        CurrentCount = Progress.GetGrenades();
    }

    public void BuyOne()
    {
        if (CurrentCount >= maxCount) return;
        if (Money.SpendMoney(price)) CurrentCount++;
    }

    public void BuyFull()
    {
        var priceForMax = (maxCount - CurrentCount) * price;
        if (Money.SpendMoney(priceForMax))
            CurrentCount = maxCount;
    }

    public void TryRewardFull()
    {
        GSConnect.ShowRewardedAd(GSConnect.GrenadesReward);
    }

    public void RewardFull()
    {
        CurrentCount = maxCount;
        addGrenadeImage.SetActive(true);
    }
}