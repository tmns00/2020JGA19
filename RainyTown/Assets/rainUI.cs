using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rainUI : MonoBehaviour
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
      
        if (RainManager.rainLevel == 1)
        {
            sprite = Resources.Load<Sprite>("umbrella[0]");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
            
        }
        if (RainManager.rainLevel == 2)
        {
            sprite = Resources.Load<Sprite>("umbrella[1]");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        if (RainManager.rainLevel == 3)
        {
            sprite = Resources.Load<Sprite>("umbrella[2]");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
    }
}
