using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterUP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        

        if (RainManager.rainLevel == 3)
        {           
            pos.y =-0.2f;
            myTransform.position = pos;
        }
        else
        {
            pos.y = -0.48f;
            myTransform.position = pos;
        }
    }
}
