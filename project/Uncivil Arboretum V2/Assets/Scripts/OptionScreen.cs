using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class OptionScreen : MonoBehaviour
{
    public AudioMixer theMixer;
    public TMP_Text mastLabel, musicLabel;
    public Slider mastSlider, musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        float vol = 0f;
        theMixer.GetFloat("MasterVol", out vol);
        mastSlider.value = vol;
        theMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;

        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
    }

    public void SetMasterVol()
    {
        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();

        theMixer.SetFloat("MasterVol", mastSlider.value);

        PlayerPrefs.SetFloat("MasterVol", mastSlider.value);
    }

    public void SetMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        theMixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
}
