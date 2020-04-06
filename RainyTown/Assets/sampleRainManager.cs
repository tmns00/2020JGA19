using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleRainManager : MonoBehaviour
{
    public static float rainLevel;

    // Start is called before the first frame update
    void Start()
    {
       // rainLevel =5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetLevel()
    {
        return rainLevel;
    }
}
