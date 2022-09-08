using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> prefab;

    private void Update()
    {
        Debug.Log(prefab.Count);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawner")
        {
            GameObject platform = Instantiate(prefab[Random.Range(0, prefab.Count)], 
                new Vector3(prefab[0].transform.position.x, prefab[0].transform.position.y, prefab[0].transform.position.z + 80f), 
                Quaternion.identity);
            
            prefab.Add(platform);
        }
        if (prefab.Count >= 3)
        {
            prefab.RemoveAt(0);
            Destroy(prefab[0]);
        }
    }
}
