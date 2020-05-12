using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuyoSearchSystem : MonoBehaviour
{
    private SphereCollider search;

    public bool isTracking;

    public Transform eneTrans;

    // Start is called before the first frame update
    void Start()
    {
        search = GetComponent<SphereCollider>();
    }

    private void Awake()
    {
        isTracking = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = eneTrans.position;
        //searce.radius = 4 * RainManager.rainLevel * 1.5f;
        transform.localScale = new Vector3(10, 10, 10) + RainManager.rainLevel * Vector3.one * 3.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isTracking = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isTracking = true;
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
