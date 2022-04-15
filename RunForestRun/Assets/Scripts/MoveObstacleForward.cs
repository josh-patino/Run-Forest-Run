using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacleForward : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 30f;
    private float leftBound = -30;
    private PlayerController playerControllerScript; 
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        //if we are out of bounds, the object will be destroyed
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); 
        }

    }
}
