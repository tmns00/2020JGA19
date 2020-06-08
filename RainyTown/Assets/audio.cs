using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{

    //public AudioSource[] sounds;

    
    

    // Start is called before the first frame update
    void Start()
    {
        //sounds = GetComponents<AudioSource>();
        //sounds[0].Stop();
        //sounds[1].Stop();
        //sounds[2].Stop();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RainManager.rainLevel == 1)
        {
            //sounds[1].Stop();
            //sounds[2].Stop();
            //sounds[0].Play();
            
        }
        else if (RainManager.rainLevel == 2)
        {
            //sounds[0].Stop();
            //sounds[2].Stop();
            //sounds[1].Play();
        }
        else if (RainManager.rainLevel == 3)
        {
            //sounds[0].Stop();
            //sounds[1].Stop();
            //sounds[2].Play();
        }

        //Debug.Log(RainManager.rainLevel);
    }
}
