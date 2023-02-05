using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MusicSlider : MonoBehaviour
{
    public float _musicVolume = default;
   // public float _sfxVolume = default;
    public Slider _musicSlider = default;
  //  public Slider _SfxSlider = default;
    [SerializeField] private AudioSource musicSource /* , SfxSource = default*/;

    void Start()
    {
        GameObject musicObject = GameObject.FindGameObjectWithTag("Music");
        musicSource = musicObject.GetComponent<AudioSource>();
        /* GameObject sfxObject = GameObject.FindGameObjectWithTag("SFX");
         SfxSource = sfxObject.GetComponent<AudioSource>();
        _sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0.5f);
        _SfxSlider.value = _sfxVolume;
        SfxSource.volume = _SfxSlider.value;*/
        _musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        _musicSlider.value = _musicVolume;
        musicSource.volume = _musicSlider.value;
      
    }
    public void ChangeMusicSlider(float value)
    {
        _musicSlider.value = value;
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
        musicSource.volume = _musicSlider.value;
    }

  /*  public void ChangeSfxSlider(float value)
    {
        _SfxSlider.value = value;
        PlayerPrefs.SetFloat("SfxVolume", _SfxSlider.value);
        SfxSource.volume = _SfxSlider.value;
    }*/
}
