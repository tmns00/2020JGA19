using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamplePlayer : MonoBehaviour
{
    //private Vector3 velocity;
    public float moveSpeeed = 2f;
    bool isBoots;
    public bool isAttack;
    public bool isHitAttack;
    Vector3 pos;
    public Transform parent;
    public float STR;
    public float rotateSpeed = 4.0f;
    

    private WeaponManager weaponManager;

    [SerializeField]
    private GameObject playerObject;
    //private Vector3 position = new Vector3();

    private int remains;
    float Y;
    //switchで使う
    private int phaseNum;
    //プレイヤーを動けなくするか？
    bool isNotmove;
    bool isMovedown;
    Rigidbody rb;

    //マンホールテキスト
    public Text manholeText2;
    public Text manholeText3;

    // Start is called before the first frame update
    void Start()
    {
        isBoots = false;
        isNotmove = false;
        isMovedown = false;
        //wind = wind.GetComponent<Wind>();
       

        STR = 5;
        weaponManager = GetComponent<WeaponManager>();
        playerObject = GameObject.Find("protoPlayer");
    }

    private void Awake()
    {
        remains = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RainUIManager.isStart)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (isNotmove == false)
            {
                transform.Translate(
                    new Vector3(h, 0, v) * moveSpeeed * Time.deltaTime);
                Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, 0, 0);
                Quaternion rot = Quaternion.Euler(0, angle.x, 0);
                Quaternion q = transform.rotation;
                transform.rotation = q * rot;
            }

            if(isMovedown==true)
            {
                Movedown();
            }
        }
    }

    public Vector3 playerPosition()
    {
        return transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "water")
        {
            if (RainManager.rainLevel == 3)
            {
                foreach (ContactPoint contact in collision.contacts)
                {
                    //ワールド座標からローカル座標にする。
                    Vector3 relativePoint = transform.InverseTransformPoint(contact.point);

                    //プレイヤーのY座標を取得
                    float y = gameObject.transform.position.y;


                    //プレイヤー中心より下の位置で当たったかどうか。
                    if (contact.point.y > 0.7f)
                    {
                        isMovedown = true;
                    }
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
       

        if (collision.gameObject.tag == "water")
        {
            if (RainManager.rainLevel == 3)
            {
                foreach (ContactPoint contact in collision.contacts)
                {
                    //ワールド座標からローカル座標にする。
                    Vector3 relativePoint = transform.InverseTransformPoint(contact.point);

                    //プレイヤーのY座標を取得
                    float y = gameObject.transform.position.y;


                    //プレイヤー中心より下の位置で当たったかどうか。
                    if (contact.point.y > 0.7f)
                    {
                        isMovedown = true;
                    }
                }
            }
        }

        //マンホールにのっている時
        if(collision.gameObject.tag=="Manhole")
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Vector3 undergroundpoint = GameObject.Find("undergroundpoint").transform.position;
                this.gameObject.transform.position = undergroundpoint;
                Vector3 ManholeExit = GameObject.Find("ManholeExit").transform.position;
                transform.LookAt(ManholeExit);
                manholeText2.gameObject.SetActive(true);
            }
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Muddy")
    //    {
    //        moveSpeeed = 10f;
    //    }
    //}

    private void OnTriggerEnter(Collider col)
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        //地下出口
        if (col.gameObject.tag == "ManholeExit")
        {
            manholeText3.gameObject.SetActive(true);

            int M = Random.Range(0, 4);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (M == 0)
                {
                    Vector3 Manhole = GameObject.Find("Manhole").transform.position;
                    this.gameObject.transform.position = Manhole;
                }
                if (M == 1)
                {
                    Vector3 Manhole = GameObject.Find("Manhole1").transform.position;
                    this.gameObject.transform.position = Manhole;
                }
                if (M == 2)
                {
                    Vector3 Manhole = GameObject.Find("Manhole2").transform.position;
                    this.gameObject.transform.position = Manhole;
                }
                if (M == 3)
                {
                    Vector3 Manhole = GameObject.Find("Manhole3").transform.position;
                    this.gameObject.transform.position = Manhole;
                }

                manholeText3.gameObject.SetActive(false);
            }

            manholeText2.gameObject.SetActive(false);
        }
    }

    //水たまり上の処理
    private void Movedown()
    {
        switch(phaseNum)
        {
            case 0:
                Y = 0;
                phaseNum += 1;
                break;

            case 1:
                rb = GetComponent<Rigidbody>();
                rb.isKinematic = true;
                isNotmove = true;
                transform.Translate(0, Y, 0);
                Y -= 0.001f;
                if(this.gameObject.transform.position.y<=0.2f)
                {
                    phaseNum += 1;
                }
                break;

            case 2:
                Vector3 transpoint = GameObject.Find("transpoint").transform.position;
                this.gameObject.transform.position = transpoint;
                rb.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                isNotmove = false;
                isMovedown = false;
                phaseNum = 0;
                break;
        }
    }

}
