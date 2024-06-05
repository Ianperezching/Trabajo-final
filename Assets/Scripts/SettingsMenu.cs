using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;
    public Button backButton;

    private void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChange);
        sfxVolumeSlider.onValueChanged.AddListener(OnSfxVolumeChange);
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChange);
        
    }

    private void OnMasterVolumeChange(float value)
    {
      
        AudioListener.volume = value;
    }

    private void OnSfxVolumeChange(float value)
    {
        
        AudioManager.Instance.SetSfxVolume(value);
    }

    private void OnMusicVolumeChange(float value)
    {
        
        AudioManager.Instance.SetMusicVolume(value);
    }

}
