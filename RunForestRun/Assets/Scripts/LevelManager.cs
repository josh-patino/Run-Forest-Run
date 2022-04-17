using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//attach to scenemanager
//keeps track of time to progress levels as time would be closest thing to distance variable we have

public class LevelManager : MonoBehaviour
{

    public float timeLeft;
    public float time;
    int nextSceneIndex;

    private PlayerController playerControllerScript;




    // Start is called before the first frame update
    void Start()
    {
        //grab current scene
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        //start time of level
        time = Time.time;
        //changes how long each stage lasts adding time each new stage
        timeLeft = (SceneManager.GetActiveScene().buildIndex + 1) * 40f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time >= time + timeLeft) /*&& (playerControllerScript.gameOver != true)*/)
        {
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
