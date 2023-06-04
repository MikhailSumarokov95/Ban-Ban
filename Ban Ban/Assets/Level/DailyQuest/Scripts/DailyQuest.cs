using InfimaGames.LowPolyShooterPack;
using System.Collections.Generic;
using UnityEngine;

public class DailyQuest : MonoBehaviour
{
    public enum Name
    {
        Kill,
        Grenade,
        TimePlaying
    }

    const float ONE_MINUTE = 60;
    public static DailyQuest Instance;
    private CharacterBehaviour _characterBehaviour;
    private static float _timerPlaying;

    [SerializeField] private SerializedDictionary<Name, int> targetValue;
    public SerializedDictionary<Name, int> TargetValue { get { return targetValue; } }

    public static Dictionary<Name, int> DailyProgress { get; private set; } = 
        new Dictionary<Name, int>() { { Name.Kill, 0 }, { Name.Grenade, 0 }, { Name.TimePlaying, 0 } };

    private void OnEnable()
    {
        Progress.OnNewSaveSumKill += IncrementProgressKill;
        _characterBehaviour = ServiceLocator.Current.Get<IGameModeService>().GetPlayerCharacter();
        _characterBehaviour.OnThrowGrenade += IncrementProgressGrenade;
    }

    private void OnDisable()
    {
        Progress.OnNewSaveSumKill -= IncrementProgressKill;
        _characterBehaviour.OnThrowGrenade -= IncrementProgressGrenade;
    }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    private void Start()
    {
        RefreshProgress();
    }

    private void Update()
    {
        if (StateGameManager.StateGame == StateGameManager.State.Game)
            _timerPlaying += Time.deltaTime;
        if (_timerPlaying > ONE_MINUTE)
        {
            IncrementProgressTimePlaying();
            _timerPlaying = 0;
        }
    }

    public void AddTimeDay()
    {
        GSPrefs.SetInt("DayTime", GSPrefs.GetInt("DayTime", 0) + 1);
        GSPrefs.Save();
    }

    private void IncrementProgressKill()
    {
        if (Progress.GetDailyKill() > targetValue[Name.Kill]) return;
        Progress.SaveDailyKill(1);
        DailyProgress[Name.Kill]++;
    } 

    private void IncrementProgressGrenade()
    {
        if (Progress.GetDailyKill() > targetValue[Name.Grenade]) return;
        Progress.SaveDailyGrenade(1);
        DailyProgress[Name.Grenade]++; 
    }
    
    private void IncrementProgressTimePlaying()
    {
        if (Progress.GetDailyKill() > targetValue[Name.TimePlaying]) return;
        Progress.SaveDailyTimePlaying(1);
        DailyProgress[Name.TimePlaying]++; 
    }

    private void RefreshProgress()
    {
        DailyProgress[Name.Kill] = Progress.GetDailyKill();
    }
}
