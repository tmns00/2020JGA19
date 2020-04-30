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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        search = searchObject.GetComponent<TuyoSearchSystem>();
    }

    private void Awake()
    {
        moveSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        vec = player.transform.position - transform.position;

        if (search.GetTrackFlag())
            Tracking();
        else
        {
            velocity = Vector3.zero;
            DeleteAI();
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
                    new Vector3(velocity.x, 0, velocity.z) * moveSpeed * Time.deltaTime);
            }
            else if (hit.collider.tag == "RestPoint")
            {
                transform.Translate(Vector3.zero);
            }

            return;
        }
    }

    private void DeleteAI()
    {
        if (RainManager.rainLevel != 3)
            Destroy(gameObject);
    }
}
