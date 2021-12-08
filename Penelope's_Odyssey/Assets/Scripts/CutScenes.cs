using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour
{
    public bool goToGame;
    public bool goToCredits;

    private string current;

    void Start()
    {
        current = SceneManager.GetActiveScene().name;
        goToGame = false;
        goToCredits = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (current == "OpenCut")
                goToGame = true;
            else if (current == "EndCut")
                goToCredits = true;
        }

        if (goToGame)
            SceneManager.LoadScene("ThirdPlayable");

        if (goToCredits)
            SceneManager.LoadScene("CreditScroll");
    }
}
