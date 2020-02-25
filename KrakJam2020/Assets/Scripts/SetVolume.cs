using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour{
	public AudioMixer mixer;
	public Slider masterSlider;
	public Slider musicSlider;
	public Slider playerSlider;
	public Slider fxSlider;

	void Start(){
		masterSlider.value = PlayerPrefs.GetFloat("masterVol", 0.75f);
		musicSlider.value = PlayerPrefs.GetFloat("musicVol", 0.75f);
		playerSlider.value = PlayerPrefs.GetFloat("playerVol", 0.75f);
		fxSlider.value = PlayerPrefs.GetFloat("fxVol", 0.75f);
	}

	public void SetMasterLevel(float sliderValue){
		mixer.SetFloat("masterVol", Mathf.Log10(sliderValue) * 20);
		PlayerPrefs.SetFloat("masterVol", sliderValue);
	}

	public void SetMusicLevel(float sliderValue){
		mixer.SetFloat("musicVol", Mathf.Log10(sliderValue) * 20);
		PlayerPrefs.SetFloat("musicVol", sliderValue);
	}

	public void SetPlayerLevel(float sliderValue){
		mixer.SetFloat("playerVol", Mathf.Log10(sliderValue) * 20);
		PlayerPrefs.SetFloat("playerVol", sliderValue);
	}

	public void SetFxLevel(float sliderValue){
		mixer.SetFloat("fxVol", Mathf.Log10(sliderValue) * 20);
		PlayerPrefs.SetFloat("fxVol", sliderValue);
	}
}