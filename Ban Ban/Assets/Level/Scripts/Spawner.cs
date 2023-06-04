using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static List<Life> SpawnEnemies(SpawnBot[] spawnEnemy)
    {
        var enemy = new List<Life>();
        for (var i = 0; i < spawnEnemy.Length; i ++)
        {   
            var countEnemy = spawnEnemy[i].Count;
            for (var j = 0; j < countEnemy; j++)
            {
                var numberSpawnPoint = Random.Range(0, spawnEnemy[i].SpawnPoints.Length);
                var spawnPoint = spawnEnemy[i].SpawnPoints[numberSpawnPoint];
                enemy.Add(Instantiate(spawnEnemy[i].BotPrefs.gameObject, spawnPoint.position, spawnPoint.rotation)
                    .GetComponent<Life>());
            }
        }
        return enemy;
    }

    public static List<GameObject> SpawnObject(SpawnObjParameters spawnObject)
    {
        var obj = new List<GameObject>();
        for (var i = 0; i < spawnObject.Count; i++)
        {
            var numberSpawnPoint = Random.Range(0, spawnObject.SpawnPoints.Length);
            var spawnPoint = spawnObject.SpawnPoints[numberSpawnPoint];
            obj.Add(Instantiate(spawnObject.ObjectPrefs, 
                spawnPoint.position + spawnObject.ObjectPrefs.transform.position, 
                spawnPoint.rotation * spawnObject.ObjectPrefs.transform.rotation));
        }
        return obj;
    }

    [Serializable]
    public class SpawnBot
    {
        public Life BotPrefs;
        public int Count;
        public Transform[] SpawnPoints;
    }

    [Serializable]
    public class SpawnObjParameters
    {
        public GameObject ObjectPrefs;
        public int Count;
        public Transform[] SpawnPoints;
    }
}