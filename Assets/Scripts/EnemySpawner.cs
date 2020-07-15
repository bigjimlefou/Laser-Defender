using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    private WaveConfig currentWave;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = waveConfigs[0];

        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.NumberOfEnemies; i++)
        {
            Instantiate(waveConfig.EnemyPrefab, waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
        
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
