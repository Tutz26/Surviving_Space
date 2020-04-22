using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlls all the main movement of the player camera.
/// </summary>
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


    /// <summary>
    /// Assign objects to vars
    /// </summary>
    void Start()
    {
        //Track player object:
            playerObject = GameObject.FindGameObjectWithTag("Player");

        //Default values:
            cameraFollowSpeed = 5f;

        //Set camera distance from the player (fixed)
            this.transform.position = new Vector2(this.transform.position.x, armLength);


    }

    /// <summary>
    /// Since the player is physics based the logic of position is placed in Fixed Update.
    /// </summary>
    void FixedUpdate()
    {

        //Follow the player:
        this.transform.position = Vector2.Lerp(currentPosition, newPosition, cameraFollowSpeed * Time.deltaTime);

   
    }
    
    /// <summary>
    /// Updates the player position and the camera position.
    /// </summary>
    void Update()
    {

        //Track positions of self and player.
        currentPosition = (Vector2) this.transform.position;
        newPosition = new Vector2(playerObject.transform.position.x, playerObject.transform.position.y + armLength);

        //TODO: Create the rotation with the player to keep the aspect ratio relative to the player sight.



    }
}
