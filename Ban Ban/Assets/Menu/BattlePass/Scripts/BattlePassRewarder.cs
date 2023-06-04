using InfimaGames.LowPolyShooterPack;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BattlePassRewarder : MonoBehaviour, IShopPurchase
{
    [SerializeField] private RewardBattlePass[] _rewardBattlePassPerLevel;
    [SerializeField] private LevelAchievementMark[] levelAchievementMark;

    private void OnEnable()
    {
        EnableLevelAchievementMark();
    }

    public void TryPurchase()
    {
        GSConnect.Purchase(GSConnect.PurchaseTag.Battlepass, this);
    }

    [ContextMenu("BoughtBattlePass")]
    public void RewardPerPurchase()
    {
        Progress.SetBoughtBattlePass();
        for (var i = 1; i < Level.CurrentLevel + 1; i++)
            Reward(_rewardBattlePassPerLevel[i]);
    }

    public void RewardPerLevel()
    {
        var currentLevel = Level.CurrentLevel;
        if (Progress.IsBoughtBattlePass())
            Reward(_rewardBattlePassPerLevel[currentLevel]);
    }

    private void Reward(RewardBattlePass reward)
    {
        if (reward.NameWeapon != null)
            foreach (var weapon in reward.NameWeapon)
                Progress.SetBuyWeapon(weapon);
        if (reward.AmountMoney != 0)
            Money.MakeMoney(reward.AmountMoney);
        if (reward.NumberSkinWeapons != -1)
            foreach(WeaponBehaviour.Name weapon in Enum.GetValues(typeof(WeaponBehaviour.Name)))
                Progress.SetBuySkin(weapon, reward.NumberSkinWeapons);
    }

    private void EnableLevelAchievementMark()
    {
        var currentLevel = Level.CurrentLevel;
        for (var i = 1; i < levelAchievementMark.Length; i++)
        {
            levelAchievementMark[i].CloseImage.gameObject.SetActive(!(i <= currentLevel - 1));
            levelAchievementMark[i].OpenedImage.gameObject.SetActive(i <= currentLevel - 1);
        }
    }

    [Serializable]
    private class RewardBattlePass
    {
        public WeaponBehaviour.Name[] NameWeapon;
        public int AmountMoney;
        public int NumberSkinWeapons = -1;
    }

    [Serializable]
    private class LevelAchievementMark
    {
        public Image CloseImage;
        public Image OpenedImage;
    }
}