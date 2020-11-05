using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovementScript : MonoBehaviour
{
    public Vector3 speed;
    private bool goingUp = false;
    private void Start()
    {
        goingUp = Random.Range(0.0f,1.0f)>0.5f;
    }
    // Update is called once per frame
    void Update()
    {

        if (goingUp)
        {
            speed.y = -1;
        }
        else {
            speed.y = 1;
        }
        if (transform.Find("Player") != null)
        {
            speed.y = 0;
        }
        if (transform.position.y > 5)
        {
            goingUp = true;
        }
        else if (transform.position.y < -5) {
            goingUp = false;
        }
        transform.position += speed * Time.deltaTime;
    }
}
