using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject carPrefab;
    public float offset;

    private GameObject playerOffset;
    void Start()
    {
        playerOffset = GameObject.FindGameObjectWithTag("Player");
        //Call SpawnCars every X seconds
        InvokeRepeating("SpawnCars", 3f, 3f);
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, playerOffset.transform.position.y, playerOffset.transform.position.z - offset);
    }
    //Spawn cars on random X position
    void SpawnCars()
    {
        Instantiate(carPrefab, 
            new Vector3(Random.Range(transform.position.x -3, transform.position.x + 3), transform.position.y, transform.position.z), 
            Quaternion.identity);
    }
}
