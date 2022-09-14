using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float rotationSpeed;

    public float angleRotation;
    private bool isRotating;

    void Update()
    {
        // CarWheelRotation();
        transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, -Input.GetAxis("Horizontal") * 180);
    }

    void CarWheelRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            angleRotation += Time.deltaTime * rotationSpeed;
            isRotating = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            angleRotation -= Time.deltaTime * rotationSpeed;
            isRotating = true;
        }
        else { 
            isRotating = false;
        }

        if (angleRotation < 0 && !isRotating)
            angleRotation += Time.deltaTime * rotationSpeed;
        else if (angleRotation > 0 && !isRotating)
            angleRotation -= Time.deltaTime * rotationSpeed;

        //Rotate the wheel and set min and max rotation degrees
        angleRotation = Mathf.Clamp(angleRotation, -120f, 120f);
        transform.rotation = Quaternion.Euler(0f, 0f, angleRotation);
    }
}
