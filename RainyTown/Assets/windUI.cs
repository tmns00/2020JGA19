using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class windUI : MonoBehaviour
{
    public Image image;
    private Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 0, 0));
    }
}
