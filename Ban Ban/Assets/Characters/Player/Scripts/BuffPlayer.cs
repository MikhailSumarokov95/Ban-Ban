using InfimaGames.LowPolyShooterPack;
using System.Collections.Generic;
using UnityEngine;
using static SkinsShop;

public class BuffPlayer : MonoBehaviour
{
    private void Start()
    {
        var buff = ÑonvertFromTFGDictionaryToSystemDictionary(Progress.GetSelectedBuffs());
        if (buff.ContainsKey(Buff.Health))
        {
            var health = GetComponent<HealthPoints>();
            health.IncreaseMaxHealth(buff[Buff.Health]);
        }
        if (buff.ContainsKey(Buff.Damage))
        {
            GetComponent<Character>().IncreaseDamageByPercentage(buff[Buff.Damage]);
        }
        if (buff.ContainsKey(Buff.Speed))
        {
            GetComponent<Movement>().IncreaseSpeedByPercentage(buff[Buff.Speed]);
        }
    }

    private Dictionary<Buff, int> ÑonvertFromTFGDictionaryToSystemDictionary(TFG.Generic.Dictionary<Buff, int> TFGDictionary)
    {
        var buffs = new Dictionary<Buff, int>();
        for (var i = 0; i < TFGDictionary.keys.Count; i++)
            buffs.Add(TFGDictionary.keys[i], TFGDictionary.values[i]);
        return buffs;
    }
}
