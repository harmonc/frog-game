using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Skin[] skins;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Skin
{
    public Sprite jumping;
    public Sprite still;
}