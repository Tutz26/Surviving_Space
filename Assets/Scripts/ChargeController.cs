using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController : MonoBehaviour
{
        //Set the type of projectile used by the charge:
        //TODO: Make this dynamic depending on player attributes.
        public GameObject projectilePrefab;
    

    /// <summary>
    /// Set the color of the carge "particles" based on the player preferences.
    /// </summary>
    void Start()
    {
        this.GetComponent<Renderer>().material.color = new Color(1F,1F,100F,1F); 
    }

    /// <summary>
    /// When animation ends, instanciate the projectile prefab and destroy self.
    /// </summary>
    public void AnimationEnded()
    {
        Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}
