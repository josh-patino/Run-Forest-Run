/*
* GRoup 1
* Project 4
* manages the player script
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; 
    public float jumpForce;
    public bool isOnGround = true; 
    public ForceMode forceMode; 
    public bool gameOver = false; 
    public float gravityModifier; 
    public float horizontalInput; 
    public float speed; 
    public float zRange = 6.5f;
    //public CalorieBar cb;
    private UIManager displayScoreScript; 
    
    // Start is called before the first frame update

    void Awake()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<UIManager>();

    }
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        forceMode = ForceMode.Impulse;

        if(Physics.gravity.y > -10)
        {
        Physics.gravity *= gravityModifier; 
        }
        //displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<UIManager>();
        //cb = GameObject.FindGameObjectWithTag("CalorieBar").GetComponent<CalorieBar>();
    }
    

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        if (!gameOver)
        {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }

         if(transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        // keep player in bounds on the pos side
        if(transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y , zRange);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce,forceMode); 
            isOnGround = false; 
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Ground") && !gameOver)
       {
           isOnGround = true; 
           //dirtParticle.Play(); 
       } 
       else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
       {
           //playerAnimator.SetBool("Death_b", true);
           //playerAnimator.SetInteger("DeathType_int", 1);  
           Debug.Log("Game is over!");
           gameOver = true; 
           //playerAudio.PlayOneShot(crashSound, 1.0f); 
           //explosionParticle.Play();

       }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthyFood"))
        {
            displayScoreScript.cal += 90; 
            Destroy(other.gameObject);

        }
        if (other.CompareTag("UnhealthyFood"))
        {
            displayScoreScript.cal += 200;
            Destroy(other.gameObject);
        }
    }

}
