using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
       //Float values:

        //Basic values:
            public float hitPoints = 100f;
            public float shieldPoints = 100f;    
            public float energyPoints =20f;

        //Speed values:
            public float enemySpeed = 5f;
            public float enemyPanningSpeed = 3f;
            public float enemyRotationSpeed = 0.8f;
            public float enemyBrakeSpeed = 2f;
            public float enemyShootingSpeed =1f;




    // Start is called before the first frame update
    void Start()
    {
        //Default values:
            // hitPoints = 100f;
            // shieldPoints = 100f;
            // energyPoints = 20f;
            // playerSpeed = 5f;
            // playerPanningSpeed = 3f;
            // playerRotationSpeed = 100f;
            // playerBrakeSpeed = 2f;
            // playerShootingSpeed = 1f;


    }
}
