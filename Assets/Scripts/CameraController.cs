using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
        //Object declarations:
            GameObject playerObject;
            PlayerController playerController;

        //Vector declarations:
            Vector2 currentPosition;
            Vector2 newPosition;
            Vector2 directionToLookAt;

        //Quaternio declarations:
            Quaternion thisRotation;
            Quaternion playerRotation;

        //float declarations:
            public float armLength = 8.35f;
            public float cameraFollowSpeed = 10f;
            float cameraRotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //Default values:
            cameraFollowSpeed = 5f;

        //Camera arm length
            this.transform.position = new Vector2(this.transform.position.x, armLength);


    }

    void FixedUpdate()
    {

        //Follow the player:
        this.transform.position = Vector2.Lerp(currentPosition, newPosition, cameraFollowSpeed * Time.deltaTime);

   
    }
    // Update is called once per frame
    void Update()
    {

        //Track positions of self and player.
        currentPosition = (Vector2) this.transform.position;
        newPosition = new Vector2(playerObject.transform.position.x, playerObject.transform.position.y + armLength);

        //track rotation of self and player



    }
}
