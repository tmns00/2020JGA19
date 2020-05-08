using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searceSystem : MonoBehaviour
{
    private SphereCollider searce;

    public bool isTracking;

    // Start is called before the first frame update
    void Start()
    {
        searce = GetComponent<SphereCollider>();
    }

    private void Awake()
    {
        isTracking = false;
    }

    // Update is called once per frame
    void Update()
    {
        searce.radius = 4 + RainManager.rainLevel * 1.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isTracking = true;
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.tag == "Untagged")
        //    return;

        if (other.gameObject.tag == "Player")
            isTracking = true;
        //else
        //    isTracking = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isTracking = false;
    }

    public bool GetTrackFlag()
    {
        return isTracking;
    }
}
