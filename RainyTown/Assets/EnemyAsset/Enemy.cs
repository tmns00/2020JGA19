using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public float moveSpeed;
    private Vector3 velocity;

    [SerializeField]
    private GameObject searceObject;
    [SerializeField]
    private searceSystem searce;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        searceObject = GameObject.Find("SearceObject");
        searce = searceObject.GetComponent<searceSystem>();
    }

    private void Awake()
    {
        moveSpeed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            new Vector3(velocity.x, 0, velocity.z) * moveSpeed * Time.deltaTime);

        if (searce.GetTrackFlag() && player != null)
            Tracking();
        else
            velocity = Vector3.zero;

        //Debug.Log(searce.GetTrackFlag());
    }

    private void Tracking()
    {
        Vector3 vec = player.transform.position - transform.position;
        velocity = vec.normalized;
    }
}
