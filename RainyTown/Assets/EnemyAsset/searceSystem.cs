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
        searce.radius = 2 + RainManager.rainLevel * 1.0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Untagged")
            return;

        if (other.gameObject.tag == "Player")
            isTracking = true;
        else
            isTracking = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isTracking = false;
    }

    public bool GetTrackFlag()
    {
        return isTracking;
    }
}
