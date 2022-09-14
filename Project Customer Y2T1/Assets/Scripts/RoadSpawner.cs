using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> environment;

    public float offset;

    /* If the player trigger this
     * Instantiate new environmnets on random 
     * Add the game object with all the objects to the list 
     * Removes and destroys the objects if there are more or equal to 3
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawner")
        {
            GameObject platform = Instantiate(environment[Random.Range(0, environment.Count)],
                new Vector3(environment[0].transform.position.x, environment[0].transform.position.y, environment[0].transform.position.z + offset),
                Quaternion.identity);

            environment.Add(platform);
        }
        if (environment.Count >= 3)
        {
            Destroy(environment[0]);
            environment.RemoveAt(0);
        }
    }
}
