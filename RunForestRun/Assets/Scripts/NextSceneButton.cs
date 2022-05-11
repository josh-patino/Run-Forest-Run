﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextSceneButton : MonoBehaviour
{
    private Button button;

    //private StoryManager storyManager;

    public int difficulty;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(SetDifficulty);

    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        //go to the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
