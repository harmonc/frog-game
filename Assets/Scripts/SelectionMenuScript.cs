using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectionMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Skin[] skins;
    public int selected = 0;
    private Image img;
    public GlobalVariablesScript vars;
    private void Start()
    {
        img = transform.Find("Image").GetComponent<Image>();
        img.sprite = skins[selected].still;
    }

    public void leftButton() {
        selected--;
        if (selected < 0) {
            selected = skins.Length - 1;
        }
        img.sprite = skins[selected].still;
    }

    public void rightButton() {
        selected = (selected + 1) % skins.Length;
        img.sprite = skins[selected].still;
    }

    public void backButton() {
        vars.jumping = skins[selected].jumping;
        vars.still = skins[selected].still;
    }
}
[System.Serializable]
public class Skin
{
    public Sprite jumping;
    public Sprite still;
}