using GameScore;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    public static AchievementsManager Instance;
    const float ONE_MINUTE = 60;
    private static readonly string killTag = "kill";
    private static readonly string timePlayingTag = "timePlaying";
    private static readonly string grenadeUsingTag = "grenadeUsing";
    private static float _timerPlaying;
    private static CharacterBehaviour _characterBehaviour;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    private void OnEnable()
    {
        Progress.OnNewSaveSumKill += UnlockAchievementsForKill;
        _characterBehaviour = ServiceLocator.Current.Get<IGameModeService>().GetPlayerCharacter();
        _characterBehaviour.OnThrowGrenade += SetIncrementProgressGrenadeUsing;
    }

    private  void OnDisable()
    {
        Progress.OnNewSaveSumKill -= UnlockAchievementsForKill;
        _characterBehaviour.OnThrowGrenade -= SetIncrementProgressGrenadeUsing;
    }

    private void Update()
    {
        if (StateGameManager.StateGame == StateGameManager.State.Game) 
            _timerPlaying += Time.deltaTime;
        if (_timerPlaying > ONE_MINUTE)
        {
            SetProgressTimePlaying(1);
            _timerPlaying = 0;
        }
    }

    public static void OpenAchievementsTable()
    {
        if (Application.isEditor) print("OpenedAchievementsTable");
        else GS_Achievements.Open();
    }

    public static void SetProgressAchievements(string tag, int value)
    {
        if (Application.isEditor) print("SetProgressAchievements: tag - " + tag + ", value - " + value);
        else GS_Achievements.SetProgress(tag, value);
    }

    public static void UnlockAchievements(string tag)
    {
        if (Application.isEditor) print("UnlockAchievements: tag - " + tag);
        else GS_Achievements.Unlock(tag);
    }

    private static void UnlockAchievementsForKill()
    {
        switch (Progress.GetSumKill())
        {
            case 10:
                UnlockAchievements(killTag + 10);
                break;
            case 50:
                UnlockAchievements(killTag + 50);
                break;
            case 100:
                UnlockAchievements(killTag + 100);
                break; 
            case 500:
                UnlockAchievements(killTag + 500);
                break; 
            case 1000:
                UnlockAchievements(killTag + 1000);
                break;
        }
    }

    private static void SetProgressTimePlaying(int value)
    {
        var time = Progress.GetTimePlaying() + value;
        SetProgressAchievements(timePlayingTag + 10, time);
        SetProgressAchievements(timePlayingTag + 30, time);
        SetProgressAchievements(timePlayingTag + 60, time);
        SetProgressAchievements(timePlayingTag + 300, time);
        Progress.SaveTimePlaying(time);
    }

    private static void SetIncrementProgressGrenadeUsing()
    {
        var count = Progress.GetGrenadesUsed() + 1;
        SetProgressAchievements(grenadeUsingTag + 10, count);
        SetProgressAchievements(grenadeUsingTag + 100, count);
        SetProgressAchievements(grenadeUsingTag + 500, count);
        Progress.SaveGrenadeUsed(count);
    }
}
