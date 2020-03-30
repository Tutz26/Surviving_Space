using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{

    //Set the projectile
        public GameObject chargePrefab;
    
    void Start()
    {
                 
    }


    public void Shoot()
    {        
        GameObject chargeVFX = Instantiate(chargePrefab, (Vector2) this.transform.position, this.transform.rotation);
        chargeVFX.transform.parent = transform;

    }

}
