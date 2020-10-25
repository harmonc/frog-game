using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public Sprite jumping;
    public Sprite still;
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    private GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        spr = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        aim = transform.Find("Aim").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0.5f)
        {
            spr.sprite = jumping;
            aim.SetActive(false);
        }
        else
        {
            spr.sprite = still;
            aim.SetActive(true);
        }
    }
}
