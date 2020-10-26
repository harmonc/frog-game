using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchScript : MonoBehaviour
{
    public float length = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("2").transform.localPosition = new Vector3(-length/2.0f,0.0f,0.0f);
        transform.Find("3").transform.localPosition = new Vector3(-length, 0.0f, 0.0f);
    }
}
