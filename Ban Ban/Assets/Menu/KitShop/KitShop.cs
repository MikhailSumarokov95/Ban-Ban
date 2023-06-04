using UnityEngine;
using System;
using InfimaGames.LowPolyShooterPack;
using UnityEngine.UI;
using System.Collections.Generic;

public class KitShop : MonoBehaviour, IShopPurchase
{
    [SerializeField] private GSConnect.PurchaseTag purchaseTag;
    [SerializeField] private Image isNotBoughtButton;
    [SerializeField] private Image isBoughtButton;

    [Title(label: "Reward")]
    [SerializeField] private WeaponBehaviour.Name[] weapons;
    [SerializeField] private ArrayOfNumbers numberSkin;
    [SerializeField] private int amountMoney;
    [SerializeField] private bool battlePass;

    private void OnEnable()
    {
        InitButton();
    }

    public void TryPurchase()
    {
        GSConnect.Purchase(purchaseTag, this);
    }

    public void RewardPerPurchase()
    {
        if (weapons != null)
            foreach (var weapon in weapons)
                Progress.SetBuyWeapon(weapon);
        if (amountMoney != 0)
            Money.MakeMoney(amountMoney);
        if (numberSkin != null)
        {
            var numbersSkin = new List<int>();
            for (var i = numberSkin.FirstNumber; i < numberSkin.LastNumber + 1; i++)
                numbersSkin.Add(i);
            var numbersSkinArray = numbersSkin.ToArray();
            Progress.SetBuySkinsForAllWeapons(numbersSkinArray);
        }
        if (battlePass && !Progress.IsBoughtBattlePass()) FindObjectOfType<BattlePassRewarder>(true).RewardPerPurchase();
        Progress.SetBoughtKit(purchaseTag);
        InitButton();
    }

    private void InitButton()
    {
        if (Progress.IsBoughtKit(purchaseTag))
        {
            isNotBoughtButton.gameObject.SetActive(false);
            isBoughtButton.gameObject.SetActive(true);
        }
        else
        {
            isNotBoughtButton.gameObject.SetActive(true);
            isBoughtButton.gameObject.SetActive(false);
        }        
    }

    [Serializable]
    private class ArrayOfNumbers
    {
        public int FirstNumber;
        public int LastNumber;
    }
}
