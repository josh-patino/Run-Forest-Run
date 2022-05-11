using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
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
        //restart game
        SceneManager.LoadScene(0);
    }
}
