using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float SpawnRange = 9;
    public int waveNumber =1;
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
       SpawnEnemyWave(waveNumber);
       Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        
    }
    private Vector3 GenerateSpawnPosition () {
        float spawnPosX = Random.Range(-SpawnRange,SpawnRange);
        float spawnPosZ = Random.Range(-SpawnRange,SpawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0 , spawnPosZ);
        return randomPos;

    }
    void SpawnEnemyWave(int enemiesToSpawn){
        for(int i=0;i<enemiesToSpawn;i++){
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }
    }

    public int enemyCount;

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
         
    }
}
