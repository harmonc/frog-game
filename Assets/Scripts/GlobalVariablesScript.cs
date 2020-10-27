using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariablesScript : MonoBehaviour
{
    public static GlobalVariablesScript Instance;
    public int test;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

