/*
* GRoup 1
* Project 4
* manages the car and food spawns
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    private float leftBound = -6.5f; 
    private float rightBound = 6.5f; 
    private float spawnPosZ = 210.0f; 
    private PlayerController playerControllerScript; 
    public float minRangeInSec = 0.3f; 
    public float maxRangeInSec = 0.8f; 
    
    public GameObject[] foodPrefabs; 


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); 
        StartCoroutine(SpawnRandomPrefabWtihCoroutine()); 
    }
    IEnumerator SpawnRandomPrefabWtihCoroutine()
    {
        //add a 3 second delay before first spawning object
        yield return new WaitForSeconds(3f);
        while (!playerControllerScript.gameOver)
        {
            SpawnRandomPreFab();

            float randomDelay = Random.Range(minRangeInSec, maxRangeInSec); 

            yield return new WaitForSeconds(randomDelay);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomPreFab()
    {
        //pick a random car
            int prefabIndex = Random.Range(0,prefabsToSpawn.Length);
            int prefabFoodIndex = Random.Range(0,foodPrefabs.Length);

            // generate random spawn position
            Vector3 spawnPos = new Vector3(spawnPosZ, 0, Random.Range(leftBound,rightBound));
            Vector3 spawnPosFood = new Vector3(spawnPosZ, 0, Random.Range(leftBound,rightBound));

            // random animal to spawn
            Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
            Instantiate(foodPrefabs[prefabFoodIndex], spawnPosFood, foodPrefabs[prefabFoodIndex].transform.rotation);
            
    }

    
}
