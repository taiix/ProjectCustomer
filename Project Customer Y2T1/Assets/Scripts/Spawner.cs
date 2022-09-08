using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject carPrefab;


    void Start()
    {
        InvokeRepeating("SpawnCars", 2.0f, 2.0f);
    }

    void SpawnCars()
    {
        Instantiate(carPrefab, 
            new Vector3(Random.Range(transform.position.x -3, transform.position.x + 3), transform.position.y, transform.position.z), 
            Quaternion.identity);
    }
}
