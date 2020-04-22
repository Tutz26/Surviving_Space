using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic enemy AI that roams randomly, follows and attacks player
/// </summary>
public class BasicEnemyController : MonoBehaviour
{
    //Object and component declarations:
        Rigidbody2D myRigidbody;
        Stats Stats;
        GameObject player;
        public GameObject chargeVFXProjectilePrefab;
        FirePoint firePoint;


    //Vector declarations:
        Vector2 movementVelocity;
        Vector2 directionToLookAt;
        Vector2 randomPointToPatrol;

    //Quaternion declarations:
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
        float distanceBetweenTarget;
        public float thresholdLimitToFollow;
        public float thresholdLimitToAttack;



    /// <summary>
    /// Create all variables for objects.
    /// </summary>
    void Start()
    {
         //COLOR OBJECTS
            //   m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
            //   m_SpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            //-----------

        //Material Collor Test
            // this.GetComponent<Renderer>().material.color = new Color(100F,1F,1F,1F); 

        //Set player object
            player = GameObject.FindGameObjectWithTag("Player");

        //Get stats:            
            Stats = this.GetComponent<Stats>();

        //get rigidbody component, must be dynamic to use unity physics:
            myRigidbody = this.GetComponent<Rigidbody2D>();

            firePoint = GetComponentInChildren<FirePoint>();

        //Speed Values:
            thrustSpeed = Stats.thrustSpeed;
            lateralThrustSpeed = Stats.thrustPanningSpeed;
            brakeSpeed = Stats.brakeSpeed;
            rotationSpeed = Stats.thrustRotationSpeed;
            shootingSpeed = Stats.shootingSpeed;


    }

    /// <summary>
    /// Rotates the object towards the vector desired
    /// </summary>
    /// <param name="targetToRotate">X and Y coordinates for where you want the object to look at</param>
    void RotateTowards(Vector2 targetToRotate) 
    {
        //Create rotation vector to look at
            var directionFromOrigin = targetToRotate - (Vector2) this.transform.position;
            var angleToRotate = Mathf.Atan2(directionFromOrigin.y, directionFromOrigin.x) * Mathf.Rad2Deg;

            targetRotation = Quaternion.Euler(0f,0f,angleToRotate -90f);
            targetRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            transform.rotation = targetRotation;

    }
    

    /// <summary>
    /// Updates the hp to see if object should be destroyed.
    /// </summary>
    void Update()
    {
        
        //If no hp then die.
         if(Stats.hitPoints <= 0f)
            {
                Destroy(gameObject);
            }

    }

    /// <summary>
    /// Most movement logic is here because is based on unity physics.
    /// </summary>
    void FixedUpdate()
    {
        //Calculate distance between current position and player.
            distanceBetweenTarget = Vector2.Distance(player.transform.position, transform.position);

        //If player is close to be targeted:
            if(distanceBetweenTarget < thresholdLimitToFollow)
            {
         
            //Point (Rotate) towards target:
                RotateTowards((Vector2) player.transform.position);

            //If Distance is enough to attack.
                if(distanceBetweenTarget < thresholdLimitToAttack)
                    {
                        //If player is close enough to attack brake:
                            ApplyBrakes();
                            ShootTowardsTarget();
                        //Attack

                    }
                    else
                    {
                        //Accelerate towards target:
                            myRigidbody.AddForce(((Vector2) player.transform.position - (Vector2) transform.position) * Mathf.Lerp(0f, 1f, thrustSpeed-3f * Time.fixedDeltaTime));
                    }

            } 
            else
            {
                
                //Apply random patrolling here:
                    RandomPatrolling();
            }

    }   

    /// <summary>
    /// Applys negative force to the velocity to brake
    /// </summary>
    void ApplyBrakes()
    {
        // Applys negative acceleration to velocity to brake
            myRigidbody.AddForce(-brakeSpeed * myRigidbody.velocity);
    }

    /// <summary>
    /// It generates projectile instance based on firepoint position and rotation.
    /// </summary>
    void ShootTowardsTarget()
    {
        //It only creates another projectile if the firepoint is not charing.
            if(firePoint.transform.childCount == 0)
            {
                firePoint.Shoot();             
            }
    }

    /// <summary>
    /// Creates a random patrolling/roaming between a randomized x and y position on map.
    /// </summary>
    void RandomPatrolling()
    {
        //Rotates the object towards the random point       
            RotateTowards(randomPointToPatrol);

        //Add force towards the random position with a linear interpolation for acceleration simulation.            
            myRigidbody.AddForce((randomPointToPatrol - (Vector2) transform.position) * Mathf.Lerp(0f, 1f, thrustSpeed * Time.fixedDeltaTime));

        //Calls for a change on the random position
            StartCoroutine(ChangeRandomPatrolPoint(10f));

    }


    /// <summary>
    /// Creates a different random position based on x and y coordinates at a certain time.
    /// </summary>
    /// <param name="time">Add time in floats as seconds.</param>
    /// <returns></returns>
    IEnumerator ChangeRandomPatrolPoint(float time)
    {
        yield return new WaitForSeconds(time);

            float randX = Random.Range(-40f, 40f);
            float randY = Random.Range(-40f, 40f);
        
            randomPointToPatrol = new Vector2(randX, randY);

    }
}
