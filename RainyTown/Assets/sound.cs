using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip[] bgms;

    private float preRain;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        preRain = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (RainManager.rainLevel != preRain)
            PlayBGM();

        preRain = RainManager.rainLevel;
    }

    void PlayBGM()
    {
        audioSource.Stop();
        audioSource.clip = bgms[(int)RainManager.rainLevel - 1];
        audioSource.Play();
    }
}
