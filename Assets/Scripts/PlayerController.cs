using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Object and component declarations:
        Rigidbody2D myRigidbody;


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

        //Rotate towards mouse position:
            transform.up = Vector2.Lerp(transform.up, mousePosition, rotationSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        //Movement logic happens here to work good with unity physics:

            //Thrust/Move
                if(!isBraking)
                {
                    myRigidbody.AddForce(mousePosition * accelerationSpeed);
                        if(lateralAccelerationInput != 0)
                        {
                            myRigidbody.AddForce(new Vector2(lateralAccelerationInput * thrustSpeed, 0f));
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

        //Mouse position tracker:
            mousePosition = Vector2.ClampMagnitude(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1f);


        //Primary Weapon key    
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Shoot.");
                Debug.Log(mousePosition);
            }
                                   
        //Secondary Weapon Key
            if (Input.GetMouseButtonDown(1))
            {
               Debug.Log("Special Weapon Shoot.");
            }

    }

}
