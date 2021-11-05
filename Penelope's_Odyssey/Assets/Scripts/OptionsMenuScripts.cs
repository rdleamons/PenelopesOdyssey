using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class OptionsMenuScripts : MonoBehaviour
{
    [Tooltip("Root GameObject of the menu used to toggle its activation")]
    public GameObject MenuRoot;


   public AudioSource MyAudioSource;
    //Value from the slider, and it converts to volume level
   public float VolumeSliderValue;
    public Camera cam;

    void Start()
    {
        MenuRoot.SetActive(false);

        //Initiate the Slider value to half way
        VolumeSliderValue = 0.5f;
        //Fetch the AudioSource from the GameObject
        MyAudioSource = cam.GetComponent<AudioSource>();
         
        //Play the AudioClip attached to the AudioSource on startup
        MyAudioSource.Play();
    }

    void OnGUI()
    {
        MyAudioSource.volume = VolumeSliderValue;
    }


    public void CloseOptionsMenu()
    {
        SetOptionsMenuActivation(false);
    }
    public void OpenOptionsMenu()
    {
        SetOptionsMenuActivation(true);
    }


    void SetOptionsMenuActivation(bool active)
    {
        MenuRoot.SetActive(active);

        if (MenuRoot.activeSelf)
        {
            Cursor.visible = true;
            Time.timeScale = 0f;

            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            Time.timeScale = 1f;
        }

    }








    // Update is called once per frame
    void Update()
    {
        if (!MenuRoot.activeSelf && Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;
        }


    }
}
