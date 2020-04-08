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
    int number=0;
   
    void Start()
    {
       
        
        var instantiateEffect = GameObject.Instantiate(effectobj[0]);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        istime += 1 / 60f;
        if (istime >= 8)
        {
            number = Random.Range(0, 5);
            //number = 4;
            sampleRainManager.rainLevel = number+1;
            Debug.Log(sampleRainManager.rainLevel);
        }

        switch (number)
        {
            case 0:
             
                break;
            case 1:

                var instantiateEffect = GameObject.Instantiate(effectobj[1]);
                if (istime >= 8)
                {
                    Destroy(instantiateEffect, 3);
                    istime = 0;                  
                }


                break;
            case 2:
                instantiateEffect = GameObject.Instantiate(effectobj[2]);
                if (istime >= 8)
                {
                    Destroy(instantiateEffect, 3);                    
                    istime = 0;
                    
                }
                break;
            case 3:
                instantiateEffect = GameObject.Instantiate(effectobj[3]);
                if (istime >= 8)
                {
                    Destroy(instantiateEffect, 3);                   
                    istime = 0;
                    
                }
                break;     
            case 4:
                instantiateEffect = GameObject.Instantiate(effectobj[4]);
                if (istime >= 8)
                {
                    Destroy(instantiateEffect, 3);                   
                    istime = 0;
                   
                }
               
                break;
        }
        
    }
}
