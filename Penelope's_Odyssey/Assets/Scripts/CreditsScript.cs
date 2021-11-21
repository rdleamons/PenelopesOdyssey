using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool goToStart;
    public bool goToGame;
    void Start()
    {
        goToStart = false;
        goToGame = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(goToStart)
            SceneManager.LoadScene(0);

        if (goToGame)
            SceneManager.LoadScene(2);
    }
}
