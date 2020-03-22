using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Object and component declarations:
        Rigidbody2D myRigidbody;
        Camera cam;

    //Vector declarations:
        Vector2 movementInput;
        Vector2 movementVelocity;
        Vector2 mousePosition;
        Vector2 directionToLookAt;

    //Float declarations:
        float thrustSpeed;
        float brakeSpeed;
        float rotationSpeed;
        float crosshairThresholdRadius;
        float accelerationInput;
        float lateralAccelerationInput;
        float accelerationSpeed;

    //Bool declarations:
        bool isBraking;
        // bool isMoving;



    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody component, must be dynamic to use unity physics:
            myRigidbody = this.GetComponent<Rigidbody2D>();

        //Other objects initialization;
            cam = Camera.main;

        //Speed defaults:
            thrustSpeed = 5f;
            brakeSpeed = 2f;
            rotationSpeed = 4f;

    }

    // Update is called once per frame
    void Update()
    {
        //Run Inputs:
            InputManager();

        //Calculate velocity based on input and thrust speed:
            if(!isBraking)
            {
                accelerationSpeed = accelerationInput * thrustSpeed;
            }

        //Calculate direction from mouse to player.
            directionToLookAt = (mousePosition - (Vector2)  this.transform.position).normalized;

        //Rotate towards mouse position:
            transform.up = Vector2.Lerp(transform.up, directionToLookAt, rotationSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        //Movement logic happens here to work good with unity physics:

            //Thrust/Move
                if(!isBraking)
                {
                        if(lateralAccelerationInput != 0)
                        {
                            myRigidbody.AddRelativeForce(new Vector2((lateralAccelerationInput * thrustSpeed), 0f));
                        }
                        else
                        {
                            myRigidbody.AddForce(directionToLookAt * accelerationSpeed);
                        }
                }
            //Brake
                else
                {
                    myRigidbody.AddForce(-brakeSpeed * myRigidbody.velocity);
                }

    }
    
    void InputManager()
    {
        //Vertical and Horizontal thrust:
            
            accelerationInput = Input.GetAxis("Vertical");
            lateralAccelerationInput = Input.GetAxis("Horizontal");

        //Brake input:
            isBraking = Input.GetKey("left ctrl") ? true : false;

        //Mouse position tracker based on camera:
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            if(Input.GetKey("space"))
            {
                 Debug.Log(mousePosition);
            }

        //Primary Weapon key    
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Shoot.");
               
            }
                                   
        //Secondary Weapon Key
            if (Input.GetMouseButtonDown(1))
            {
               Debug.Log("Special Weapon Shoot.");
            }

    }

}
