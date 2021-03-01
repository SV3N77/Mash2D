using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // Move speed of helicopter
    public Camera camera; // Main camera
    private Rigidbody2D heliRigidbody2D; // Get the player controller
    private GameObject soldier; // Gets the Soldier game object
    private int counter = 0; // initialise counter
    private int maxCounter = 9; // max soldiers
    
    // Start is called before the first frame update
    void Start()
    {
        heliRigidbody2D = GetComponent<Rigidbody2D>(); // Gets heli's rigid body
        soldier = GameObject.FindGameObjectWithTag("Soldier");
    }
    
    // Update is called once per frame
    void Update()
    {
        CheckOffScreen();
    }
    
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        HeliMovement();
    }
    //Heli movement
    void HeliMovement()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        heliRigidbody2D.MovePosition(heliRigidbody2D.position + movement * Time.fixedDeltaTime);
    }
    
    //Creating clamp for moving off screen
    void CheckOffScreen()
    {
        // Getting pixels of camera and creating a rectangle
        var bottomeLeft = camera.ScreenToWorldPoint(Vector2.zero);
        var topRight = camera.ScreenToWorldPoint(new UnityEngine.Vector3(camera.pixelWidth, camera.pixelHeight));
        var cameraRect = new Rect(
            bottomeLeft.x,
            bottomeLeft.y,
            topRight.x - bottomeLeft.x,
            topRight.y - bottomeLeft.y
        );
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax),
            Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax)
        );
    }

    // Checks collisions with other objects
    void OnCollisionEnter2D(Collision2D col)
    {
        // Checks collision with tree, hospital and soldier
        if (col.gameObject.CompareTag("Tree"))
        {
            SceneManager.LoadScene("GameOverScene"); // loads gameover scene
        }
        else if (col.gameObject.CompareTag("Hospital"))
        {
            ScoreScript.AddScore(counter); // Adds counter to scorevalue
            counter = 0;// Resets counter to pickup more soldiers
            InHeli.soldierInHeli = 0;
        }
        else if(col.gameObject.CompareTag("Soldier") && counter < 3)
        {
            Destroy(col.gameObject); // destroys soldier
            counter++; // adds to the counter
            InHeli.CountSoldier(counter);
        }
        else if(ScoreScript.scoreValue == maxCounter)
        {
            SceneManager.LoadScene(2);
        }
        Debug.Log(counter);
    }
    
}
