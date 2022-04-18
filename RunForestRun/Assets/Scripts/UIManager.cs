using System.Collections;
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
        if (SceneManager.GetActiveScene().buildIndex == 0 )
        {
            instructionsText.text = "Avoid all traffic and don't go over 2000 calories! move L or R\n One Day Lil' Gumpy started running... \n Press Space to continue and jump!"; 
        }
        

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

           
            instructionsText.text = "You died of diabetes!" + "\n" + "Press R to Try again!"; 
        }

        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name); 

            
        }

      

    }
}
