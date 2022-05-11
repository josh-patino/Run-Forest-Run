using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{

    public LevelManager levelManager;
    private PlayerController playerControllerScript;


    public float timeLeft;
    public Text timeText;
    public float totalTime;
    // Start is called before the first frame update
    void Start()
    {
        if (timeText == null)
        {
            timeText = FindObjectOfType<Text>();
        }
        timeText.gameObject.SetActive(true);


        if (levelManager == null)
        {
            levelManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelManager>();
        }
        //totalTime = (SceneManager.GetActiveScene().buildIndex + 1) * 15f;
        //works kinda
        // timeLeft = levelManager.timeLeft;
        timeLeft = (SceneManager.GetActiveScene().buildIndex + 1) * 15f;

        //timeText.text = "Time Left: " + timeLeft;
    }

    // Update is called once per frame
    void Update()
    {

        //timeLeft += Time.deltaTime;
        timeLeft -=  Time.deltaTime;


        timeText.text = "Time Left: " + timeLeft;

       /* if (!playerControllerScript.gameOver)
        {
            timeText.text = "Time Left: " + timeLeft;
        }*/
    }
}
