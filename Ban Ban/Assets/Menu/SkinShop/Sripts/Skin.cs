using System;
using UnityEngine;
using static SkinsShop;

public class Skin: MonoBehaviour
{
    [SerializeField] private string nameSkin;
    public string NameSkin { get { return nameSkin; } }

    [SerializeField] private BuffPower[] buffs;
    public BuffPower[] Buffs { get { return buffs; } }

    [Title(label: "Price")]
    [SerializeField] private bool isFree;
    public bool IsFree { get { return isFree; } }

    [SerializeField] private int priceInMoney;
    public int PriceInMoney { get { return priceInMoney; } }

    [SerializeField] private int priceInYan;
    public int PriceInYan { get { return priceInYan; } }

    [Serializable]
    public class BuffPower
    {
        [SerializeField] private Buff buff;
        public Buff Buff { get { return buff; } }

        [SerializeField] private int power;
        public int Power { get { return power; } }
    }
}
