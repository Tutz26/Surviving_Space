using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //Object to spawn:
    public GameObject enemyObject;

    //Random coords range to spawn:
    float randX;
    float randY;
    
    //Vector to create for spawning:
    Vector2 spawnPoint;

    //Spawn rates:
    public float enemySpawnedLimit = 5f;
    public float spawnRate = 2f;
    float nextSpawn = 0.5f;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    //Get count of hildren and compare to limit
        if(this.transform.childCount < enemySpawnedLimit)
        {


        //Spawn at certain interval of time.
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(-50f, 50f);
                randY = Random.Range(-50f, 50f);
                spawnPoint = new Vector2(transform.position.x + randX, transform.position.y + randY);
                
                GameObject enemyObjectInstance = Instantiate(enemyObject, spawnPoint, Quaternion.identity);
                enemyObjectInstance.transform.parent = this.transform;

            }
        }

    }
}
