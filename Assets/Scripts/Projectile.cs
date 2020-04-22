using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Prefab projectile generator.
/// </summary>
public class Projectile : MonoBehaviour
{
    //Component declarations:
        Rigidbody2D projectileRigidbody;
        public GameObject collisionEffect;

    //Vector declarations:
        Vector2 initialPosition;

    //Float declarations:
        public float projectileSpeed = 10f;
        public float maxDistance = 50f;


    //Components of otherCollision
        public float projectileDamage = 25f;

    /// <summary>
    /// Object to variables.
    /// TODO: Will probably change the color projectile derived from player attributes.
    /// </summary>
    void Start()
    {
        //Changes the color of the projectile.
            this.GetComponent<Renderer>().material.color = new Color(1F,1F,100F,1F); 

        //Get rigidbody.
            projectileRigidbody = this.GetComponent<Rigidbody2D>();

        //Creates the projectile with specified velocitiy of the projectile
        //TODO: Will probably get velocity from player attributes.
            projectileRigidbody.velocity = transform.up * projectileSpeed;

        //Gets the position based on the instanciation.
            initialPosition = (Vector2) this.transform.position;
    }

    /// <summary>
    /// If it reaches the limit distance it will destroy itself.
    /// TODO: Probable will limit itself from player attributes (weapon attributes).
    /// </summary>
    void Update()
    {
        if(Vector2.Distance(initialPosition, (Vector2) this.transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// On collision enter against other object.
    /// TODO: Will change depending on projectile type variant depending on weapon and player attributes.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {

        // Debug.Log(other.name);

        //Creates an instance of the GB effect for the COLLISION POINT.
            GameObject effect = Instantiate(collisionEffect, transform.position, Quaternion.identity);

        //Destroy the effect based on time.
        //TODO: Change the destroy of the effect based on VFX long.
            Destroy(effect, 6f*Time.deltaTime);
            Destroy(gameObject);
        

        //Logic if the collision is an Enemy (How it affects the enemy)
            if (other.tag == "Enemy")
            {
                other.GetComponent<Stats>().hitPoints  = other.GetComponent<Stats>().hitPoints - projectileDamage;
            }

        //Logic if the collision is a Player (How it affects the player)
            if (other.tag == "Player")
            {
                other.GetComponent<Stats>().hitPoints  = other.GetComponent<Stats>().hitPoints - projectileDamage;
            }


    }

}
