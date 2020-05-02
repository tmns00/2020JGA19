using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class attackgage : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider atkg;
    public  float gage;
    public SamplePlayer player;
    void Start()
    {
        atkg = GetComponent<Slider>();
        player = player.GetComponent<SamplePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        atkg.value = gage;
        if (RainManager.rainLevel == 3&&!player.isAttack)
        {
            gage += 0.5f;
        }
        if (RainManager.rainLevel == 2 && !player.isAttack)
        {
            gage += 0.1f;
        }
        if (RainManager.rainLevel == 1 && !player.isAttack)
        {
            gage += 0.05f;
        }
        if(gage>=100)
        {
            gage = 100;
        }
    }
}
