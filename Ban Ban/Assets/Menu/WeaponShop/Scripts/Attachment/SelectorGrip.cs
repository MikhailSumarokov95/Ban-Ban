public class SelectorGrip : SelectorAttachment
{
    public override void InitAttachment()
    {
        _countAttachment = _weaponAttachmentManager.GetGripBehaviourCount();
    }

    public override void SetActiveAttachment(int index)
    {
        _weaponAttachmentManager.SetEquippedGrip(index);
    }

    public override void BuyAttachment()
    {
        if (!Money.SpendMoney(cast)) return;
        Progress.SetBuyGrip(_shop.CurrentWeaponName, _currentAttachment);
        ScrollThrough(0);
    }

    public override void SelectAttachment()
    {
        Progress.SetSelectGrip(_shop.CurrentWeaponName, _currentAttachment);
        ScrollThrough(0);
    }

    public override bool IsSelectedAttachment(int index)
    {
        return Progress.IsSelectedGrip(_shop.CurrentWeaponName, index);
    }

    public override bool IsBoughtAttachment(int index)
    {
        return Progress.IsBoughtGrip(_shop.CurrentWeaponName, index);
    }

    public override int[] BoughtAttachments()
    {
        return Progress.GetBoughtGrip(_shop.CurrentWeaponName);
    }

    public override int SelectedAttachments()
    {
        return Progress.GetSelectedGrip(_shop.CurrentWeaponName);
    }
}