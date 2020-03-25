using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController : MonoBehaviour
{
        public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AnimationEnded()
    {
        Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}
