﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class AimScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 force = new Vector3(-1.0f,0.0f,0.0f);
    private GameObject a;
    private AudioSource fireNoise;
    public bool onLilyPad = true;
    public GameObject currPad;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    void Start()
    {
        a = transform.Find("Aim").gameObject;
        fireNoise = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a.activeInHierarchy)
        {
            Vector2 mouse = Mouse.current.position.ReadValue();
            Vector3 p1 = transform.position;
            Vector3 p2 = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, p1.z));
            p2.z = p1.z;
            float angle = Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * Mathf.Rad2Deg;
            Vector3 dir = new Vector3(0.0f, 0.0f, angle);
            transform.eulerAngles = dir;
            float dist = Vector3.Distance(p1, p2);
            float l = Mathf.Lerp(0, 3, Mathf.InverseLerp(0, 5, dist));
            float aim = Mathf.Clamp(l, 0, 3);
            transform.Find("Aim").GetComponent<StretchScript>().length = aim;
            force = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad + Mathf.PI), Mathf.Sin(angle * Mathf.Deg2Rad + Mathf.PI), 0.0f).normalized * aim;
        }
    }


    void OnFire() {
        if (a.activeInHierarchy) {
            fireNoise.Play();
            transform.GetComponent<Rigidbody2D>().AddForce(force * 1000); //500
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Lilypad"))
        {
            onLilyPad = true;
            currPad = collision.gameObject;
        }
        if (collision.tag.Equals("Fly")) {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = $"Score: {score}";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Lilypad"))
        {
            onLilyPad = false;
        }
    }
}
