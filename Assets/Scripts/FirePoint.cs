using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{

    //Set the projectile
        public GameObject chargePrefab;
    
    void Start()
    {
            //TODO: Make VFX and positioning depedning on player weapons location and weapon type based on player attributes.         
    }   


    /// <summary>
    /// Creates instance of the "Charge object VFX" and asign it as child of the firepoint object.
    /// </summary>
    public void Shoot()
    {        
        GameObject chargeVFX = Instantiate(chargePrefab, (Vector2) this.transform.position, this.transform.rotation);
        chargeVFX.transform.parent = transform;

    }

}
