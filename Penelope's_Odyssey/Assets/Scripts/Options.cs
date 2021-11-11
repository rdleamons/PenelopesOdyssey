using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject optMenu;
    public AudioListener audioList;

    // Start is called before the first frame update
    void Start()
    {
        optMenu.SetActive(false);
        audioList.gameObject.SetActive(true);

        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 0.5f);
            LoadVol();
        }
        else LoadVol();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        
        SaveVol();
    }

    private void LoadVol()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    private void SaveVol()
    {
        PlayerPrefs.SetFloat("soundVolume", volumeSlider.value);
    }

    public void ToggleOptions()
    {
        if (optMenu.activeSelf)
        {
            Time.timeScale = 1f;
            optMenu.SetActive(false);
        }
        else
        {
            optMenu.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
        }

    }
}
