using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLight : MonoBehaviour
{
    public GameObject particle;

    private bool once = true;

    private void Update()
    {
        if (ItemManager.isComplete && once)
            Create();
    }

    private void Create()
    {
        once = false;
        Instantiate(particle, this.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
    }
}
