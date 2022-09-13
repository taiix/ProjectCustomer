using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject carPrefab;


    void Start()
    {
        //Call SpawnCars every X seconds
        InvokeRepeating("SpawnCars", 2.0f, 2.0f);
    }

    //Spawn cars on random X position
    void SpawnCars()
    {
        Instantiate(carPrefab, 
            new Vector3(Random.Range(transform.position.x -3, transform.position.x + 3), transform.position.y, transform.position.z), 
            Quaternion.identity);
    }
}
