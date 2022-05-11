/*
* GRoup 1
* Project 4
* manages the UI, displays the instructions, story, and the score
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public double cal = 500;

    //public Text calories; 
    public Text instructionsText;
    public Text calText;
    private PlayerController playerControllerScript;

    void Start() {
        if (calText == null) {
            calText = FindObjectOfType<Text>();
        }

        if (playerControllerScript == null) {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        calText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        cal -= 10 * Time.deltaTime;
        
        if (cal < 0) {
            playerControllerScript.gameOver = true;
            instructionsText.text = "You died of Starvation!" + "\n" + "Press R to Try again!";
        } else if ( cal >= 2000) {
            playerControllerScript.gameOver = true;
            instructionsText.text = "You died of diabetes!" + "\n" + "Press R to Try again!";
            calText.text = "Calories: 2000";
        } else if (playerControllerScript.gameOver) {
            instructionsText.text = "You Lose!" + "\n" + "Press R to Try again!";
        }
        
        if ((SceneManager.GetActiveScene().buildIndex == 0)) {
            instructionsText.text =
                "Avoid all traffic and don't go over 2000 calories! move L or R\n One Day Lil' Gumpy started running..." +
                " \n Press Space to continue and jump!";
        }

        if (Input.GetKey(KeyCode.Space)) {
            instructionsText.gameObject.SetActive(false);
        }

        //display calories during the game
        if (!playerControllerScript.gameOver) {
            calText.text = "Calories: " + Math.Round(cal);
        } else {
            instructionsText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}