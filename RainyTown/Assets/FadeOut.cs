using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeOut : MonoBehaviour
{
    public float speed = 0.01f;
    float alfa;
    float red, green, blue;
    [SerializeField]
    GameObject GameOver;
    public bool isReset = false;
    // Start is called before the first frame update
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        isReset = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += speed;
        if (alfa >= 1)
        {
            isReset = true;
            GameOver.SetActive(true);
        }  
    }
}
