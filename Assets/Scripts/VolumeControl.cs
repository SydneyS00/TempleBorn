using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    //This acts as the slider control//
    [SerializeField] string _volumeParameter = "MusicVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier = 30f;
    [SerializeField] private Toggle _toggle;
    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }
    private void HandleSliderValueChanged(float value)
    {
        _mixer.SetFloat(_volumeParameter, value: Mathf.Log10(value) * _multiplier);
    }

    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }
}
