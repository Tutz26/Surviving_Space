using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Object and component declarations:
        Rigidbody2D myRigidbody;
        Stats Stats;
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
    
    //TODO: This probably might be changed to attributes instade of player controller.
            //These are the values that the Color Sliders return
                    //COLOR VALUES:
                        float m_Red, m_Blue, m_Green;
                        Color m_NewColor;
                        SpriteRenderer m_SpriteRenderer;
                    //--------------



    /// <summary>
    /// Bring information about stats and attributes to the player.
    /// TODO: Might be changed to another component.
    /// </summary>
    void Start()
    {
            //COLOR OBJECTS
              m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
              m_SpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            //-----------

        //Material Collor Test
            // this.GetComponent<Renderer>().material.color = new Color(100F,1F,1F,1F); 

        //Get player stats:            
            Stats = this.GetComponent<Stats>();

        //get rigidbody component, must be dynamic to use unity physics:
            myRigidbody = this.GetComponent<Rigidbody2D>();

        //Other objects initialization;
            cam = Camera.main;
            firePoint = GetComponentInChildren<FirePoint>();

        //Speed Values:

            thrustSpeed = Stats.thrustSpeed;
            lateralThrustSpeed = Stats.thrustPanningSpeed;
            brakeSpeed = Stats.brakeSpeed;
            rotationSpeed = Stats.thrustRotationSpeed;
            shootingSpeed = Stats.shootingSpeed;
            rotationSpeed = Stats.thrustRotationSpeed;

    }

    /// <summary>
    /// Update used to keep track on inputs, mouse tracking and rotation since is direct applied to mouse instead of physics rotation.
    /// </summary>
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
            
            rotationZ = Mathf.Atan2(directionToLookAt.y, directionToLookAt.x) * Mathf.Rad2Deg;

            targetRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);            
            targetRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            transform.rotation = targetRotation;


            //  rotationVector = Quaternion.LookRotation(new Vector2 (directionToLookAt.x,directionToLookAt.y));


        //YOU're DEAD go back to main menu!!!!!
            if(this.GetComponent<Stats>().hitPoints <= 0f){
                Destroy(gameObject);
                SceneManager.LoadScene("Main_menu");
            }
            

    }

    /// <summary>
    /// Thrust, speed, acceleration, and braking logic is applied here to keep with physics by unity.
    /// </summary>
    void FixedUpdate()
    {
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
    
    /// <summary>
    /// Input manager keeps all input tracking for the user.list (Only for keyboard and mouse)
    /// TODO: Implement for Switch controllers and Generic GamePad.
    /// </summary>
    public void InputManager()
    {
        //Vertical and Horizontal thrust based on axis to be able to lerp:
            
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
                if(firePoint.transform.childCount == 0)
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

        /// <summary>
        /// Creates slides on GUI to let the player change the color.list
        /// TODO: Will change to another go referent to all GUI
        /// </summary>
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
