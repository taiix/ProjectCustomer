using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip[] clip;

    
    public Slider volumeSlider;

    public float musicVolValue ;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicVolValue = InstanceManager.instance.musicValue;
        volumeSlider.value = musicVolValue;
    }

    private void Update()
    {


    }

    void OnEnable()
    {
        //Register Slider Events
        volumeSlider.onValueChanged.AddListener(delegate { changeVolume(volumeSlider.value); });
    }

    //Called when Slider is moved
    void changeVolume(float sliderValue)
    {
        audioSource.volume = sliderValue;
        musicVolValue = sliderValue;
        InstanceManager.instance.musicValue = sliderValue;
    }

    /*void OnDisable()
    {
        //Un-Register Slider Events
        volumeSlider.onValueChanged.RemoveAllListeners();
    }*/
}
