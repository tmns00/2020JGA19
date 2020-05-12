using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLight : MonoBehaviour
{
    public GameObject particle;

    private void Update()
    {
        if (ItemManager.isComplete)
            Instantiate(particle, this.transform.position, Quaternion.identity);
    }
}
