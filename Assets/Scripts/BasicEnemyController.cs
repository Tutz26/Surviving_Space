using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    //Object and component declarations:
        Rigidbody2D myRigidbody;
        EnemyStats enemyStats;

    //Vector declarations:
        Vector2 movementVelocity;
        Vector2 directionToLookAt;

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



    // Start is called before the first frame update
    void Start()
    {
        enemyStats = this.GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        

         if(enemyStats.hitPoints <= 0f)
        {
            Destroy(gameObject);
        }


    }
}
