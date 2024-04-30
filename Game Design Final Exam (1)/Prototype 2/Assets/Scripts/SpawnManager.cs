using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX =20;
    private float spawnRangeZ =20;
    private float startDelay = 2;
    private float SpawnInterval =1.5f;
    // public int animalIndex;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",startDelay,SpawnInterval);
    }

    void SpawnRandomAnimal(){
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,spawnRangeZ);
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], spawnPos,animalPrefabs[animalIndex].transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
