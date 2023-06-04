using GameScore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static InfimaGames.LowPolyShooterPack.WeaponBehaviour;
using static SkinsShop;

public static class Progress
{   //TODO: уйти от повторений
    readonly static string weaponsSelectedTag = nameof(weaponsSelectedTag);
    readonly static string weaponsBoughtTag = nameof(weaponsBoughtTag);
    readonly static string moneyTag = nameof(moneyTag);
    readonly static string levelTag = nameof(levelTag);
    readonly static string battlePassTag = nameof(battlePassTag);
    readonly static string grenadesTag = nameof(grenadesTag);
    readonly static string superGrenadesTag = nameof(superGrenadesTag);
    readonly static string sensitivityTag = nameof(sensitivityTag);
    readonly static string soundVolumeTag = nameof(soundVolumeTag);
    readonly static string musicVolumeTag = nameof(musicVolumeTag);
    readonly static string setDefaultWeaponsTag = nameof(setDefaultWeaponsTag);
    readonly static string shipAssemblyStageTag = nameof(shipAssemblyStageTag);
    readonly static string numberPartsFoundShipTag = nameof(numberPartsFoundShipTag);
    readonly static string kitTag = nameof(kitTag);
    readonly static string guideTag = nameof(guideTag);
    readonly static string sumKillTag = nameof(sumKillTag);
    readonly static string grenadesUsedTag = nameof(grenadesUsedTag);
    readonly static string timePlayingTag = nameof(timePlayingTag);
    readonly static string selectedBuffsTag = nameof(selectedBuffsTag);
    readonly static string skinsBoughtTag = nameof(skinsBoughtTag);
    readonly static string skinsSelectedTag = nameof(skinsSelectedTag);

    public static Action OnNewSaveWeapons;
    public static Action OnNewSaveGrenade;
    public static Action OnNewSaveSuperGrenade;
    public static Action OnNewSaveSensitivity;
    public static Action OnNewSaveMoney;
    public static Action OnNewSaveSumKill;

    private static TFG.Generic.Dictionary<Name, WeaponAttachmentsBought> _weaponsBought;
    private static TFG.Generic.Dictionary<Name, WeaponAttachmentSelected> _weaponSelected;
    private static int _money = -1;
    private static int _level = -1;
    private static int _grenades = -1;
    private static int _superGrenades = -1;
    private static int _sumKill = -1;
    private static int _grenadesUsed = -1;
    private static int _timePlaying = -1;
    private static TFG.Generic.Dictionary<Buff, int> _selectedBuffs;
    private static SkinsPlayerBought _skinsBought;
    private static string _skinSelected;
    private static DailyProgress _dailyKill;
    private static DailyProgress _dailyGrenade;
    private static DailyProgress _dailyTimePlaying;

    public static bool IsBoughtWeapon(Name name)
    {
        var weaponsBought = LoadWeaponsBought();
        return weaponsBought[name].IsBoughtWeapon;
    }

    public static bool IsBoughtScope(Name name, int scopeIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        for (int i = 0; i < weaponsBought[name].ScopeIndex.Count; i++)
            if (weaponsBought[name].ScopeIndex[i] == scopeIndex) return true;
        return false;
    }
    
    public static bool IsBoughtMuzzle(Name name, int muzzleIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        for (int i = 0; i < weaponsBought[name].MuzzleIndex.Count; i++)
            if (weaponsBought[name].MuzzleIndex[i] == muzzleIndex) return true;
        return false;
    } 
    
    public static bool IsBoughtLaser(Name name, int laserIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        for (int i = 0; i < weaponsBought[name].LaserIndex.Count; i++)
            if (weaponsBought[name].LaserIndex[i] == laserIndex) return true;
        return false;
    }  
    
    public static bool IsBoughtGrip(Name name, int gripIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        for (int i = 0; i < weaponsBought[name].GripIndex.Count; i++)
            if (weaponsBought[name].GripIndex[i] == gripIndex) return true;
        return false;
    }

    public static bool IsBoughtSkin(Name name, int skinIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        for (int i = 0; i < weaponsBought[name].SkinIndex.Count; i++)
            if (weaponsBought[name].SkinIndex[i] == skinIndex) return true;
        return false;
    }

