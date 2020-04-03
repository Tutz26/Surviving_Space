using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject playerObj;

    Renderer bgRenderer;

    

    public Vector2 bgSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        bgRenderer = this.GetComponent<Renderer>();
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        bgSpeed = new Vector2(playerObj.transform.position.x * Time.deltaTime, playerObj.transform.position.y * Time.deltaTime);
    }

    void Update()
    {

        Vector2 offset = (Vector2) bgSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        this.transform.position = (Vector2) mainCamera.transform.position;
        

    }


}
