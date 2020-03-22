using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
        //Object declarations:
            GameObject playerObject;

        //Vector declarations:
            Vector2 positionTracker;

        //Float declarations:
            float distanceFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //Default values:
            distanceFromPlayer = 10f;

        //Adjust this object prosition from player:
            positionTracker = new Vector2(playerObject.transform.localPosition.x, playerObject.transform.localPosition.y + distanceFromPlayer);
            this.transform.localPosition = positionTracker;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
