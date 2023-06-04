using UnityEngine;
using UnityEngine.UI;
using InfimaGames.LowPolyShooterPack;
using TMPro;
using System.Collections.Generic;
using System;

public abstract class SelectorAttachment : MonoBehaviour
{
    [SerializeField] protected int cast;
    [SerializeField] private Button buyButton;
    [SerializeField] protected TMP_Text buyText;
    [SerializeField] private Button selectButton;
    [SerializeField] private Image selectedButton;
    protected int _currentAttachment;
    protected ShopAttachment _shop;
    protected WeaponAttachmentManager _weaponAttachmentManager;
    protected int _countAttachment;
    protected int _numberAttachment;
    protected int _attachmentAbsenteeNumber = -1;
    protected int[] _attachmentNumberSorted;

    public void InitSelectorAttachment(WeaponAttachmentManager weaponAttachmentManager, ShopAttachment shop)
    {
        _shop = shop;
        _weaponAttachmentManager = weaponAttachmentManager;
        InitAttachment();
        SortAttachment();
        SetNumberAttachment(0);
    }

    public void ScrollThrough(int direction)
    {
        _numberAttachment = Math.Sign(direction) + _numberAttachment;
        _numberAttachment = ToxicFamilyGames.Math.SawChart(_numberAttachment, 0, _attachmentNumberSorted.Length - 1);
        _currentAttachment = _attachmentNumberSorted[_numberAttachment];
        SetActiveAttachment(_currentAttachment);
        InitButton(_currentAttachment);
    }

    public void SetNumberAttachment(int number)
    {
        _numberAttachment = number;
        ScrollThrough(0);
    }

    public abstract void SetActiveAttachment(int index);
    public abstract void InitAttachment();
    public abstract void BuyAttachment();
    public abstract void SelectAttachment();
    public abstract bool IsSelectedAttachment(int index);
    public abstract bool IsBoughtAttachment(int index);
    public abstract int[] BoughtAttachments();
    public abstract int SelectedAttachments();

    private void InitButton(int attachment)
    {
        buyButton.gameObject.SetActive(false);
        selectButton.gameObject.SetActive(false);
        selectedButton.gameObject.SetActive(false);
        if (IsSelectedAttachment(attachment))
        {
            selectedButton.gameObject.SetActive(true);
        }
        else if (IsBoughtAttachment(attachment))
        {
            selectButton.gameObject.SetActive(true);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyText.text = cast.ToString();
        }
    }

    private void SortAttachment()
    {
        var listSelectedAndBoughtAttachment = new List<int>() { SelectedAttachments() };
        var boughtAttachments = BoughtAttachments();
        foreach (var attachment in boughtAttachments)
        {
            if (!listSelectedAndBoughtAttachment.Contains(attachment))
            {
                listSelectedAndBoughtAttachment.Add(attachment);
            }
        }
        var attachmentNumberSorted = new List<int>();
        attachmentNumberSorted.AddRange(listSelectedAndBoughtAttachment);
        for (var i = 0; i < _countAttachment; i++)
        {
            if (listSelectedAndBoughtAttachment.Contains(i)) continue;
            attachmentNumberSorted.Add(i);
        }
        if (!listSelectedAndBoughtAttachment.Contains(_attachmentAbsenteeNumber))
        {
            listSelectedAndBoughtAttachment.Add(_attachmentAbsenteeNumber);
        }
        _attachmentNumberSorted = attachmentNumberSorted.ToArray();
    }
}