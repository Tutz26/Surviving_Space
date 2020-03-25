using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{

    //Set the projectile
        public GameObject projectilePrefab;
    

    void Start()
    {

    }


    public void Shoot()
    {
        Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
    }

}
