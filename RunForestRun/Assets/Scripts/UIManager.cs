using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class UIManager : MonoBehaviour
{
    public int cal = 1;
    public Text calText; 
    public Text instructionsText; 
    private PlayerController playerControllerScript; 
    public bool won = false; 
    // Start is called before the first frame update
    void Start()
    {
        if (calText == null)
        {
            calText = FindObjectOfType<Text>();
        }

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); 
        }

        calText.text = "wave: 0"; 
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
            calText.text = "cal  " + cal;
        }
        if (playerControllerScript.gameOver && !won)
        {
            instructionsText.gameObject.SetActive(true);
            instructionsText.text = "You Lose!" + "\n" + "Press R to Try again!";   
        }
        // win condition: 10
        if (cal >= 10)
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
