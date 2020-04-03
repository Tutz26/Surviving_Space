using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Object and component declarations:
        Rigidbody2D myRigidbody;
        PlayerStats playerStats;
        Camera cam;
        FirePoint firePoint;

    //Vector declarations:
        Vector2 movementInput;
        Vector2 movementVelocity;
        Vector2 mousePosition;
        Vector2 directionToLookAt;

    //Quaternionr declarations:
        Quaternion targetRotation;

    //Float declarations:
        float thrustSpeed;
        float lateralThrustSpeed;
        float brakeSpeed;
        float rotationSpeed;
        float crosshairThresholdRadius;
        float accelerationInput;
        float lateralAccelerationInput;
        float accelerationSpeed;
        float shootingSpeed;
        float rotationZ;

    //Bool declarations:
        bool isBraking;
        // bool isMoving;
        //These are the values that the Color Sliders return
                    //COLOR VALUES:
                        float m_Red, m_Blue, m_Green;
                        Color m_NewColor;
                        SpriteRenderer m_SpriteRenderer;
                    //--------------



    // Start is called before the first frame update
    void Start()
    {
            //COLOR OBJECTS
              m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
              m_SpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            //-----------

        //Material Collor Test
            // this.GetComponent<Renderer>().material.color = new Color(100F,1F,1F,1F); 

        //Get player stats:            
            playerStats = this.GetComponent<PlayerStats>();

        //get rigidbody component, must be dynamic to use unity physics:
            myRigidbody = this.GetComponent<Rigidbody2D>();

        //Other objects initialization;
            cam = Camera.main;
            firePoint = GameObject.FindGameObjectWithTag("FirePoint").GetComponent<FirePoint>();

        //Speed Values:

            thrustSpeed = playerStats.playerSpeed;
            lateralThrustSpeed = playerStats.playerPanningSpeed;
            brakeSpeed = playerStats.playerBrakeSpeed;
            rotationSpeed = playerStats.playerRotationSpeed;
            shootingSpeed = playerStats.playerShootingSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        rotationSpeed = playerStats.playerRotationSpeed;
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
            
            rotationZ = Mathf.Atan2(directionToLookAt.y, directionToLookAt.x) * Mathf.Rad2Deg;

            targetRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);            
            targetRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            transform.rotation = targetRotation;


            //  rotationVector = Quaternion.LookRotation(new Vector2 (directionToLookAt.x,directionToLookAt.y));


    }

    void FixedUpdate()
    {
        //Movement logic happens here to work good with unity physics:

            //Thrust/Move
                if(!isBraking)
                {
                        if(lateralAccelerationInput != 0)
                        {
                            myRigidbody.AddRelativeForce(new Vector2((lateralAccelerationInput * lateralThrustSpeed), 0f));
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
    
    public void InputManager()
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
                //  Debug.Log(mousePosition);
                 Debug.Log(transform.up);
                //  Debug.Log(rotationVector);
                //  Debug.Log(directionToLookAt);
            }

        //Primary Weapon key    
            if (Input.GetMouseButtonDown(0))
            {                
                if(GameObject.FindGameObjectWithTag("chargeVFX") == null)
                {
                    firePoint.Shoot();             
                }
            }
                                   
        //Secondary Weapon Key
            if (Input.GetMouseButtonDown(1))
            {
               Debug.Log("Special Weapon Shoot.");
            }

    }

        //COLOR ON GUI
        void OnGUI()
    {
        //Use the Sliders to manipulate the RGB component of Color
        //Use the Label to identify the Slider
                // GUI.Label(new Rect(0, 30, 50, 30), "Red: ");
                // //Use the Slider to change amount of red in the Color
                // m_Red = GUI.HorizontalSlider(new Rect(35, 25, 200, 30), m_Red, 0, 1);

                // //The Slider manipulates the amount of green in the GameObject
                // GUI.Label(new Rect(0, 70, 50, 30), "Green: ");
                // m_Green = GUI.HorizontalSlider(new Rect(35, 60, 200, 30), m_Green, 0, 1);

                // //This Slider decides the amount of blue in the GameObject
                // GUI.Label(new Rect(0, 105, 50, 30), "Blue: ");
                // m_Blue = GUI.HorizontalSlider(new Rect(35, 95, 200, 30), m_Blue, 0, 1);

                // //Set the Color to the values gained from the Sliders
                // m_NewColor = new Color(m_Red, m_Green, m_Blue);

                // //Set the SpriteRenderer to the Color defined by the Sliders
                // m_SpriteRenderer.color = m_NewColor;
    }
        //-------------

}
