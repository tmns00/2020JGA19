using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RainManager.rainLevel == 1)
        {
            GameObject srain = transform.Find("BGMs").gameObject;
            audioSource = srain.GetComponent<AudioSource>();
            audioSource.Play();
        }
        else if (RainManager.rainLevel == 2)
        {
            GameObject mrain = transform.Find("BGMm").gameObject;
            audioSource = mrain.GetComponent<AudioSource>();
            audioSource.Play();
        }
        else if (RainManager.rainLevel == 3)
        {
            GameObject brain = transform.Find("BGMb").gameObject;
            audioSource = brain.GetComponent<AudioSource>();
            audioSource.Play();
        }
    }
}
