using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSscript : MonoBehaviour
{
    public Transform player;
    public float offset;
    // Start is called before the first frame update
    void LateUpdate ()
    {
        Vector3 newPosition = new Vector3(player.position.x, player.position.y, player.position.z + offset);
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
