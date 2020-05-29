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
    public Transform parent;
    void Start()
    {
       
        
        var instantiateEffect = GameObject.Instantiate(effectobj[0],transform.position+new Vector3(0,15,0),Quaternion.Euler(90,0,0),parent);
        rnd = 1;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        istime += 1 / 60f;
        if (israin)
        {
            if (istime >= 3)
            {
                //rnd = Random.Range(1, 4);
                if (rnd == 1)
                {
                    rnd = 2;
                }
                else if (rnd == 2)
                {
                    rnd = 3;
                }
                else if (rnd == 3)
                {
                    rnd = 1;
                }
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

                var instantiateEffect = GameObject.Instantiate(effectobj[1], transform.position + new Vector3(0, 15, 0), Quaternion.Euler(90, 0, 0));
               
                if (istime >= 8)
                {
                    
                    israin = true;
                    istime = 0;                  
                }
               

                break;
            case 3:
                instantiateEffect = GameObject.Instantiate(effectobj[2], transform.position + new Vector3(0, 15, 0), Quaternion.Euler(90, 0, 0));
               
                if (istime >= 8)
                {
                  
                    israin = true;
                    istime = 0;
                    
                }
               
                break;
            
        }
    }        //Debug.Log(number);

}
