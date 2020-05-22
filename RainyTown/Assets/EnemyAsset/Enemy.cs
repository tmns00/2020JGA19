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

    public SamplePlayer sampleplayer;

    public GameObject body;
    [SerializeField]
    private EnemyAttackAI attackAI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //searceObject = GameObject.Find("SearceObject");
        searce = searceObject.GetComponent<searceSystem>();
        sampleplayer = player.GetComponent<SamplePlayer>();

        attackAI = body.GetComponent<EnemyAttackAI>();
    }

    private void Awake()
    {
        moveSpeed = 4.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vec = player.transform.position - body.transform.position;

        if (searce.GetTrackFlag() && !attackAI.isAttack)
            Tracking();
        else
            velocity = Vector3.zero;

        Debug.Log(searce.GetTrackFlag());
      
        //Debug.Log(player.transform.position);
        //Debug.Log(transform.position);
    }

    private void Tracking()
    {
        Ray ray = new Ray(body.transform.position, (player.transform.position - body.transform.position));
        RaycastHit hit;

        Debug.DrawRay(body.transform.position, ray.direction * 10, Color.red, 10);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player" /*|| hit.collider.tag == "Wall" || hit.collider.tag == "Untagged" || hit.collider.tag == "Item"*/)
            {
                velocity = vec.normalized;
                body.transform.Translate(
                    new Vector3(velocity.x, 0, velocity.z) * moveSpeed * Time.deltaTime);
            }
            else if (hit.collider.tag == "RestPoint")
            {
                body.transform.Translate(Vector3.zero);
            }

            Debug.Log(hit.collider.tag);
            return;
        }
    }
}
