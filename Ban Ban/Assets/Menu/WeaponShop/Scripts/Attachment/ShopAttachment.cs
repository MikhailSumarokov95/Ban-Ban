using UnityEngine;
using InfimaGames.LowPolyShooterPack;
using TMPro;

public class ShopAttachment : MonoBehaviour
{
    [SerializeField] private WeaponBehaviour.Name[] defaultWeapons;
    [SerializeField] private Transform weaponsParentTr;
    [SerializeField] private SelectorAttachment[] selectorsAttachment;
    [SerializeField] private TMP_Text damageText;

    private WeaponBehaviour[] _weapons;
    private int _currentWeaponNumber;

    private WeaponBehaviour.Name _currentWeaponName;
    public WeaponBehaviour.Name CurrentWeaponName { get { return _currentWeaponName; } private set { _currentWeaponName = value; } }

    public void StartInitWeapons(WeaponBehaviour.Name name)
    {
        _weapons = weaponsParentTr.GetComponentsInChildren<WeaponBehaviour>(true);

        for (var i = 0; i < _weapons.Length; i++)
        {
            if (_weapons[i].GetName() == name)
            {
                _weapons[i].gameObject.SetActive(true);
                _currentWeaponNumber = i;
            }

            else _weapons[i].gameObject.SetActive(false);
        }

        _currentWeaponName = name;

        InitDamageText();
        SetActiveAttachment(Progress.IsBoughtWeapon(name));
    }
    private void InitDamageText()
    {
        damageText.text = _weapons[_currentWeaponNumber].GetDamageProjectile().ToString();
    }

    private void SetActiveAttachment(bool value)
    {
        if (!value)
        {
            foreach (var selector in selectorsAttachment)
                selector.gameObject.SetActive(false);
        }
        else
        {
            var weaponAttachmentManager = _weapons[_currentWeaponNumber].GetComponent<WeaponAttachmentManager>();
            foreach (var selector in selectorsAttachment)
            {
                selector.gameObject.SetActive(true);
                selector.InitSelectorAttachment(weaponAttachmentManager, this);
            }
        }
    }

    public void SetDefaultSetting()
    {
        var weapons = weaponsParentTr.GetComponentsInChildren<WeaponBehaviour>(true);
        foreach (var weapon in weapons)
        {
            var weaponAttachmentManager = weapon.GetComponent<WeaponAttachmentManager>();
            Progress.SetSelectAttachments(weapon.GetName(), weaponAttachmentManager.GetScopeIndex(), weaponAttachmentManager.GetMuzzleIndex(),
                weaponAttachmentManager.GetLaserIndex(), weaponAttachmentManager.GetGripIndex(), weaponAttachmentManager.GetSkinIndex());
            Progress.SetBuyAttachments(weapon.GetName(), weaponAttachmentManager.GetScopeIndex(), weaponAttachmentManager.GetMuzzleIndex(),
                weaponAttachmentManager.GetLaserIndex(), weaponAttachmentManager.GetGripIndex(), weaponAttachmentManager.GetSkinIndex());
        }
        foreach (var weapon in defaultWeapons)
            Progress.SetBuyWeapon(weapon);
        Progress.SaveSettedDefaultWeapons();
    }
}