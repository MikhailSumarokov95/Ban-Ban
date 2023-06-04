using InfimaGames.LowPolyShooterPack;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionShop : MonoBehaviour
{
    public Action OnReplenished;
    [SerializeField] private int price;
    [SerializeField] private MaxAmmunitionWeapon[] _maxAmmunitionWeapon;

    public void BuyAmmunition()
    {
        if (!Money.SpendMoney(price)) return;
        ReplenishAmmunition();
    }

    public void ReplenishAmmunition()
    {
        var ammunitionWeapon = new Dictionary<WeaponBehaviour.Name, int>();
        for (var i = 0; i < _maxAmmunitionWeapon.Length; i++)
            ammunitionWeapon.Add(_maxAmmunitionWeapon[i].NameWeapon, _maxAmmunitionWeapon[i].Count);
        Progress.SetAmmunitionCountAllWeapon(ammunitionWeapon);
        OnReplenished?.Invoke();
    }

    [Serializable]
    private class MaxAmmunitionWeapon
    {
        public WeaponBehaviour.Name NameWeapon;
        public int Count;
    }
}