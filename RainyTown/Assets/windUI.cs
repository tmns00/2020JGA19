using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class windUI : MonoBehaviour
{
    public Image image;
    Sprite sprite;
    float angle;
    public Wind wind;
    // Start is called before the first frame update
    void Start()
    {
        wind = wind.GetComponent<Wind>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("wind" + wind.iswind);
        if (wind.windvec == 0)
        {
            sprite = Resources.Load<Sprite>("wind (2)");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
            angle = Mathf.LerpAngle(0, -180, Time.time);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        if (wind.windvec == 1)
        {
            sprite = Resources.Load<Sprite>("wind (2)");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
            angle = Mathf.LerpAngle(0, 0, Time.time);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        if (wind.windvec == 2)
        {
            sprite = Resources.Load<Sprite>("wind (2)");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
            angle = Mathf.LerpAngle(0, -90, Time.time);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        if (wind.windvec == 3)
        {
            sprite = Resources.Load<Sprite>("wind (2)");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
            angle = Mathf.LerpAngle(0, 90, Time.time);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        if (wind.windvec == 4)
        {
            sprite = Resources.Load<Sprite>("norain");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
    }
}
