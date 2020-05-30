using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDelete : MonoBehaviour
{
    private int remains;

    [SerializeField]
    private bool isInvicible;
    [SerializeField]
    GameObject Fadeout;
    private float countTime;
    private float limit;

    public Renderer renderer;
    private float nextTime;
    private float interval;
   
    public UnityEngine.UI.Text stockcount;

    // Start is called before the first frame update
    void Start()
    {
        isInvicible = false;
        limit = 3.0f;

        nextTime = Time.time;
        interval = 1.0f;
    }

    private void Awake()
    {
        remains = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (remains <= 0)
        {
            Fadeout.SetActive(true);
        }
       
           // Destroy(gameObject);
        if (countTime >= limit)
        {
            countTime = 0;
            isInvicible = false;
            renderer.enabled = true;
        }

        if (isInvicible)
        {
            countTime += Time.deltaTime;        

            //if(countTime>=limit)
            //{
            //    countTime = 0;
            //    isInvicible = false;
            //    renderer.enabled = true;
            //}

            if(Time.time>nextTime)
            {
                renderer.enabled = !renderer.enabled;

                nextTime += interval;
            }
        }

        stockcount.text = remains.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss") && !isInvicible)
        {
            isInvicible = true;
            remains -= 1;
        }
    }
}
