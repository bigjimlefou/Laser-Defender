using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    private WaveConfig _currentWave;

    // Start is called before the first frame update
    private void Start()
    {
        _currentWave = waveConfigs[0];

        StartCoroutine(SpawnAllEnemiesInWave(_currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.NumberOfEnemies; i++)
        {
            var enemy = Instantiate(waveConfig.EnemyPrefab, waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);

            enemy.GetComponent<EnemyPathing>().WaveConfig = waveConfig;
            
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
