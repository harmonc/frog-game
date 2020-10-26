using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject followObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,followObject.transform.position.y,transform.position.z);
    }
}
