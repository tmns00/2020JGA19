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

    private float HP = 15.0f;
    private bool isDeadFlag;

    public AudioSource audioSource;
 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //searceObject = GameObject.Find("SearceObject");
        searce = searceObject.GetComponent<searceSystem>();
        sampleplayer = player.GetComponent<SamplePlayer>();

        isDeadFlag = false;

        attackAI = body.GetComponent<EnemyAttackAI>();
        //audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        moveSpeed = 4.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDeadFlag)
            Delete();

        if (HP <= 0)
            isDeadFlag = true;
       
        vec = player.transform.position - body.transform.position;
        //body.transform.rotation = Quaternion.Euler(0, Vector3.Angle(transform.up, vec), 0);

        if (searce.GetTrackFlag() && !attackAI.isAttack)
        {
            Tracking();
            audioSource.Play();
        }

        audioSource.Stop();

        Debug.Log(searce.GetTrackFlag());

        if (attackAI.isAttack)
        {
            body.transform.Translate(Vector3.zero);
        }

        //Debug.Log(player.transform.position);
        //Debug.Log(transform.position);
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

    void Die()
    {
        HP -= sampleplayer.STR;
        if (sampleplayer.isHitAttack)
        {
            Debug.Log("aaa");
            //Destroy(gameObject);
        }
    }

    private void Tracking()
    {
        Ray ray = new Ray(body.transform.position, (player.transform.position - body.transform.position));
        RaycastHit hit;

        Debug.DrawRay(body.transform.position, ray.direction * 10, Color.red, 10);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player" || hit.collider.tag == "Wall" || hit.collider.tag == "Untagged" || hit.collider.tag == "Item")
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

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PlayerAttack")
        {
            Die();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Muddy")
        {
            if (RainManager.rainLevel == 2)
            {
                moveSpeed = 2.5f;
            }
            else if (RainManager.rainLevel == 3)
            {
                moveSpeed = 0.5f;
            }
            else
            {
                moveSpeed = 4.5f;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Muddy")
        {
            moveSpeed = 4.5f;
        }
    }
}
