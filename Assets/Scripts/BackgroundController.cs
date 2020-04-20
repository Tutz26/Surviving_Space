using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //This is script is the controller of the quad object to maintain a seamless background below the player to simulate a universe.

    //Main Camera of the player:
        private Camera mainCamera;
    //Object of the player:
        GameObject playerObj;
    //Renderer of the background image.
        Renderer bgRenderer;
    //Seamless speed:        
        public Vector2 bgSpeed;
    
    
    /// <summary>
    /// Initialize all the objects when created
    /// </summary>
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        bgRenderer = this.GetComponent<Renderer>();
        
    }

    /// <summary>
    /// Fixed update is used because of the phyisics applied in the player.
    /// </summary>
    void FixedUpdate()
    {
        //Creates the speed based on the player position.
            bgSpeed = new Vector2(playerObj.transform.position.x * Time.deltaTime, playerObj.transform.position.y * Time.deltaTime);
    }

    /// <summary>
    /// Update is used to maintain the values of the position and speed updated.
    /// </summary>
    void Update()
    {
        //The offset adquires values based on the speed to reposition the textureOffset.
        Vector2 offset = (Vector2) bgSpeed;        
        GetComponent<Renderer>().material.mainTextureOffset = offset;

        //Keeps the quad position based on the camera form
        //TODO: Watch how to match position with rotation of the camera.
        this.transform.position = (Vector2) mainCamera.transform.position;
        

    }


}
