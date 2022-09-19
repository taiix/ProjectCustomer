using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public int numberOfLightWindows;
    public Material lightColor;
    [SerializeField] GameObject[] windows;

    void Start()
    {
        windows = GameObject.FindGameObjectsWithTag("Windows");

        for (int i = 0; i < numberOfLightWindows; i++)
        {
            int r = Random.Range(0, windows.Length - 1);
            windows[r].GetComponent<MeshRenderer>().material = lightColor;
        }
    }

}
