using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider ambienceSlider;
    public Slider sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("set first time volume") == 0) {
            PlayerPrefs.SetInt("set first time volume", 1);
            masterSlider.value = 0.25f;
            musicSlider.value = 0.25f;
            ambienceSlider.value = 0.25f;
            sfxSlider.value = 0.25f;
        }
        else {
            masterSlider.value = PlayerPrefs.GetFloat("Master");
            musicSlider.value = PlayerPrefs.GetFloat("Music");
            ambienceSlider.value = PlayerPrefs.GetFloat("Ambience");
            sfxSlider.value = PlayerPrefs.GetFloat("SFX");
        }
    }

    public void SetMasterVolume() {
        SetVolume("Master", masterSlider.value);
    }

    public void SetMusicVolume() {
        SetVolume("Music", musicSlider.value);
    }

    public void SetAmbienceVolume() {
        SetVolume("Ambience", ambienceSlider.value);
    }

    public void SetSFXVolume() {
        SetVolume("SFX", sfxSlider.value);
    }

    void SetVolume(string name, float value) {
        float volume = Mathf.Log10(value) * 20;
        if(value == 0) {
            volume = -80;
        }

        mixer.SetFloat(name, volume);
        PlayerPrefs.SetFloat(name, value);
    }
}
