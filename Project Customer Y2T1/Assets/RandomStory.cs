using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStory : MonoBehaviour
{
    public GameObject[] stories;

    private void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            stories[Random.Range(0,stories.Length)].SetActive(true);
        }
    }
}
