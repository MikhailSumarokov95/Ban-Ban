public class SelectorSkin : SelectorAttachment
{ 
    public override void InitAttachment()
    {
        _countAttachment = _weaponAttachmentManager.GetSkinCount();
        _attachmentAbsenteeNumber = 0;
    }

    public override void SetActiveAttachment(int index)
    {
        _weaponAttachmentManager.SetEquippedSkin(index);
    }

    public override void BuyAttachment()
    {
        if (!Money.SpendMoney(cast)) return;
        Progress.SetBuySkin(_shop.CurrentWeaponName, _currentAttachment);
        ScrollThrough(0);
    }

    public override void SelectAttachment()
    {
        Progress.SetSelectSkin(_shop.CurrentWeaponName, _currentAttachment);
        ScrollThrough(0);
    }

    public override bool IsSelectedAttachment(int index)
    {
        return Progress.IsSelectedSkin(_shop.CurrentWeaponName, index);
    }

    public override bool IsBoughtAttachment(int index)
    {
        return Progress.IsBoughtSkin(_shop.CurrentWeaponName, index);
    }

    public override int[] BoughtAttachments()
    {
        return Progress.GetBoughtSkin(_shop.CurrentWeaponName);
    }

    public override int SelectedAttachments()
    {
        return Progress.GetSelectedSkin(_shop.CurrentWeaponName);
    }
}
