using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float timeBetweenSpawns = 0.5f;
    [SerializeField] private float spawnRandomFactor = 0.3f;
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private float moveSpeed = 0.2f;
    private readonly List<Transform> _getWaypoints;

    public GameObject EnemyPrefab => enemyPrefab;
    public float TimeBetweenSpawns => timeBetweenSpawns;
    public float SpawnRandomFactor => spawnRandomFactor;
    public int NumberOfEnemies => numberOfEnemies;
    public float MoveSpeed => moveSpeed;

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        
        foreach (Transform transform in pathPrefab.transform)
        {
            waypoints.Add(transform);
        }

        return waypoints;
    }
}
