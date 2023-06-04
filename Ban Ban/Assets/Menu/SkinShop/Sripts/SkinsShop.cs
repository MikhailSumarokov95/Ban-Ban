using System;
using TMPro;
using UnityEngine;

public class SkinsShop : MonoBehaviour, IShopPurchase
{
    public enum Buff
    {
        Health,
        Damage,
        Speed
    }

    [SerializeField] private SkinParameters[] skinParameters;

    [Title(label: "Button Text")]
    [SerializeField] private TMP_Text priceMoneyText;
    [SerializeField] private TMP_Text priceYANText;
    [SerializeField] private TMP_Text isBoughtText;
    [SerializeField] private TMP_Text isSelectedText;

    [Title(label: "Buffs")]
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text speedText;
    private int _numberSkin = 0;

    private void Start()
    {
        _numberSkin = FindNumberSkinInSkinParameters(Progress.GetSelectedSkinPlayer());
        ReloadShop();
    }

    public void ScrollSkin(int direction)
    {
        SetActiveBuffParameters(_numberSkin, false);
        SetActiveSkinInModel(_numberSkin, false);
        SetActiveButtonShop(_numberSkin, false);
        _numberSkin = Math.Sign(direction) + _numberSkin;
        _numberSkin = ToxicFamilyGames.Math.SawChart(_numberSkin, 0, skinParameters.Length - 1);
        SetActiveBuffParameters(_numberSkin, true);
        SetActiveSkinInModel(_numberSkin, true);
        SetActiveButtonShop(_numberSkin, true);
    }

    public void BuySkin()
    {
        if (skinParameters[_numberSkin].PriceInMoney > 0)
        {
            if (Money.SpendMoney(skinParameters[_numberSkin].PriceInMoney))
            {
                Progress.SaveBoughtSkinPlayer(skinParameters[_numberSkin].Name);
                ReloadShop();
            }
        }
        else if (skinParameters[_numberSkin].PriceInYan > 0)
        {
            switch (skinParameters[_numberSkin].Name)
            {
                case "Clown":
                    GSConnect.Purchase(GSConnect.PurchaseTag.Clown, this);
                    break;
                case "Chicken":
                    GSConnect.Purchase(GSConnect.PurchaseTag.Chicken, this);
                    break;
                case "Hat":
                    GSConnect.Purchase(GSConnect.PurchaseTag.Hat, this);
                    break;
                case "Tiger":
                    GSConnect.Purchase(GSConnect.PurchaseTag.Tiger, this);
                    break;
            }
        }
    }

    public void RewardPerPurchase()
    {
        Progress.SaveBoughtSkinPlayer(skinParameters[_numberSkin].Name);
        ReloadShop();
    }

    public void SelectSkin()
    {
        Progress.SaveSelectedSkinPlayer(skinParameters[_numberSkin].Name);
        var buffs = new TFG.Generic.Dictionary<Buff, int>();
        foreach (var buff in skinParameters[_numberSkin].Buffs)
            buffs.Add(buff.Buff, buff.Power);
        Progress.SaveSelectedBuffs(buffs);
        ReloadShop();
    }

    private void ReloadShop()
    {
        DisableAllTexts();
        DisableAllSkins();
        SetActiveBuffParameters(_numberSkin, true);
        SetActiveSkinInModel(_numberSkin, true);
        SetActiveButtonShop(_numberSkin, true);
    }

    private void DisableAllTexts()
    {
        priceMoneyText.transform.parent.gameObject.SetActive(false);
        priceYANText.transform.parent.gameObject.SetActive(false);
        isBoughtText.transform.parent.gameObject.SetActive(false);
        isSelectedText.transform.parent.gameObject.SetActive(false);
        healthText.transform.parent.gameObject.SetActive(false);
        damageText.transform.parent.gameObject.SetActive(false);
        speedText.transform.parent.gameObject.SetActive(false);
    }

    private void SetActiveBuffParameters(int number, bool value)
    {
        foreach (var buff in skinParameters[number].Buffs)
        {
            switch (buff.Buff)
            {
                case Buff.Health:
                    healthText.transform.parent.gameObject.SetActive(value);
                    healthText.text = buff.Power.ToString();
                    continue;
                case Buff.Damage:
                    damageText.transform.parent.gameObject.SetActive(value);
                    damageText.text = buff.Power.ToString();
                    continue;
                case Buff.Speed:
                    speedText.transform.parent.gameObject.SetActive(value);
                    speedText.text = buff.Power.ToString();
                    continue;
            }
        }
    }

    private void DisableAllSkins()
    {
        foreach(var parameter in skinParameters)
            parameter.Skin.gameObject.SetActive(false);
    }

    private void SetActiveSkinInModel(int number, bool value) => skinParameters[number].Skin.SetActive(value);

    private void SetActiveButtonShop(int number, bool value)
    {
        if (skinParameters[number].IsFree)
        {
            isBoughtText.transform.parent.gameObject.SetActive(value);
        }
        else if (Progress.IsSelectedSkinPlayer(skinParameters[number].Name))
        {
            isSelectedText.transform.parent.gameObject.SetActive(value);
        }
        else if (Progress.IsBoughtSkinPlayer(skinParameters[number].Name))
        {
            isBoughtText.transform.parent.gameObject.SetActive(value);
        }
        else if (skinParameters[number].PriceInMoney != 0)
        {
            priceMoneyText.transform.parent.gameObject.SetActive(value);
            priceMoneyText.text = skinParameters[number].PriceInMoney.ToString();
        }
        else
        {
            priceYANText.transform.parent.gameObject.SetActive(value);
            priceYANText.text = skinParameters[number].PriceInYan.ToString();
        }
    }

    private int FindNumberSkinInSkinParameters(string nameSkin)
    {
        for (var i = 0; i < skinParameters.Length; i++)
            if (skinParameters[i].Name == nameSkin) return i;
        return 0;
    }

    [Serializable]
    private class SkinParameters
    {
        public string Name;
        public BuffPower[] Buffs;
        public GameObject Skin;

        [Title(label: "Price")]
        public bool IsFree;
        public int PriceInMoney;
        public int PriceInYan;

        [Serializable]
        public class BuffPower
        {
            public Buff Buff;
            public int Power;
        }
    }
}
