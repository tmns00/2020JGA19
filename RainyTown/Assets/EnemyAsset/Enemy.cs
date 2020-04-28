using System.Collections;
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
        //searceObject = GameObject.Find("SearceObject");
        searce = searceObject.GetComponent<searceSystem>();       
    }

    private void Awake()
    {
        moveSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    { 
        vec = player.transform.position - transform.position;

        if (searce.GetTrackFlag()/* && player != null*/)
            Tracking();
        else
            velocity = Vector3.zero;

        Debug.Log(searce.GetTrackFlag());
        //Debug.Log(player.transform.position);
        //Debug.Log(transform.position);
    }

    private void Tracking()
    {
        Ray ray = new Ray(transform.position, (player.transform.position - transform.position));
        RaycastHit hit;

        Debug.DrawRay(transform.position, ray.direction * 10, Color.red, 10);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player" || hit.collider.tag == "Wall" || hit.collider.tag == "Untagged" || hit.collider.tag == "Item")
            {
                velocity = vec.normalized;
                transform.Translate(
                    new Vector3(velocity.x, 0, velocity.z) * moveSpeed * Time.deltaTime);
            }
            else if (hit.collider.tag=="RestPoint")
            {
                transform.Translate(Vector3.zero);
            }

            Debug.Log(hit.collider.tag);
            return;
        }       
    }
}
