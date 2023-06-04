public class SelectorMuzzle : SelectorAttachment
{
    public override void InitAttachment()
    {
        _countAttachment = _weaponAttachmentManager.GetMuzzleBehaviourCount();
        _attachmentAbsenteeNumber = 0;
    }

    public override void SetActiveAttachment(int index)
    {
        _weaponAttachmentManager.SetEquippedMuzzle(index);
    }

    public override void BuyAttachment()
    {
        if (!Money.SpendMoney(cast)) return;
        Progress.SetBuyMuzzle(_shop.CurrentWeaponName, _currentAttachment);
        ScrollThrough(0);
    }

    public override void SelectAttachment()
    {
        Progress.SetSelectMuzzle(_shop.CurrentWeaponName, _currentAttachment);
        ScrollThrough(0);
    }

    public override bool IsSelectedAttachment(int index)
    {
        return Progress.IsSelectedMuzzle(_shop.CurrentWeaponName, index);
    }

    public override bool IsBoughtAttachment(int index)
    {
        return Progress.IsBoughtMuzzle(_shop.CurrentWeaponName, index);
    }

    public override int[] BoughtAttachments()
    {
        return Progress.GetBoughtMuzzle(_shop.CurrentWeaponName);
    }

    public override int SelectedAttachments()
    {
        return Progress.GetSelectedMuzzle(_shop.CurrentWeaponName);
    }
}
