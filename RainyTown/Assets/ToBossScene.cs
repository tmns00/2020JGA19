using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToBossScene : MonoBehaviour
{
    public Text clearText;

    [SerializeField]
    private float counter = 0;
    [SerializeField]
    private bool flag = false;

    private void FixedUpdate()
    {
        if (flag)
            counter += 0.05f;

        if(counter >= 3)
        {
            clearText.text = "";
            flag = false;
            counter = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (ItemManager.isComplete || other.gameObject.tag == "Player")
        //    SceneManager.LoadScene("ProtoBoss");
        if (ItemManager.isComplete && other.gameObject.tag == "Player")
        {
            //clearText.text = "CLEAR";
            SceneManager.LoadScene("ProtoClear");
        }            
        if (!ItemManager.isComplete && !flag && other.gameObject.tag == "Player")
        {
            flag = true;
            clearText.text = "鍵が足りないようだ…";         
        }
    }
}
