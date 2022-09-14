using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float angleRotation;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(angleRotation);

        angleRotation += Input.GetAxis("Horizontal") * Time.deltaTime * 1f;
        angleRotation = Mathf.Lerp(angleRotation, -120f, 120f);

        if (Input.GetAxis("Horizontal") == 0 && angleRotation != 0) { 
            //if()
        }
        transform.rotation = Quaternion.Euler(0f,0f, angleRotation);
    }
}