    public static int[] GetBoughtScope(Name name)
    {
        var weaponsBought = LoadWeaponsBought();
        return weaponsBought[name].ScopeIndex.ToArray();
    } 
    
    public static int[] GetBoughtMuzzle(Name name)
    {
        var weaponsBought = LoadWeaponsBought();
        return weaponsBought[name].MuzzleIndex.ToArray();
    }   

    public static int[] GetBoughtLaser(Name name)
    {
        var weaponsBought = LoadWeaponsBought();
        return weaponsBought[name].LaserIndex.ToArray();
    }    
    
    public static int[] GetBoughtGrip(Name name)
    {
        var weaponsBought = LoadWeaponsBought();
        return weaponsBought[name].GripIndex.ToArray();
    }    
    
    public static int[] GetBoughtSkin(Name name)
    {
        var weaponsBought = LoadWeaponsBought();
        return weaponsBought[name].SkinIndex.ToArray();
    }

    public static int GetAmmunitionCount(Name name) 
    {
        var weaponsBought = LoadWeaponsBought();
        return weaponsBought[name].AmmunitionSum;
    }

    public static void SetBuyWeapon(Name name)
    {
        var weaponsBought = LoadWeaponsBought();
        weaponsBought[name].IsBoughtWeapon = true;
        SaveWeaponsBought(weaponsBought);
    }

    public static void SetBuyScope(Name name, int scopeIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        if (weaponsBought[name].ScopeIndex.Contains(scopeIndex)) return;
        weaponsBought[name].ScopeIndex.Add(scopeIndex);
        SaveWeaponsBought(weaponsBought);
    }
      
    public static void SetBuyMuzzle(Name name, int muzzleIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        if (weaponsBought[name].MuzzleIndex.Contains(muzzleIndex)) return;
        weaponsBought[name].MuzzleIndex.Add(muzzleIndex);
        SaveWeaponsBought(weaponsBought);
    }
       
    public static void SetBuyLaser(Name name, int laserIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        if (weaponsBought[name].LaserIndex.Contains(laserIndex)) return;
        weaponsBought[name].LaserIndex.Add(laserIndex);
        SaveWeaponsBought(weaponsBought);
    }
      
    public static void SetBuyGrip(Name name, int gripIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        if (weaponsBought[name].GripIndex.Contains(gripIndex)) return;
        weaponsBought[name].GripIndex.Add(gripIndex);
        SaveWeaponsBought(weaponsBought);
    }

    public static void SetBuySkin(Name name, int skinIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        if (weaponsBought[name].SkinIndex.Contains(skinIndex)) return;
        weaponsBought[name].SkinIndex.Add(skinIndex);
        SaveWeaponsBought(weaponsBought);
    }

    public static void SetBuyAttachments(Name name, int scopeIndex, int muzzleIndex, int laserIndex, int gripIndex, int skinIndex)
    {
        var weaponsBought = LoadWeaponsBought();
        if (!weaponsBought[name].ScopeIndex.Contains(scopeIndex)) 
            weaponsBought[name].ScopeIndex.Add(scopeIndex);
        if (!weaponsBought[name].MuzzleIndex.Contains(muzzleIndex)) 
            weaponsBought[name].MuzzleIndex.Add(muzzleIndex);
        if (!weaponsBought[name].LaserIndex.Contains(laserIndex)) 
            weaponsBought[name].LaserIndex.Add(laserIndex);
        if (!weaponsBought[name].GripIndex.Contains(gripIndex)) 
            weaponsBought[name].GripIndex.Add(gripIndex);
        if (!weaponsBought[name].SkinIndex.Contains(skinIndex)) 
            weaponsBought[name].SkinIndex.Add(skinIndex);
        SaveWeaponsBought(weaponsBought);
    }

    public static void SetBuySkinsForAllWeapons(int[] skins)
    {
        var weaponsBought = LoadWeaponsBought();
        foreach (Name weapon in Enum.GetValues(typeof(Name)))
        {
            for (var i = 0; i < skins.Length; i++)
            {
                if (!(weaponsBought[weapon].SkinIndex.Contains(skins[i])))
                {
                    weaponsBought[weapon].SkinIndex.Add(skins[i]);
                }
            }
        }
        SaveWeaponsBought(weaponsBought);
    }

