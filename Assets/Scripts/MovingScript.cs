using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    private Sprite jumping;
    public GameObject gameOver;
    private Sprite still;
    public GameObject splash;
    public GameObject health;

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
        if (transform.position.x <= -16.0f) {
            gameOver.SetActive(true);
            Destroy(this.gameObject);
        }

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
                HealthScript h = health.GetComponent<HealthScript>();
                h.LoseLife();
                if (h.GetLives() > 0)
                {
                    transform.position = new Vector3(transform.parent.position.x,transform.parent.position.y, transform.position.z);
                    transform.GetComponent<AimScript>().onLilyPad = true;
                }
                else {
                    Destroy(this.gameObject);
                    gameOver.SetActive(true);
                }
            }
        }
    }
}
