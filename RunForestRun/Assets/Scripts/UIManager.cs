﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class UIManager : MonoBehaviour
{
    public int cal = 0;
    //public Text calories; 
    public Text instructionsText; 
    public Text calText; 
    private PlayerController playerControllerScript; 
    public bool won = false; 
   
    // Start is called before the first frame update
    void Start()
    {
        //if (calText == null)
        //{
           // calText = FindObjectOfType<Text>();
        //}

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); 
        }

        calText.text = " "; 
    }

    // Update is called once per frame
    void Update()
    {
        instructionsText.text = "Avoid all traffic! collect healthy foods \n to increase protein! move L or R \n Press Space to continue!"; 

        if (Input.GetKey(KeyCode.Space))
        {
            instructionsText.gameObject.SetActive(false); 
        }

        //display calories during the game
        if (!playerControllerScript.gameOver)
        {
            calText.text = "Calories: " + cal;
        }
        if (playerControllerScript.gameOver && !won)
        {
            instructionsText.gameObject.SetActive(true);
            instructionsText.text = "You Lose!" + "\n" + "Press R to Try again!";   
        }
        // win condition: 10
        if (cal >= 2000)
        {
            playerControllerScript.gameOver = true; 
            won = true; 

           
            instructionsText.text = "You win!" + "\n" + "Press R to Try again!"; 
        }

        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name); 

            
        }

      

    }
}
