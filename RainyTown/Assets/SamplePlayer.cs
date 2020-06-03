using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        isBoots = false;
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

            transform.Translate(
                new Vector3(h, 0, v) * moveSpeeed * Time.deltaTime);
            Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, 0, 0);
            Quaternion rot = Quaternion.Euler(0, angle.x, 0);
            Quaternion q = transform.rotation;
            transform.rotation = q * rot;

            //長靴を取得した時、水たまりを通れるように変更
            if (isBoots == true)
            {
                int playerCol = LayerMask.NameToLayer("Player");
                int waterCol = LayerMask.NameToLayer("Water");
                Physics.IgnoreLayerCollision(playerCol, waterCol);
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
                        Vector3 transpoint = GameObject.Find("transpoint").transform.position;
                        this.gameObject.transform.position = transpoint;
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
                        Vector3 transpoint = GameObject.Find("transpoint").transform.position;
                        this.gameObject.transform.position = transpoint;
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
        //長靴を取得
        if (col.gameObject.tag == "Boots")
        {
            isBoots = true;
        }


        //地下出口
        if(col.gameObject.tag=="ManholeExit")
        {
            int M = Random.Range(0, 4);
            if(M==0)
            {
                Vector3 Manhole = GameObject.Find("Manhole").transform.position;
                this.gameObject.transform.position = Manhole;
            }
            if(M==1)
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
        }
    }
   

}
