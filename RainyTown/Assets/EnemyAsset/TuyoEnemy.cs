using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuyoEnemy : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private float moveSpeed;
    private Vector3 velocity;
    private Vector3 vec;

    [SerializeField]
    private GameObject searchObject;
    [SerializeField]
    private TuyoSearchSystem search;
    [SerializeField]
    private bool isTracking;
  
    private SamplePlayer samplePlayer;

    public GameObject body;
    [SerializeField]
    private EnemyAttackAI attackAI;

    private AudioSource audioSource;
    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        isTracking = false;
        attackAI = body.GetComponent<EnemyAttackAI>();

        audioSource = GetComponent<AudioSource>();
        once = true;
    }

    private void Awake()
    {
        moveSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (player == null || search == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            search = searchObject.GetComponent<TuyoSearchSystem>();
        }

        vec = player.transform.position - body.transform.position;

        if (search.GetTrackFlag() && !attackAI.isAttack)
            Tracking();
        if (!search.GetTrackFlag())
            isTracking = false;

        if (!isTracking)
        {
            velocity = Vector3.zero;
            DeleteAI();
        }

        if (attackAI.isAttack)
        {
            body.transform.Translate(Vector3.zero);
            audioSource.Stop();
            once = true;
        }

        if (!search.GetTrackFlag())
        {
            audioSource.Stop();
            once = true;
        }
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

    private void Tracking()
    {
        Ray ray = new Ray(body.transform.position, (player.transform.position - body.transform.position));
        RaycastHit hit;

        Debug.DrawRay(body.transform.position, ray.direction * 10, Color.red, 10);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                isTracking = true;
                velocity = vec.normalized;
                body.transform.Translate(
                    new Vector3(velocity.x, 0, velocity.z) * moveSpeed * Time.deltaTime);
                PlayBGM();
            }
            else if (hit.collider.tag == "RestPoint")
            {
                isTracking = false;
                body.transform.Translate(Vector3.zero);
                audioSource.Stop();
                once = true;
            }

            return;
        }
    }

    private void DeleteAI()
    {
        if (RainManager.rainLevel == 1)
            Delete();
    }

    private void PlayBGM()
    {
        if (once)
        {
            audioSource.Play();
            once = false;
        }
    }
}
