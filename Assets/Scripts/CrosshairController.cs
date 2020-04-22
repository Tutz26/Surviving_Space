using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlls the crosshair position to stay with player
/// </summary>
public class CrosshairController : MonoBehaviour
{
        //READ:
            //Since object corsshair is children of the player object, it updates its local position once the player position/rotation changes.
            //There is no need to mess with the positioning UNLESS there is a weapon created that can shoot to another coordinates the player is not looking at.
        //TODO: Make dynamic to object attributes and possibly rework for a multi corsshair depending on weapons.


        //Object declarations:
            GameObject playerObject;

        //Vector declarations:
            Vector2 positionTracker;

        //Float declarations:
            float distanceFromPlayer;

    /// <summary>
    /// Assign objects to vars:
    /// </summary>
    void Start()
    {
        //Set player object owner.
            playerObject = GameObject.FindGameObjectWithTag("Player");

        //Default values:
            distanceFromPlayer = 10f;

        //Adjust this object prosition from player (Fixed):
        //TODO: Make dynamic depending on the player object attributes.
            positionTracker = new Vector2(playerObject.transform.localPosition.x, playerObject.transform.localPosition.y + distanceFromPlayer);
            this.transform.localPosition = positionTracker;

    }

}