    public static void SetAmmunitionCount(Name name, int ammunitionCount)
    {
        var weaponsBought = LoadWeaponsBought();
        weaponsBought[name].AmmunitionSum = ammunitionCount;
        SaveWeaponsBought(weaponsBought);
    }

    public static void SetAmmunitionCountAllWeapon(Dictionary<Name, int> ammunitionWeapon)
    {
        var weaponsBought = LoadWeaponsBought();
        foreach (var weapon in ammunitionWeapon.Keys)
            weaponsBought[weapon].AmmunitionSum = ammunitionWeapon[weapon];
        SaveWeaponsBought(weaponsBought);
    }

    public static bool IsSelectedScope(Name name, int scopeIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        return weaponsSelected[name].ScopeIndex == scopeIndex;
    }

    public static bool IsSelectedMuzzle(Name name, int muzzleIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        return weaponsSelected[name].MuzzleIndex == muzzleIndex;
    }  
    
    public static bool IsSelectedLaser(Name name, int laserIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        return weaponsSelected[name].LaserIndex == laserIndex;
    }
     
    public static bool IsSelectedGrip(Name name, int gripIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        return weaponsSelected[name].GripIndex == gripIndex;
    }

    public static bool IsSelectedSkin(Name name, int skinIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        return weaponsSelected[name].SkinIndex == skinIndex;
    }

    public static int GetSelectedScope(Name name)
    {
        var weaponsSelected = LoadWeaponsSelected();
        return weaponsSelected[name].ScopeIndex;
    }
    
    public static int GetSelectedMuzzle(Name name)
    {
        var weaponsSelected = LoadWeaponsSelected();
        return weaponsSelected[name].MuzzleIndex;
    }  
    
    public static int GetSelectedLaser(Name name)
    {
        var weaponsSelected = LoadWeaponsSelected();
        return weaponsSelected[name].LaserIndex;
    }

    public static int GetSelectedGrip(Name name)
    {
        var weaponsSelected = LoadWeaponsSelected();
        return weaponsSelected[name].GripIndex;
    }

    public static int GetSelectedSkin(Name name)
    {
        var weaponsSelected = LoadWeaponsSelected();
        return weaponsSelected[name].SkinIndex;
    }

    public static void SetSelectScope(Name name, int scopeIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        weaponsSelected[name].ScopeIndex = scopeIndex;
        SaveWeaponsSelected(weaponsSelected);
    }

    public static void SetSelectMuzzle(Name name, int muzzleIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        weaponsSelected[name].MuzzleIndex = muzzleIndex;
        SaveWeaponsSelected(weaponsSelected);
    }
      
    public static void SetSelectLaser(Name name, int laserIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        weaponsSelected[name].LaserIndex = laserIndex;
        SaveWeaponsSelected(weaponsSelected);
    }
     
    public static void SetSelectGrip(Name name, int gripIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        weaponsSelected[name].GripIndex = gripIndex;
        SaveWeaponsSelected(weaponsSelected);
    }

    public static void SetSelectSkin(Name name, int skinIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        weaponsSelected[name].SkinIndex = skinIndex;
        SaveWeaponsSelected(weaponsSelected);
    }

    public static void SetSelectAttachments(Name name, int scopeIndex, int muzzleIndex, int laserIndex, int gripIndex, int skinIndex)
    {
        var weaponsSelected = LoadWeaponsSelected();
        weaponsSelected[name].ScopeIndex = scopeIndex;
        weaponsSelected[name].MuzzleIndex = muzzleIndex;
        weaponsSelected[name].LaserIndex = laserIndex;
        weaponsSelected[name].GripIndex = gripIndex;
        weaponsSelected[name].SkinIndex = skinIndex;
        SaveWeaponsSelected(weaponsSelected);
    }

    public static void SaveSettedDefaultWeapons()
    {
        GSPrefs.SetInt(setDefaultWeaponsTag, 1);
        GSPrefs.Save();
    }

    public static bool IsSetDefaultWeapons()
    {
        return GSPrefs.GetInt(setDefaultWeaponsTag, 0) == 1;
    }

    public static void SetMoney(int value)
    {
        _money = value;
        GSPrefs.SetInt(moneyTag, value);
        GSPrefs.Save();
        OnNewSaveMoney?.Invoke();
    }

