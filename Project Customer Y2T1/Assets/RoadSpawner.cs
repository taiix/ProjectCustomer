using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    public float offset;

    /* If the player trigger this
     * Instantiate new road on random 
     * Add the road to the list 
     * Removes and destroys the roads if there are more or equal to 3
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawner")
        {
            GameObject platform = Instantiate(roads[Random.Range(0, roads.Count)],
                new Vector3(roads[0].transform.position.x, roads[0].transform.position.y, roads[0].transform.position.z + offset),
                Quaternion.identity);


            roads.Add(platform);
        }
        if (roads.Count >= 3)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
        }
    }
}
