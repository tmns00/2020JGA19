using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainStr : MonoBehaviour
{
    // Start is called before the first frame update
    //雨のエフェクト
    [SerializeField]
    private List<ParticleSystem> effectobj;
    //時間
    float istime = 0;
    public static float nextrain=0;
    float number=0;
    bool israin=true;
    float rnd;
    void Start()
    {
       
        
        var instantiateEffect = GameObject.Instantiate(effectobj[0]);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        istime += 1 / 60f;
        if (israin)
        {
            if (istime >= 3)
            {
                rnd = Random.Range(1, 4);
                nextrain = rnd;
                israin = false;
            }
        }
        if(istime>=8)
        {
            number = rnd;
            RainManager.rainLevel = number ;
            nextrain = 4;
        }
        switch (number)
        {
            case 1:
                if (istime >= 8)
                {
                    israin = true;
                    istime = 0;
                }
                break;
            case 2:

                var instantiateEffect = GameObject.Instantiate(effectobj[1]);
               
                if (istime >= 8)
                {
                    
                    israin = true;
                    istime = 0;                  
                }
               

                break;
            case 3:
                instantiateEffect = GameObject.Instantiate(effectobj[2]);
               
                if (istime >= 8)
                {
                  
                    israin = true;
                    istime = 0;
                    
                }
               
                break;
            //case 3:
            //    instantiateEffect = GameObject.Instantiate(effectobj[3]);
            //    if (istime >= 5)
            //    {
            //        Destroy(instantiateEffect, 3);                   
            //        istime = 0;
                    
            //    }
            //    break;     
            //case 4:
            //    instantiateEffect = GameObject.Instantiate(effectobj[4]);
            //    if (istime >= 5)
            //    {
            //        Destroy(instantiateEffect, 3);                   
            //        istime = 0;
                   
            //    }
               
                //break;
        }
        //Debug.Log(number);
    }
}
