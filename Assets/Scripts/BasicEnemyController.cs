using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    //Object and component declarations:
        Rigidbody2D myRigidbody;
        Stats Stats;
        GameObject player;
        public GameObject chargePrefab;
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



    // Start is called before the first frame update
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

    void RotateTowards(Vector2 targetToRotate) 
    {
        //Create rotation vector to look at
            var directionFromOrigin = targetToRotate - (Vector2) this.transform.position;
            var angleToRotate = Mathf.Atan2(directionFromOrigin.y, directionFromOrigin.x) * Mathf.Rad2Deg;

            targetRotation = Quaternion.Euler(0f,0f,angleToRotate -90f);
            targetRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            transform.rotation = targetRotation;

    }
    

    // Update is called once per frame
    void Update()
    {
        
        //If no hp then die.
         if(Stats.hitPoints <= 0f)
            {
                Destroy(gameObject);
            }

    }

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

    void ApplyBrakes()
    {
        // Applys negative acceleration to velocity to brake
        myRigidbody.AddForce(-brakeSpeed * myRigidbody.velocity);
    }

    void ShootTowardsTarget()
    {
               if(firePoint.transform.childCount == 0)
                {
                    firePoint.Shoot();             
                }
    }


    void RandomPatrolling()
    {
            
            RotateTowards(randomPointToPatrol);
            myRigidbody.AddForce((randomPointToPatrol - (Vector2) transform.position) * Mathf.Lerp(0f, 1f, thrustSpeed * Time.fixedDeltaTime));

            StartCoroutine(ChangeRandomPatrolPoint(10f));

    }


    //Create a diferente patrol point after specified time
    IEnumerator ChangeRandomPatrolPoint(float time)
    {
        yield return new WaitForSeconds(time);

            float randX = Random.Range(-100f, 100f);
            float randY = Random.Range(-100f, 100f);
        
            randomPointToPatrol = new Vector2(randX, randY);

    }
}
