using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rainUI1 : MonoBehaviour
{
    public Image image;
    private Sprite sprite;
    float time;
    float alpha = 1;
    bool isalpha=true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        Time();
        if (RainStr.nextrain == 1)
        {
           
            sprite = Resources.Load<Sprite>("umbrella[0]");
            image = this.GetComponent<Image>();
            image.sprite = sprite; 
            image.color = new Color(1, 1, 1, alpha);

        }
        if (RainStr.nextrain == 2)
        {
            sprite = Resources.Load<Sprite>("umbrella[1]");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
            image.color = new Color(1, 1, 1, alpha);
        }
        if (RainStr.nextrain == 3)
        {
            sprite = Resources.Load<Sprite>("umbrella[2]");
            image = this.GetComponent<Image>();
            image.sprite = sprite;    
            image.color = new Color(1, 1, 1, alpha);
        }
        if(RainStr.nextrain==4)
        {
            sprite = Resources.Load<Sprite> ("norain");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
            image.color = new Color(1, 1, 1, alpha);
        }
    }
    void Time()
    {
        time += 1 / 60f;
        if (RainStr.istime >= 5)
        {
            if (alpha >= 1)
                isalpha = true;
            if (alpha <= 0)
                isalpha = false;
            if (isalpha)
                alpha -= 0.08f;
            if (!isalpha)
                alpha += 0.08f;
        }
        if (RainStr.istime >= 8)
        {
            alpha = 1;
        }
    }
}
