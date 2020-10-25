using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 force = new Vector3(-1.0f,0.0f,0.0f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Mouse.current.position.ReadValue();
        Vector3 p1 = transform.position;
        Vector3 p2 = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, p1.z));
        p2.z = p1.z;
        float angle = Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * Mathf.Rad2Deg;
        Vector3 dir = new Vector3(0.0f, 0.0f, angle);
        transform.localEulerAngles = dir;
        float dist = Vector3.Distance(p1,p2);
        float l = Mathf.Lerp(0, 3, Mathf.InverseLerp(0, 5, dist));
        float aim = Mathf.Clamp(l,0,3);
        transform.Find("Aim").GetComponent<StretchScript>().length = aim;
        force = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad + Mathf.PI),Mathf.Sin(angle * Mathf.Deg2Rad + Mathf.PI),0.0f).normalized * aim;
    }


    void OnFire() {
        Debug.Log("Fire");
        transform.GetComponent<Rigidbody2D>().AddForce(force*500);
    }
}
