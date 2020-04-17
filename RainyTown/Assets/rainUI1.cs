using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rainUI1 : MonoBehaviour
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

        if (RainStr.nextrain == 1)
        {
            sprite = Resources.Load<Sprite>("umbrella[0]");
            image = this.GetComponent<Image>();
            image.sprite = sprite;

        }
        if (RainStr.nextrain == 2)
        {
            sprite = Resources.Load<Sprite>("umbrella[1]");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        if (RainStr.nextrain == 3)
        {
            sprite = Resources.Load<Sprite>("umbrella[2]");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        if(RainStr.nextrain==4)
        {
            sprite = Resources.Load<Sprite> ("norain");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
    }
}
