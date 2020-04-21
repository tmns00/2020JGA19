using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manhole : MonoBehaviour
{
    private Rigidbody myRigid;
    private Rigidbody playerRigid;

    [SerializeField]
    private bool isSplash;
    [SerializeField]
    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        isSplash = false;
        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSplash && once)
            Splash();

        if (RainManager.rainLevel == 3)
            isSplash = true;
        else
        {
            isSplash = false;
            once = true;
        }

        Debug.Log(RainManager.rainLevel);
    }

    private void Splash()
    {
        once = false;
        myRigid.AddForce(new Vector3(0.1f, 5.5f, 0.0f), ForceMode.Impulse);
        myRigid.AddTorque(Vector3.forward, ForceMode.Impulse);

        if (playerRigid == null)
            return;
        playerRigid.AddForce(new Vector3(0.0f, 15.0f, 0.0f), ForceMode.Impulse);       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            playerRigid = collision.rigidbody;
    }

    private void OnCollisionExit(Collision collision)
    {
            playerRigid = null;
    }
}
