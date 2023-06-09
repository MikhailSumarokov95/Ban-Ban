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

    [SerializeField] private Transform parentSkins;

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
    private Skin[] _skins;

    public void Start()
    {
        _skins = parentSkins.GetComponentsInChildren<Skin>(true);
        _numberSkin = FindNumberSkinInSkinParameters(Progress.GetSelectedSkinPlayer());
        ReloadShop();
    }

    public void ScrollSkin(int direction)
    {
        SetActiveBuffSkins(_numberSkin, false);
        SetActiveSkinInModel(_numberSkin, false);
        SetActiveButtonShop(_numberSkin, false);
        _numberSkin = Math.Sign(direction) + _numberSkin;
        _numberSkin = ToxicFamilyGames.Math.SawChart(_numberSkin, 0, _skins.Length - 1);
        SetActiveBuffSkins(_numberSkin, true);
        SetActiveSkinInModel(_numberSkin, true);
        SetActiveButtonShop(_numberSkin, true);
    }

    public void BuySkin()
    {
        if (_skins[_numberSkin].PriceInMoney > 0)
        {
            if (Money.SpendMoney(_skins[_numberSkin].PriceInMoney))
            {
                Progress.SaveBoughtSkinPlayer(_skins[_numberSkin].NameSkin);
                ReloadShop();
            }
        }
        else if (_skins[_numberSkin].PriceInYan > 0)
        {
            switch (_skins[_numberSkin].NameSkin)
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
        Progress.SaveBoughtSkinPlayer(_skins[_numberSkin].NameSkin);
        ReloadShop();
    }

    public void SelectSkin()
    {
        Progress.SaveSelectedSkinPlayer(_skins[_numberSkin].NameSkin);
        var buffs = new TFG.Generic.Dictionary<Buff, int>();
        foreach (var buff in _skins[_numberSkin].Buffs)
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
        foreach (var buff in _skins[number].Buffs)
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
        foreach(var skin in _skins)
            skin.gameObject.SetActive(false);
    }

    private void SetActiveSkinInModel(int number, bool value) => _skins[number].gameObject.SetActive(value);

    private void SetActiveButtonShop(int number, bool value)
    {
        if (_skins[number].IsFree)
        {
            isBoughtText.transform.parent.gameObject.SetActive(value);
        }
        else if (Progress.IsSelectedSkinPlayer(_skins[number].NameSkin))
        {
            isSelectedText.transform.parent.gameObject.SetActive(value);
        }
        else if (Progress.IsBoughtSkinPlayer(_skins[number].NameSkin))
        {
            isBoughtText.transform.parent.gameObject.SetActive(value);
        }
        else if (_skins[number].PriceInMoney != 0)
        {
            priceMoneyText.transform.parent.gameObject.SetActive(value);
            priceMoneyText.text = _skins[number].PriceInMoney.ToString();
        }
        else
        {
            priceYANText.transform.parent.gameObject.SetActive(value);
            priceYANText.text = _skins[number].PriceInYan.ToString();
        }
    }

    private int FindNumberSkinInSkinParameters(string nameSkin)
    {
        for (var i = 0; i < _skins.Length; i++)
            if (_skins[i].NameSkin == nameSkin) return i;
        return 0;
    }
}
