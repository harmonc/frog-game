using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    private int lives = 3;
    private Sprite still;
    // Start is called before the first frame update
    void Start()
    {
        still = GlobalVariablesScript.Instance.still;
        health1.GetComponent<Image>().sprite = still;
        health2.GetComponent<Image>().sprite = still;
        health3.GetComponent<Image>().sprite = still;
    }

    // Update is called once per frame
    public void LoseLife() {
        lives--;
        if (lives == 2) {
            health3.SetActive(false);
        }
        if (lives == 1) {
            health2.SetActive(false);
        }
        if (lives == 0) {
            health1.SetActive(false);
        }
    }

    public int GetLives() {
        return lives;
    }
}
