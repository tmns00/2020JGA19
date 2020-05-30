using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public FadeOut reset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RainUIManager.isStart = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey(KeyCode.Space)&&reset.isReset)
        {
            RainUIManager.isStart = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
