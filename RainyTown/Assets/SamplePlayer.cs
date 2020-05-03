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

    GameObject StoneSword;
    GameObject GoldSword;
    GameObject Excalibur;

    private WeaponManager weaponManager;
    //private Vector3 position = new Vector3();

    private int remains;

    // Start is called before the first frame update
    void Start()
    {
        isBoots = false;
        wind = wind.GetComponent<Wind>();
        Attackgage = Attackgage.GetComponent<attackgage>();

        STR = 5;
        weaponManager = GetComponent<WeaponManager>();
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

        transform.Translate(
            new Vector3(h, 0, v) * moveSpeeed * Time.deltaTime-wind.WindSpeed);

        //長靴を取得した時、水たまりを通れるように変更
        if(isBoots==true)
        {
            int playerCol = LayerMask.NameToLayer("Player");
            int waterCol = LayerMask.NameToLayer("Water");
            Physics.IgnoreLayerCollision(playerCol, waterCol);
        }
        Attack();
       
    }

    public Vector3 playerPosition()
    {
        return transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Muddy")
        {
            if (RainManager.rainLevel == 2)
            {
                moveSpeeed = 5f;
            }
            else if (RainManager.rainLevel == 3)
            {
                moveSpeeed = 0.5f;
            }
            else
            {
                moveSpeeed = 10f;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Muddy")
        {
            moveSpeeed = 10f;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        //長靴を取得
        if(col.gameObject.tag=="Boots")
        {
            isBoots = true;
        }

        if(col.gameObject.tag=="StoneSword")
        {
            StoneSword = GameObject.Find("StoneSword");
            weaponManager = StoneSword.GetComponent<WeaponManager>();
            STR = weaponManager.GetAttackPower();
        }

        if (col.gameObject.tag == "GoldSword")
        {
            GoldSword = GameObject.Find("StoneSword");
            weaponManager = GoldSword.GetComponent<WeaponManager>();
            STR = weaponManager.GetAttackPower();
        }

        if (col.gameObject.tag == "Excalibur")
        {
            Excalibur = GameObject.Find("Excalibur");
            weaponManager = Excalibur.GetComponent<WeaponManager>();
            STR = weaponManager.GetAttackPower();
        }
    }
    private void Attack()
    {
        if (Input.GetKey(KeyCode.Space)&&!isAttack)
            isAttack = true;

        if(isAttack)
        {
            Attackgage.gage -= 0.7f;
            if(Input.GetKeyDown(KeyCode.RightShift))
            {
                GameObject obj = (GameObject)Resources.Load("AttackHitBox");
                Instantiate(obj,transform.position , Quaternion.identity,parent);
                isHitAttack = true;
            }
         
            if(Attackgage.gage<=0)
            {
                isHitAttack = false;
                Attackgage.gage = 0;
                isAttack = false;
               
            }
        
        }
    }
    
}
