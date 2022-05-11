/*
* GRoup 1
* Project 4
* manages the car and food spawns
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour {
    [FormerlySerializedAs("prefabsToSpawn")] public GameObject[] vehiclePrefabs;
    private float spawnPosX = 210.0f;
    private PlayerController playerControllerScript;
    public float minRangeInSec = 0.3f;
    public float maxRangeInSec = 0.8f;
    public float foodTimeModifier = 2f;

    public int laneCount = 6;
    public float laneWidth = 0f;
    public float playerBoundary = 6.5f;
    List<float> laneMiddlePoint = new List<float>();
    private int randomLane = 0;
    private int lastSpawnedLane = 0;
    
    public GameObject[] foodPrefabs;


    // Start is called before the first frame update
    void Start() {
        DefineLanes(playerBoundary);
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartCoroutine(SpawnRandomVehiclePreFabWithCoroutine());
        StartCoroutine(SpawnRandomFoodPrefabWithCoroutine());
    }

    IEnumerator SpawnRandomVehiclePreFabWithCoroutine() {
        yield return new WaitForSeconds(3f);
        while (!playerControllerScript.gameOver) {
            //pick a random car
            int prefabIndex = Random.Range(0, vehiclePrefabs.Length);
        
            //Pick a random lane making sure we don't pick the last lane that spawned something.
            while (randomLane == lastSpawnedLane) {
                randomLane = Random.Range(0, laneMiddlePoint.Count);
                Debug.Log("Random Lane Chosen: " + randomLane);
            }
            //Update the last spawned lane.
            lastSpawnedLane = randomLane;
        
            //Generate the spawn position based on the lane
            Vector3 spawnPos = new Vector3(spawnPosX, 0, laneMiddlePoint[randomLane]);

            //Create the Vehicle
            Instantiate(vehiclePrefabs[prefabIndex], spawnPos, vehiclePrefabs[prefabIndex].transform.rotation);
            
            //Random delay
            float randomDelay = Random.Range(minRangeInSec, maxRangeInSec);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    IEnumerator SpawnRandomFoodPrefabWithCoroutine() {
        yield return new WaitForSeconds(3f);
        while (!playerControllerScript.gameOver) {
            //Pick a random food
            int prefabFoodIndex = Random.Range(0, foodPrefabs.Length);
        
            //Pick a random lane making sure we don't pick the last lane that spawned something.
            while (randomLane == lastSpawnedLane) {
                randomLane = Random.Range(0, laneMiddlePoint.Count);
                Debug.Log("Random Lane Chosen: " + randomLane);
            }
            //Update the last spawned lane.
            lastSpawnedLane = randomLane;
        
            //Generate the spawn position based on the lane
            Vector3 spawnPos = new Vector3(spawnPosX, 0, laneMiddlePoint[randomLane]);
        
            //Create the food
            Instantiate(foodPrefabs[prefabFoodIndex], spawnPos, foodPrefabs[prefabFoodIndex].transform.rotation);
            
            //Random delay
            float randomDelay = Random.Range(minRangeInSec * foodTimeModifier, maxRangeInSec * foodTimeModifier);
            yield return new WaitForSeconds(randomDelay);
        }
    }
    
    //Boundary represents how far in a single direction the player controller is able to move.
    void DefineLanes(float boundary) {
        //Define the lane width as the total distance of the player boundary
        //Divided by the total lane count
        laneWidth = (boundary * 2) / laneCount;
        //Initialize the leftmostbound as the bound provided
        float leftmostBound = boundary;
        for (int i = 0; i < laneCount; i++) {
            float rightmostBound = leftmostBound - laneWidth;
            //Add the middle point of the leftmostbound and the rightmost bound of each lane to the list
            //for the total lane count
            laneMiddlePoint.Add((leftmostBound + rightmostBound)/2);
            //Update the leftmostbound to the right bound of the added lane
            leftmostBound = (leftmostBound - laneWidth);
        }
    }
}