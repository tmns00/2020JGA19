﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public float moveSpeed = 5.0f;
    private Vector3 velocity;
    private Vector3 vec;

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
        //moveSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    { 
        vec = player.transform.position - transform.position;

        if (searce.GetTrackFlag()/* && player != null*/)
            Tracking();
        else
            velocity = Vector3.zero;

        //Debug.Log(searce.GetTrackFlag());
    }

    private void Tracking()
    {
        Ray ray = new Ray(transform.position, player.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player" || hit.collider.tag == "Wall" || hit.collider.tag == "Untagged")
            {
                velocity = vec.normalized;
                transform.Translate(
                    new Vector3(velocity.x, 0, velocity.z) * moveSpeed * Time.deltaTime);
            }
            else if (hit.collider.tag=="RestPoint")
            {
                transform.Translate(Vector3.zero);
            }

            //Debug.Log(hit.collider.tag);
            return;
        }

    }
}
