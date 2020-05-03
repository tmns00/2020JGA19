using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searceSystemB : MonoBehaviour
{
    private BoxCollider searceB;
    public bool isTrackingB;

    // Start is called before the first frame update
    void Start()
    {
        searceB = GetComponent<BoxCollider>();
    }

    private void Awake()
    {
        isTrackingB = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTrackingB = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTrackingB = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTrackingB = false;
        }
    }

    public bool GetTrackBFlag()
    {
        return isTrackingB;
    }
}
