﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWarning : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), 1.0f, Space.World);
    }
}
