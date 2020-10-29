using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnable;
    public Vector2 range;
    public float t;
    private float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > t) {
            timer = 0;
            GameObject spawned = Instantiate(spawnable);
            spawned.transform.position = transform.position;
            spawned.transform.position += new Vector3(0.0f,Random.Range(range.x,range.y),0.0f);
        }
    }
}
