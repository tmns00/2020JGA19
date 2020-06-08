using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RainUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject rain;
    [SerializeField]
    GameObject telop;
    [SerializeField]
    GameObject title;
    public Text space;
    bool isActive=false;
    bool istelop = false;
    public static bool isStart=false;
    bool isalpha=false;
    float alpha=1;
    float time;
    
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
        }
        if (!isActive)
        {
            rain.SetActive(false);
            telop.SetActive(false);
            title.SetActive(true);
        }
        if (isActive)
        {
            istelop = true;
            title.SetActive(false);
            if (istelop)
            {
                telop.SetActive(true);
                time += 1 / 60f;
                if (time >= 5)
                    istelop = false;
            }
            if (!istelop)
            {
                isStart = true;
                telop.SetActive(false);
                rain.SetActive(true);
            }
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