    public static int GetMoney()
    {
        if (_money == -1) _money = GSPrefs.GetInt(moneyTag, 0);
        return _money;
    }

    public static void SetLevel(int value)
    {
        _level = value;
        GSPrefs.SetInt(levelTag, value);
        GSPrefs.Save();
    }

    public static int GetLevel()
    {
        if (_level == -1) _level = GSPrefs.GetInt(levelTag, 1);
        return _level;
    }

    public static void SetBoughtBattlePass()
    {
        GSPrefs.SetInt(battlePassTag, 1);
        GSPrefs.Save();
    }

    public static bool IsBoughtBattlePass()
    {
        return GSPrefs.GetInt(battlePassTag, 0) == 1;
    }

    public static void SetBoughtKit(GSConnect.PurchaseTag purchaseTag)
    {
        GSPrefs.SetInt(KitScrambler(purchaseTag), 1);
        GSPrefs.Save();
    }
    
    public static bool IsBoughtKit(GSConnect.PurchaseTag purchaseTag)
    {
        return GSPrefs.GetInt(KitScrambler(purchaseTag), 0) == 1;
    }

    private static string KitScrambler(GSConnect.PurchaseTag purchaseTag)
    {
        return (kitTag + purchaseTag).ToString();
    }

    public static void SetGrenades(int value)
    {
        _grenades = value;
        GSPrefs.SetInt(grenadesTag, value);
        GSPrefs.Save();
        OnNewSaveGrenade?.Invoke();
    }

    public static int GetGrenades()
    {
        if (_grenades == -1) _grenades = GSPrefs.GetInt(grenadesTag, 0);
        return _grenades;
    }
    
    public static void SetSuperGrenades(int value)
    {
        _superGrenades = value;
        GSPrefs.SetInt(superGrenadesTag, value);
        GSPrefs.Save();
        OnNewSaveSuperGrenade?.Invoke();
    }

    public static int GetSuperGrenades()
    {
        if (_superGrenades == -1) _superGrenades = GSPrefs.GetInt(superGrenadesTag, 1);
        return _superGrenades;
    }

    public static void SetSensitivity(float value)
    {
        PlayerPrefs.SetFloat(sensitivityTag, value);
        OnNewSaveSensitivity?.Invoke();
    }

    public static float GetSensitivity()
    {
        return PlayerPrefs.GetFloat(sensitivityTag, 1);
    }

