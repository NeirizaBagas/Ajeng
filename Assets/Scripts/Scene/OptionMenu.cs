using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class OptionMenu : MonoBehaviour
{
    public GameObject OptionMenuUI;
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }
    public void ClickToOpt()
    {
        OptionMenuUI.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (OptionMenuUI.activeSelf)
            {
                OptionMenuUI.SetActive(false);
                
            }
        }
    }


}
