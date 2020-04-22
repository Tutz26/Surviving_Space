using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains all the basic stats for an enemy/player object
/// </summary>
public class Stats : MonoBehaviour
{

    //Includes all of the basic stats needed to create a living/destructible object.

        //Basic INHUD values:
            public float hitPoints = 100f;
            public float shieldPoints = 100f;    
            public float energyPoints =20f;

        //Speed values:
            public float thrustSpeed = 5f;
            public float thrustPanningSpeed = 3f;
            public float thrustRotationSpeed = 0.8f;
            public float brakeSpeed = 2f;
            public float shootingSpeed =1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
