using System.Collections.Generic;
using UnityEngine;
using static Spawner;

public class WaveGameMode : GameMode
{
    [Title(label: "Wave")]
    [SerializeField] private float plusEnemyWithLevel = 1;
    [SerializeField] private int howManyLevelsSpawnBoss = 5;

    private void Start()
    {
        CountNumberOfBots();
    }

    public override void StartNewWave()
    {
        NumberWave++;
        var enemyLife = new List<Life>();
        enemyLife.AddRange(SpawnEnemies(spawnBots));
        if (Level.CurrentLevel % howManyLevelsSpawnBoss == 0 && countWave == NumberWave)
            enemyLife.AddRange(SpawnEnemies(spawnBoss));
        var currentEnemyLife = enemyLife.ToArray();
        OnSpawnedEnemies?.Invoke(currentEnemyLife);
        SignOnKillEventEnemy(currentEnemyLife);
        _countKilledEnemyForWave = 0;
        _waveEnd = false;
    }

    protected override void IncrementCountKilled()
    {
        _countKilledEnemyForWave++;
        Progress.SaveIncrementSumKill();
    }

    private SpawnBot[] CountNumberOfBots()
    {
        var bots = spawnBots;
        foreach (var bot in bots) 
            bot.Count += (int)(plusEnemyWithLevel * Level.CurrentLevel);
        return bots;
    }
}
