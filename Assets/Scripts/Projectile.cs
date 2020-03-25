using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Component declarations:
        Rigidbody2D projectileRigidbody;

    //Vector declarations:
        Vector2 initialPosition;

    //Float declarations:
        public float projectileSpeed = 10f;
        public float maxDistance = 50f;

    // Start is called before the first frame update
    void Start()
    {
        projectileRigidbody = this.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = transform.up * projectileSpeed;
        initialPosition = (Vector2) this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(initialPosition, (Vector2) this.transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

}
