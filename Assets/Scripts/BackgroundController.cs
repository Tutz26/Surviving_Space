using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    public GameObject[] layers;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        foreach(GameObject obj in layers)
        {
            LoadChildObjs(obj);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadChildObjs(GameObject obj)
    {
        // Debug.Log(obj.name);

        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x *2 / objectWidth);
        GameObject bgClone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= childsNeeded; i++)
        {
            GameObject newObj = Instantiate(bgClone) as GameObject;
            newObj.transform.SetParent(obj.transform);
            newObj.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            newObj.name = obj.name + i;
        }
        Destroy(bgClone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void RepositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;

            if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);

            }else if(transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void LateUpdate()
    {
        foreach(GameObject obj in layers)
        {
            RepositionChildObjects(obj);
        }
    }
}
