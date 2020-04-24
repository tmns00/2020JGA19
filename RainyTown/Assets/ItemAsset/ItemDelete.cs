using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDelete : MonoBehaviour
{
    private ItemManager itemManager;

    // Start is called before the first frame update
    void Start()
    {
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            itemManager.Count();
            Destroy(gameObject);
        }
    }
}
