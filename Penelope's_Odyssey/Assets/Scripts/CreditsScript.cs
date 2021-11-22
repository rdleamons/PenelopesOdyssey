using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public bool goToStart;

    void Start()
    {
        goToStart = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            goToStart = true;

        if(goToStart)
            SceneManager.LoadScene("StartScreen");
    }
}
