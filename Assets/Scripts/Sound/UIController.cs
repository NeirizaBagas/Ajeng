using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public void ToggleMusic()
    {
        Lvl1AudioManager.instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        Lvl1AudioManager.instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        Lvl1AudioManager.instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        Lvl1AudioManager.instance.SFXVolume(_sfxSlider.value);
    }
}
