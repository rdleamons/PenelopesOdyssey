using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour
{

    public bool goToGame;
    void Start()
    {
        goToGame = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (goToGame)
            SceneManager.LoadScene("ThirdPlayable");
    }
}
