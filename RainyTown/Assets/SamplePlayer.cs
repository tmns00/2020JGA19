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
    public Wind wind;
    public attackgage Attackgage;
    public Transform parent;
    public float STR;
    public float rotateSpeed = 4.0f;

    private Rigidbody rb;
    private WeaponManager weaponManager;

    [SerializeField]
    private GameObject playerObject;
    //private Vector3 position = new Vector3();

    private int remains;
    //水たまりの処理に使う
    private int phaseNum;
    float Y;

    //水たまりを貫通するかどうか？
    bool isPuddlethrough;
    //動かなくするかどうか？
    bool isNotmove;
    //水たまり落ちる？
    bool isMovedown;


    // Start is called before the first frame update
    void Start()
    {
        isBoots = false;
        isNotmove = false;
        isPuddlethrough = false;
        isMovedown = false;
        
        //wind = wind.GetComponent<Wind>();
        Attackgage = Attackgage.GetComponent<attackgage>();

        STR = 5;
        weaponManager = GetComponent<WeaponManager>();
        playerObject = GameObject.Find("protoPlayer");
        phaseNum = 0;
    }

    private void Awake()
    {
        remains = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
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

        //長靴を取得した時、水たまりを通れるように変更
        if (isBoots == true)
        {
            Puddlethrough();
        }
        Attack();

        if(isMovedown==true)
        {
            Movedown();
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
        //if (collision.gameObject.tag == "Muddy")
        //{
        //    if (RainManager.rainLevel == 2)
        //    {
        //        moveSpeeed = 5f;
        //    }
        //    else if (RainManager.rainLevel == 3)
        //    {
        //        moveSpeeed = 0.5f;
        //    }
        //    else
        //    {
        //        moveSpeeed = 10f;
        //    }
        //}

        

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
    private void Attack()
    {
        if (Input.GetKey(KeyCode.Space) && !isAttack)
            isAttack = true;

        if (isAttack)
        {
            Attackgage.gage -= 0.7f;
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                GameObject obj = (GameObject)Resources.Load("AttackHitBox");
                Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, parent);
                isHitAttack = true;
            }

            if (Attackgage.gage <= 0)
            {
                isHitAttack = false;
                Attackgage.gage = 0;
                isAttack = false;

            }

        }
    }

    private void Puddlethrough()
    {
          int playerCol = LayerMask.NameToLayer("Player");
          int waterCol = LayerMask.NameToLayer("Water");
          Physics.IgnoreLayerCollision(playerCol, waterCol);
        
    }

    private void Movedown()
    {
        switch (phaseNum)
        {
            case 0:
                Y = 0;
                phaseNum += 1;
                break;

            case 1:
                //プレイヤーの移動制限
                rb = GetComponent<Rigidbody>();
                rb.isKinematic = true;
                isNotmove = true;

                transform.Translate(0, Y, 0);
                Y -= 0.001f;

                if (this.gameObject.transform.position.y<=-0.7f)
                {
                    phaseNum += 1;
                }
                break;

            case 2:
                Vector3 transpoint = GameObject.Find("transpoint").transform.position;
                this.gameObject.transform.position = transpoint;
                phaseNum = 0;
                rb.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                isNotmove = false;
                isMovedown = false;
                break;
        }
    }

}
