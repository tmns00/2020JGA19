﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWindowSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false, 30);
    }

}
