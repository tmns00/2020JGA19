using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer : MonoBehaviour
{
    //private Vector3 velocity;
    public float moveSpeeed = 2f;
    [SerializeField]
    public Wind wind;
    //private Vector3 position = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        wind = wind.GetComponent<Wind>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(
            new Vector3(h, 0, v) * moveSpeeed *Time.deltaTime-wind.WindSpeed);
        Debug.Log(wind.WindSpeed);
    }

    public Vector3 playerPosition()
    {
        return transform.position;
    }
}
