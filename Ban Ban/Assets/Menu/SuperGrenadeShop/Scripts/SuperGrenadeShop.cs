using System;
using UnityEngine;
using TMPro;

public class SuperGrenadeShop : MonoBehaviour, IShopPurchase
{
    public Action OnBought;
    [SerializeField] private TMP_Text currentCountText;
    [SerializeField] private GameObject addSuperGrenadeImage;
    [SerializeField] private int countRewardPerPurchase;

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
            Progress.SetSuperGrenades(_currentCount);
            OnBought?.Invoke();
        }
    }

    private void OnEnable()
    {
        CurrentCount = Progress.GetSuperGrenades();
    }

    public void TryPurchase()
    {
        GSConnect.Purchase(GSConnect.PurchaseTag.SuperGrenade, this);
    }

    public void RewardPerPurchase()
    {
        RewardCount(countRewardPerPurchase);
        addSuperGrenadeImage.SetActive(true);
    }

    public void RewardCount(int value)
    {
        CurrentCount += value;
        addSuperGrenadeImage.SetActive(true);
    }
}
