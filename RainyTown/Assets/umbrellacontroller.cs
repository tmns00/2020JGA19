using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umbrellacontroller : MonoBehaviour
{
    public sampleRainManager rain;
    public SamplePlayer playercontroller;
    AudioSource audioSource;

    private bool umbrellatrigger;

    private float raincount;

    // Start is called before the first frame update
    void Start()
    {
        umbrellatrigger = true;
        raincount = rain.GetLevel();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (umbrellatrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                umbrellatrigger = false;
                audioSource.Stop();
            }
        }
        else if (umbrellatrigger == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                umbrellatrigger = true;
                audioSource.Play();
            }
        }

        transform.position = playercontroller.playerPosition();
    }
}
