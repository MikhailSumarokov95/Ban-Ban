using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Spawner;

public class SurvivalGameMode : GameMode
{
    [Title(label: "Survival")]
    [SerializeField] private SpawnObjParameters spawnMedicineChest;
    [SerializeField] private SpawnObjParameters spawnAmmunition;
    [SerializeField] private int plusEnemyWithWave = 1;
    [SerializeField] private int howManyWavesSpawnBoss = 5;
    [SerializeField] private TMP_Text countKilledEnemyText;
    private int _countKilledEnemy = 0;

    private void Start()
    {
        countKilledEnemyText.text = 0.ToString();
    }

    public override void StartNewWave()
    {
        NumberWave++;
        CountNumberOfBots();
        var enemyLife = new List<Life>();
        enemyLife.AddRange(SpawnEnemies(spawnBots));
        if (NumberWave % howManyWavesSpawnBoss == 0)
            enemyLife.AddRange(SpawnEnemies(spawnBoss));
        var currentEnemyLife = enemyLife.ToArray();
        OnSpawnedEnemies?.Invoke(currentEnemyLife);
        SignOnKillEventEnemy(currentEnemyLife);
        _countKilledEnemyForWave = 0;
        _waveEnd = false;
        SpawnObject(spawnMedicineChest);
        SpawnObject(spawnAmmunition);
    }

    protected override void IncrementCountKilled()
    {
        _countKilledEnemyForWave++;
        _countKilledEnemy++;
        countKilledEnemyText.text = _countKilledEnemy.ToString();
        if (GSConnect.Score < _countKilledEnemy) GSConnect.Score = _countKilledEnemy;
        Progress.SaveIncrementSumKill();
    }

    private SpawnBot[] CountNumberOfBots()
    {
        var bots = spawnBots;
        foreach (var bot in bots)
            bot.Count += plusEnemyWithWave;
        return bots;
    }
}
