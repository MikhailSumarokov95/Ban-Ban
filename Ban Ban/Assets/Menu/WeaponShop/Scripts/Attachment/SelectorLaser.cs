public class SelectorLaser : SelectorAttachment
{
    public override void InitAttachment()
    {
        _countAttachment = _weaponAttachmentManager.GetLaserBehaviourCount();
    }

    public override void SetActiveAttachment(int index)
    {
        _weaponAttachmentManager.SetEquippedLaser(index);
    }

    public override void BuyAttachment()
    {
        if (!Money.SpendMoney(cast)) return;
        Progress.SetBuyLaser(_shop.CurrentWeaponName, _currentAttachment);
        ScrollThrough(0);
    }

    public override void SelectAttachment()
    {
        Progress.SetSelectLaser(_shop.CurrentWeaponName, _currentAttachment);
        ScrollThrough(0);
    }

    public override bool IsSelectedAttachment(int index)
    {
        return Progress.IsSelectedLaser(_shop.CurrentWeaponName, index);
    }

    public override bool IsBoughtAttachment(int index)
    {
        return Progress.IsBoughtLaser(_shop.CurrentWeaponName, index);
    }

    public override int[] BoughtAttachments()
    {
        return Progress.GetBoughtLaser(_shop.CurrentWeaponName);
    }

    public override int SelectedAttachments()
    {
        return Progress.GetSelectedLaser(_shop.CurrentWeaponName);
    }
}