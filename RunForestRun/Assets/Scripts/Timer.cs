using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public LevelManager levelManager;
    private PlayerController playerControllerScript;


    public float timeLeft;
    public Text timeText;

    public float totalTime;

    // Start is called before the first frame update
    void Start() {
        if (timeText == null) {
            timeText = FindObjectOfType<Text>();
        }

        timeText.gameObject.SetActive(true);


        if (levelManager == null) {
            levelManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelManager>();
        }
        timeLeft = (SceneManager.GetActiveScene().buildIndex + 1) * 15f;
        
    }

    // Update is called once per frame
    void Update() {
        timeLeft -= Time.deltaTime;
        timeText.text = "Time Left: " + Math.Round(timeLeft);
    }
}