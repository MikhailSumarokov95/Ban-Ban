using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] pointsSpawn;

    private void Awake()
    {
        var numberPointSpawn = Random.Range(0, pointsSpawn.Length);

        player.SetPositionAndRotation(pointsSpawn[numberPointSpawn].position,
            pointsSpawn[numberPointSpawn].rotation);
    }
}