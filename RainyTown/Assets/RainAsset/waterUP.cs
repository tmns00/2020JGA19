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
        if (RainManager.rainLevel == 3)
        {
            Transform myTransform = this.transform;

            Vector3 pos = myTransform.position;
            pos.y = 0.7f;
            myTransform.position = pos;
        }
    }
}
