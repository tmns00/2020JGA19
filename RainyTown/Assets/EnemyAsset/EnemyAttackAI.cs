using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAI : MonoBehaviour
{
    public bool isAttack;
    private float count;
    public float notMoveTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttack)
        {
            count += Time.deltaTime;
        }

        if(count>=notMoveTime)
        {
            count = 0;
            isAttack = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            isAttack = true;
        }
    }

    public bool IsAttack()
    {
        return isAttack;
    }
}
