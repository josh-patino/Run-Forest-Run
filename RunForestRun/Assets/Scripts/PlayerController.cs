/*
* GRoup 1
* Project 4
* manages the player script
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private AudioSource playerAudio;
    public AudioClip jump;
    public AudioClip crashing;
    public AudioClip eating;
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

    void Awake() {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<UIManager>();
    }

    void Start() {
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        forceMode = ForceMode.Impulse;

        if (Physics.gravity.y > -10) {
            Physics.gravity *= gravityModifier;
        }
        //displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<UIManager>();
        //cb = GameObject.FindGameObjectWithTag("CalorieBar").GetComponent<CalorieBar>();
    }


    // Update is called once per frame
    void Update() {
        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        if (!gameOver) {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }

        if (transform.position.z < -zRange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        // keep player in bounds on the pos side
        if (transform.position.z > zRange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            playerAudio.PlayOneShot(jump, 0.5F);
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") && !gameOver) {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle") && !gameOver) {
            Debug.Log("Game is over!");
            gameOver = true;
            playerAudio.PlayOneShot(crashing, 1.0f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("HealthyFood")) {
            displayScoreScript.cal -= 130;
            if (displayScoreScript.cal < 0) {
                displayScoreScript.cal = 0;
            }

            Destroy(other.gameObject);
            playerAudio.PlayOneShot(eating, 1.0f);
        }

        if (other.CompareTag("UnhealthyFood")) {
            displayScoreScript.cal += 200;
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(eating, 2.0f);
        }
    }
}