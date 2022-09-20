using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] carPrefab;

    void Start()
    {
        //Call SpawnCars every X seconds
        InvokeRepeating("SpawnCars", 5f, 2f);
    }
    private void Update()
    {
        //transform.position = new Vector3(transform.position.x, playerOffset.transform.position.y, playerOffset.transform.position.z - offset);
    }
    //Spawn cars on random X position
    void SpawnCars()
    {
        Instantiate(carPrefab[Random.Range(0,carPrefab.Length)],
            new Vector3(Random.Range(transform.position.x - 3, transform.position.x + 3), transform.position.y, transform.position.z),
            Quaternion.identity);
    }
}
