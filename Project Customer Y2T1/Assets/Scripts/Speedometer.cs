using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Speedometer : MonoBehaviour
{
    [SerializeField] TextMeshPro speedText;
    [SerializeField] GameObject Car;

    float currentSpeed = CarController.speedometer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = CarController.speedometer.ToString("00") + "km/h";

    }
}