    public static void SetVolume(float value)
    {
        PlayerPrefs.SetFloat(soundVolumeTag, value);
    }

    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(soundVolumeTag, 1);
    }

    public static void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(musicVolumeTag, value);
    }

    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(musicVolumeTag, 1);
    }

    public static void SetNumberPartsFoundShip(int value)
    {
        GSPrefs.SetInt(numberPartsFoundShipTag, value);
        GSPrefs.Save();
    }

    public static int GetNumberPartsFoundShip()
    {
        return GSPrefs.GetInt(numberPartsFoundShipTag, 0);
    }
    
    public static void SetShipAssemblyStage(int value)
    {
        GSPrefs.SetInt(shipAssemblyStageTag, value);
        GSPrefs.Save();
    }

    public static int GetShipAssemblyStage()
    {
        return GSPrefs.GetInt(shipAssemblyStageTag, 0);
    }

    public static void SaveGuideCompleted()
    {
        GSPrefs.SetInt(guideTag, 1);
        GSPrefs.Save();
    }

    public static bool IsGuideCompleted()
    {
        return GSPrefs.GetInt(guideTag, 0) == 1;
    }

    public static void SaveSumKill(int value)
    {
        _sumKill = value;
        GSPrefs.SetInt(sumKillTag, value);
        GSPrefs.Save();
        OnNewSaveSumKill?.Invoke();
    }

    public static void SaveIncrementSumKill()
    {
        SaveSumKill(GetSumKill() + 1);
    }

    public static int GetSumKill()
    {
        if (_sumKill == -1) _sumKill = GSPrefs.GetInt(sumKillTag, 0);
        return _sumKill;
    }

    public static void SaveGrenadeUsed(int value)
    {
        _grenadesUsed = value;
        GSPrefs.SetInt(grenadesUsedTag, value);
        GSPrefs.Save();
    }

    public static int GetGrenadesUsed()
    {
        if (_grenadesUsed == -1) _grenadesUsed = GSPrefs.GetInt(grenadesUsedTag, 0);
        return _grenadesUsed;
    }
    
    public static void SaveTimePlaying(int value)
    {
        _timePlaying = value;
        GSPrefs.SetInt(timePlayingTag, value);
        GSPrefs.Save();
    }

    public static int GetTimePlaying()
    {
        if (_timePlaying == -1) _timePlaying = GSPrefs.GetInt(timePlayingTag, 0);
        return _timePlaying;
    }

    public static void SaveSelectedBuffs(TFG.Generic.Dictionary<Buff, int> buffs)
    {
        _selectedBuffs = buffs;
        GSPrefs.SetString(selectedBuffsTag, JsonUtility.ToJson(buffs));
        GSPrefs.Save();
    }

    public static TFG.Generic.Dictionary<Buff, int> GetSelectedBuffs()
    {
        _selectedBuffs ??= JsonUtility.FromJson<TFG.Generic.Dictionary<Buff, int>>
            (GSPrefs.GetString(selectedBuffsTag, GetDefaultSelectedBuffsJSON()));
        return _selectedBuffs;
    }

    private static string GetDefaultSelectedBuffsJSON()
    {
        return JsonUtility.ToJson(new TFG.Generic.Dictionary<Buff, int>());
    }

    public static void SaveBoughtSkinPlayer(string nameSkin)
    {
        var skinsBought = GetBoughtSkinsPlayer();
        skinsBought.Add(nameSkin);
        SaveBoughtSkinsPlayer(skinsBought);
    }

    public static bool IsBoughtSkinPlayer(string nameSkin)
    {
        var skinBought = GetBoughtSkinsPlayer();
        foreach (var skin in skinBought)
            if (skin == nameSkin) return true;
        return false;
    }

    public static void SaveBoughtSkinsPlayer(List<string> nameSkins)
    {
        _skinsBought = new SkinsPlayerBought { Name = nameSkins };
        GSPrefs.SetString(skinsBoughtTag, JsonUtility.ToJson(_skinsBought));
        GSPrefs.Save();
    }

    public static List<string> GetBoughtSkinsPlayer()
    {
        _skinsBought ??= JsonUtility.FromJson<SkinsPlayerBought>
            (GSPrefs.GetString(skinsBoughtTag,
            JsonUtility.ToJson(new SkinsPlayerBought { Name = new List<string>() { "empty" } })));
        return _skinsBought.Name;
    }

    public static bool IsSelectedSkinPlayer(string nameSkin)
    {
        return GetSelectedSkinPlayer() == nameSkin;
    }

    public static string GetSelectedSkinPlayer()
    {
        _skinSelected ??= GSPrefs.GetString(skinsSelectedTag, "");
        return _skinSelected;
    }

    public static void SaveSelectedSkinPlayer(string nameSkin)
    {
        _skinSelected = nameSkin;
        GSPrefs.SetString(skinsSelectedTag, nameSkin);
        GSPrefs.Save();
    }

    public static void SaveDailyKill(int value) => SaveDaily(ref _dailyKill, nameof(_dailyKill), value);

    public static int GetDailyKill() => LoadDaily(ref _dailyKill, nameof(_dailyKill)).Progress;
    
    public static void SaveDailyGrenade(int value) => SaveDaily(ref _dailyGrenade, nameof(_dailyGrenade), value);

    public static int GetDailyGrenade() => LoadDaily(ref _dailyGrenade, nameof(_dailyGrenade)).Progress;
    
    public static void SaveDailyTimePlaying(int value) => SaveDaily(ref _dailyTimePlaying, nameof(_dailyTimePlaying), value);

    public static int GetDailyTimePlaying() => LoadDaily(ref _dailyTimePlaying, nameof(_dailyTimePlaying)).Progress;

    private static void SaveWeaponsSelected(TFG.Generic.Dictionary<Name, WeaponAttachmentSelected> weapons)
    {
        _weaponSelected = weapons;
        GSPrefs.SetString(weaponsSelectedTag, JsonUtility.ToJson(weapons));
        GSPrefs.Save();
        OnNewSaveWeapons?.Invoke();
    }

    private static TFG.Generic.Dictionary<Name, WeaponAttachmentSelected> LoadWeaponsSelected()
    {
        _weaponSelected ??= JsonUtility.FromJson<TFG.Generic.Dictionary<Name, WeaponAttachmentSelected>>
                (GSPrefs.GetString(weaponsSelectedTag, GetDefaultWeaponAttachmentSelected()));
        return _weaponSelected;
    }

    private static void SaveWeaponsBought(TFG.Generic.Dictionary<Name, WeaponAttachmentsBought> weapons)
    {
        _weaponsBought = weapons;
        GSPrefs.SetString(weaponsBoughtTag, JsonUtility.ToJson(weapons));
        GSPrefs.Save();
        OnNewSaveWeapons?.Invoke();
    }

    private static TFG.Generic.Dictionary<Name, WeaponAttachmentsBought> LoadWeaponsBought()
    {
        _weaponsBought ??= JsonUtility.FromJson<TFG.Generic.Dictionary<Name, WeaponAttachmentsBought>>
            (GSPrefs.GetString(weaponsBoughtTag, GetDefaultWeaponAttachmentsBought()));
        return _weaponsBought;
    }

    private static string GetDefaultWeaponAttachmentSelected()
    {
        var dict = new TFG.Generic.Dictionary<Name, WeaponAttachmentSelected>();
        foreach (Name name in Enum.GetValues(typeof(Name)))
        {
            dict.Add(name, new WeaponAttachmentSelected());
        }
        return JsonUtility.ToJson(dict);
    } 
    
    private static string GetDefaultWeaponAttachmentsBought()
    {
        var dict = new TFG.Generic.Dictionary<Name, WeaponAttachmentsBought>();
        foreach (Name name in Enum.GetValues(typeof(Name)))
        {
            dict.Add(name, new WeaponAttachmentsBought()
            {
                ScopeIndex = new List<int>(),
                MuzzleIndex = new List<int>(),
                LaserIndex = new List<int>(),
                GripIndex = new List<int>(),
                SkinIndex = new List<int>(),
            });
        }
        return JsonUtility.ToJson(dict);
    }

    private static void SaveDaily(ref DailyProgress dailyProgress, string tagForSave, int value)
    {
        if (dailyProgress == null)
        {
            var daily = LoadDaily(ref dailyProgress, tagForSave);
            var dayTime = GS_Server.Time().DayOfYear;
            if (daily.DayOfYear == dayTime)
            {
                daily.Progress += value;
                dailyProgress = daily;
            }
            else
            {
                daily.Progress = value;
                daily.DayOfYear = dayTime;
                dailyProgress = daily;
            }
        }
        else
        {
            dailyProgress.Progress += value;
        }
        GSPrefs.SetString(tagForSave, JsonUtility.ToJson(dailyProgress));
        GSPrefs.Save();
    }
    private static DailyProgress LoadDaily(ref DailyProgress dailyProgress, string tagForSave)
    {
        if (dailyProgress == null)
        {
            dailyProgress = JsonUtility.FromJson<DailyProgress>(GSPrefs.GetString(tagForSave, GetDefaultDailyQuestJSON()));
            var dayTime = GS_Server.Time().DayOfYear;
            if (dailyProgress.DayOfYear != dayTime)
            {
                dailyProgress.Progress = 0;
                dailyProgress.DayOfYear = dayTime;
            }
        }
        return dailyProgress;
    }

    private static string GetDefaultDailyQuestJSON()
    {
        return JsonUtility.ToJson(new DailyProgress() { DayOfYear = GS_Server.Time().DayOfYear, Progress = 0 });
    }

    [Serializable]
    private class WeaponAttachmentSelected
    {
        public int ScopeIndex;
        public int MuzzleIndex;
        public int LaserIndex;
        public int GripIndex;
        public int SkinIndex;
    }

    [Serializable]
    private class WeaponAttachmentsBought
    {
        public bool IsBoughtWeapon;
        public List<int> ScopeIndex;
        public List<int> MuzzleIndex;
        public List<int> LaserIndex;
        public List<int> GripIndex;
        public List<int> SkinIndex;
        public int AmmunitionSum;
    }

    [Serializable]
    private class SkinsPlayerBought
    {
        public List<string> Name;
    }

    private class DailyProgress
    {
        public int Progress;
        public int DayOfYear;
    }
}