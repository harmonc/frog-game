using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    private Sprite jumping;
    private Sprite still;
    public GameObject splash;
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    private GameObject aim;
    private AimScript aimScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        spr = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        aim = transform.Find("Aim").gameObject;
        aimScript = transform.GetComponent<AimScript>();
        jumping = GlobalVariablesScript.Instance.jumping;
        still = GlobalVariablesScript.Instance.still;
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
            if (aimScript.onLilyPad)
            {
                transform.parent = aimScript.currPad.transform;
            }
            else {
                GameObject newSplash = Instantiate(splash);
                newSplash.transform.position = transform.position;
                Destroy(this.gameObject);
            }
        }
    }
}
