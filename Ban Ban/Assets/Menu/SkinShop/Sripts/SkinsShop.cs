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

    [SerializeField] private Skin[] skins;

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
        SetActiveBuffSkins(_numberSkin, false);
        SetActiveSkinInModel(_numberSkin, false);
        SetActiveButtonShop(_numberSkin, false);
        _numberSkin = Math.Sign(direction) + _numberSkin;
        _numberSkin = ToxicFamilyGames.Math.SawChart(_numberSkin, 0, skins.Length - 1);
        SetActiveBuffSkins(_numberSkin, true);
        SetActiveSkinInModel(_numberSkin, true);
        SetActiveButtonShop(_numberSkin, true);
    }

    public void BuySkin()
    {
        if (skins[_numberSkin].PriceInMoney > 0)
        {
            if (Money.SpendMoney(skins[_numberSkin].PriceInMoney))
            {
                Progress.SaveBoughtSkinPlayer(skins[_numberSkin].NameSkin);
                ReloadShop();
            }
        }
        else if (skins[_numberSkin].PriceInYan > 0)
        {
            switch (skins[_numberSkin].NameSkin)
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
        Progress.SaveBoughtSkinPlayer(skins[_numberSkin].NameSkin);
        ReloadShop();
    }

    public void SelectSkin()
    {
        Progress.SaveSelectedSkinPlayer(skins[_numberSkin].NameSkin);
        var buffs = new TFG.Generic.Dictionary<Buff, int>();
        foreach (var buff in skins[_numberSkin].Buffs)
            buffs.Add(buff.Buff, buff.Power);
        Progress.SaveSelectedBuffs(buffs);
        ReloadShop();
    }

    private void ReloadShop()
    {
        DisableAllTexts();
        DisableAllSkins();
        SetActiveBuffSkins(_numberSkin, true);
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

    private void SetActiveBuffSkins(int number, bool value)
    {
        foreach (var buff in skins[number].Buffs)
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
        foreach(var skin in skins)
            skin.gameObject.SetActive(false);
    }

    private void SetActiveSkinInModel(int number, bool value) => skins[number].gameObject.SetActive(value);

    private void SetActiveButtonShop(int number, bool value)
    {
        if (skins[number].IsFree)
        {
            isBoughtText.transform.parent.gameObject.SetActive(value);
        }
        else if (Progress.IsSelectedSkinPlayer(skins[number].NameSkin))
        {
            isSelectedText.transform.parent.gameObject.SetActive(value);
        }
        else if (Progress.IsBoughtSkinPlayer(skins[number].NameSkin))
        {
            isBoughtText.transform.parent.gameObject.SetActive(value);
        }
        else if (skins[number].PriceInMoney != 0)
        {
            priceMoneyText.transform.parent.gameObject.SetActive(value);
            priceMoneyText.text = skins[number].PriceInMoney.ToString();
        }
        else
        {
            priceYANText.transform.parent.gameObject.SetActive(value);
            priceYANText.text = skins[number].PriceInYan.ToString();
        }
    }

    private int FindNumberSkinInSkinParameters(string nameSkin)
    {
        for (var i = 0; i < skins.Length; i++)
            if (skins[i].NameSkin == nameSkin) return i;
        return 0;
    }
}
