﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovementScript : MonoBehaviour
{
    public Vector3 speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime;
    }
}