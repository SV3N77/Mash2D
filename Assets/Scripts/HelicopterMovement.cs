using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class HelicopterMovement : MonoBehaviour
{
    public float moveSpeed; // Move speed of helicopter
    public Camera camera; // Main camera
    private Rigidbody2D heliRigidbody2D; // Get the player controller

    // Start is called before the first frame update
    void Start()
    {
        heliRigidbody2D = GetComponent<Rigidbody2D>(); // Gets heli's rigid body
    }
    
    // Update is called once per frame
    void Update()
    {
        checkOffScreen();
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
    void checkOffScreen()
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
}
