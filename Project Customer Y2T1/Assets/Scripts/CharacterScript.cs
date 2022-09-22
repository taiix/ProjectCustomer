using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public GameObject text;

    private bool canTake;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTake)
        { 
            Destroy(gameObject);
            text.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            canTake = true;
            text.SetActive(true);
        }
        else {
            text.SetActive(false);
            canTake = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }
}
