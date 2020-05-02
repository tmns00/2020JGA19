using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    int rnd=4;
    public bool iswind = true;
    public Vector3 WindSpeed;
    public int windvec;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RainManager.rainLevel == 3 && iswind)
        {
            rnd = Random.Range(0, 4);
            iswind = false;
        }
        if (RainManager.rainLevel == 2 && !iswind || RainManager.rainLevel == 1 && !iswind)
        {
            iswind = true;
            rnd = 4;
        }
        windvec = rnd;
        switch (rnd)
        {
            case 0:
                WindSpeed = new Vector3(0.05f, 0, 0);
                break;
            case 1:
                WindSpeed = new Vector3(-0.05f, 0, 0);
                break;
            case 2:
                WindSpeed = new Vector3(0, 0, 0.05f);
                break;
            case 3:
                WindSpeed = new Vector3(0, 0, -0.05f);
                break;
            case 4:
                WindSpeed = Vector3.zero;
                break;
        }
        Debug.Log("hhhhhh"+WindSpeed);
    }
}
