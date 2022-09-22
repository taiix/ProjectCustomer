using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip[] clip;

    
    public Slider volumeSlider;

    public float musicVolValue ;

    public string currScene;


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

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string curSceneName = currentScene.name;

        if (curSceneName != "MainMenu")
        {
            Destroy(this.gameObject);
        }

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
