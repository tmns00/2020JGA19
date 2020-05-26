using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int needItems;

    [SerializeField]
    private int items;
    public static bool isComplete;

    public UnityEngine.UI.Text itemcount;

    public AudioClip getse;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        items = 0;
        isComplete = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (items >= needItems)
            isComplete = true;

        //Debug.Log(isComplete);

        itemcount.text = items.ToString();
    }

    public void Count()
    {
        items += 1;
        audioSource.PlayOneShot(getse);
    }


}
