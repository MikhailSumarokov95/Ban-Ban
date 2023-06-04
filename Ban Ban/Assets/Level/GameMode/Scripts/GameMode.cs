using UnityEngine;
using System;
using System.Collections;
using static Spawner;

public abstract class GameMode : MonoBehaviour
{
    public static GameMode Instance;
    public static Action<Life[]> OnSpawnedEnemies;
    public static Action OnWavesOver;
    public static Action OnWaveEnd;
    [Title(label: "Generals")]
    [SerializeField] protected SpawnBot[] spawnBots;
    [SerializeField] protected SpawnBot[] spawnBoss;
    [SerializeField] protected int delayAfterEndWave = 2;
    [SerializeField] protected int countWave = int.MaxValue;
    protected Life[] _currentEnemyLife;
    protected int _countKilledEnemyForWave;
    protected bool _waveEnd;
    public int CountKilledEnemyForWave { get { return _countKilledEnemyForWave; } }

    private int _numberWave = 0;
    public int NumberWave { get { return _numberWave; } protected set { _numberWave = value; } }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    private void Update()
    {
        if (_countKilledEnemyForWave == _currentEnemyLife.Length && !_waveEnd)
        {
            if (NumberWave < countWave) StartCoroutine(WaitAndOnWaveEnd());
            else StartCoroutine(WaitAndOnWavesOver());
            _waveEnd = true;
            UnsubscribeOnKillEventEnemy();
        }
    }

    public abstract void StartNewWave();

    protected abstract void IncrementCountKilled();

    protected void SignOnKillEventEnemy(Life[] enemies)
    {
        _currentEnemyLife = enemies;
        foreach (Life enemy in _currentEnemyLife)
            enemy.OnDid += IncrementCountKilled;
    }

    protected void UnsubscribeOnKillEventEnemy()
    {
        foreach (Life enemy in _currentEnemyLife)
            enemy.OnDid -= IncrementCountKilled;
    }

    private IEnumerator WaitAndOnWaveEnd()
    {
        yield return new WaitForSeconds(delayAfterEndWave);
        OnWaveEnd?.Invoke();
    }

    private IEnumerator WaitAndOnWavesOver()
    {
        yield return new WaitForSeconds(delayAfterEndWave);
        OnWavesOver?.Invoke();
    }
}
