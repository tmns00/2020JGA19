using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RainUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject rain;
    [SerializeField]
    GameObject title;
    public Text space;
    bool isActive=false;
    public static bool isStart=false;
    bool isalpha=false;
    float alpha=1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isActive = true;
            isStart = true;
          
        }
        if (!isActive)
        {
            rain.SetActive(false);
            title.SetActive(true);
        }
        if (isActive)
        {
            rain.SetActive(true);
            title.SetActive(false);
        }
        space.color = new Color(1, 1, 1, alpha);
        if (alpha >= 1)
            isalpha = true;
        if (alpha <= 0)
            isalpha = false;
        if(isalpha)
            alpha -= 0.05f;
        if(!isalpha)
            alpha += 0.05f;

    }
}
