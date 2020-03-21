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

    //Float declarations:
        float thrustSpeed;
        float brakeSpeed;

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


    }

    // Update is called once per frame
    void Update()
    {
        //Run Inputs:
            InputManager();

        //Calculate velocity based on input and thrust speed:
            if(!isBraking)
            {
                movementVelocity = movementInput * thrustSpeed;
            }
    }

    void FixedUpdate()
    {
        //Movement logic happens here to work good with unity physics:

            //Thrust/Move
                if(!isBraking)
                {
                    myRigidbody.AddForce(movementInput);
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
            movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Brake input:
            isBraking = Input.GetKey("left ctrl") ? true : false;
           
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
