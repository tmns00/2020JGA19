using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBossScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (ItemManager.isComplete || other.gameObject.tag == "Player")
            SceneManager.LoadScene("ProtoBoss");
    }
}
