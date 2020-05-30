using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngle : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > 2.0f)
            Transform();
    }
    void Transform()
    {
        if (RainUIManager.isStart)
        {
            transform.position -= new Vector3(0, 0.2f, 0);
        }
    }

}

