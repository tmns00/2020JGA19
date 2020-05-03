using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed=5f;

    private GameObject player;

    private int hp;

    private float rotationSmooth = 1f;

    private Vector3 pposi;

    private bool ac;

    float istime = 0;


    private float rnd;

    private Vector3 velocity;

    private Vector3 vec;


    [SerializeField]
    private GameObject searceObject;
    [SerializeField]
    private searceSystemB searceB;

    private bool isTPosition = false;

    private Vector3 tratgetPosition;

    public float XMINMR = -50;

    public float XMAXMR = 30;

    public float ZMINMR = -50;

    public float ZMAXMR = 30;

    public float speed2;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hp = 100;
        ac = false;
        searceB = searceObject.GetComponent<searceSystemB>();

        speed2 = 0.1f;
    }

    private void Awake()
    {
        speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        vec = player.transform.position - transform.position;

        istime += 1 / 60f;


        pposi = player.transform.position;

        rnd = Random.Range(1, 5);

        if (searceB.GetTrackBFlag())
        {
            Tracking();
            istime = 0;
        }
        else if (searceB.GetTrackBFlag() == false && istime < 3)
        {           
            velocity = Vector3.zero;
        }
        else if (searceB.GetTrackBFlag() == false && istime > 3)
        {
            TargetPosition();
            transform.position = Vector3.MoveTowards(transform.position, tratgetPosition, speed2);
            if(transform.position== tratgetPosition)
            {
                isTPosition = true;
            }
        }




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
                    new Vector3(velocity.x, 0, velocity.z) * speed * Time.deltaTime);
            }
            else if (hit.collider.tag == "RestPoint")
            {
                transform.Translate(Vector3.zero);
            }

            return;
        }
    }


    private void TargetPosition()
    {
        if (!isTPosition)
        {
            return;
        }

        tratgetPosition = new Vector3(Random.Range(XMINMR, XMAXMR), 1, Random.Range(ZMINMR, ZMAXMR));
        isTPosition = false;
    }

}
