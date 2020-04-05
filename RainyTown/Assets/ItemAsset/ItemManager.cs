using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int needItems;

    [SerializeField]
    private int items;
    private bool isComplete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        items = 0;
        isComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (items >= needItems)
            isComplete = true;

        //Debug.Log(isComplete);
    }

    public void Count()
    {
        items += 1;
    }
}
