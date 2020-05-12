using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    public GameObject tuyoEnemy;
    private List<GameObject> childPosList;

    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        childPosList = new List<GameObject>();
        childPosList.Clear();
        for(int i=0;i<transform.childCount;i++)
        {
            childPosList.Add(transform.GetChild(i).gameObject);
        }

        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (RainManager.rainLevel >= 2 && once)
            CreateObj();
        else if (RainManager.rainLevel == 1)
            once = true;
    }

    private void CreateObj()
    {
        once = false;

        foreach (var obj in childPosList)
            Instantiate(tuyoEnemy, obj.transform.position, Quaternion.identity);
    }
}
