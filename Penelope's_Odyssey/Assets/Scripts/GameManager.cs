using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Tooltip("Root GameObject of the menu used to toggle its activation")]
    public GameObject MenuRoot;

    // Need to add win condition to this script -- currently, it's in loadScene. 
    public float hunger = 100;
    public float sub = 1;
    public int subDivisor = 3000000;
    public Slider HungerBar;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI winText;

    public bool paused;
    //public Movement movement;

    private void Start()
    {
        MenuRoot.SetActive(false);
        loseText.enabled = false;
        winText.enabled = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (MenuRoot.activeSelf)
        {
            getHunger();
            UpdateScreen();
        }
        else
        {
            changeHunger();
            UpdateScreen();
        }


        // Show cursor in menus
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            SetPauseMenuActivation(!MenuRoot.activeSelf);
        }

    }

    public float getHunger()
    {
        return hunger;
    }

    public float changeHunger()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            hunger -= sub / (subDivisor * 10000);
        }
        else
            hunger -= sub / subDivisor;
        
        //hunger -= sub / subDivisor;
        return hunger;
    }

    public void UpdateScreen()
    {
        HungerBar.value = hunger;
    }

    public void ClosePauseMenu()
    {
        SetPauseMenuActivation(false);
    }

    void SetPauseMenuActivation(bool active)
    {
        MenuRoot.SetActive(active);

        if (MenuRoot.activeSelf)
        {
            Cursor.visible = true;
            Time.timeScale = 0f;
            paused = true;

            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            Cursor.visible = false;
            Time.timeScale = 1f;
            paused = false;
        }

    }

}
