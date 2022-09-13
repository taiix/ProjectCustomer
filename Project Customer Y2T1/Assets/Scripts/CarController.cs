using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider backLeft;
    [SerializeField] WheelCollider backRight;

    public float maxTorque;
    public float maxAngle;
    public float brakeForce;

    private bool brake;

    private void FixedUpdate()
    {
        float speed = Input.GetAxis("Vertical") * maxTorque;
        float steering = Input.GetAxis("Horizontal") * maxAngle;

        MotorTorque(speed);
        Steering(steering);

        Brakes();
    }

    void MotorTorque(float speed)
    {
        frontLeft.motorTorque = speed;
        frontRight.motorTorque = speed;
    }

    void Steering(float steering)
    {
        frontLeft.steerAngle = steering;
        frontRight.steerAngle = steering;
    }

    void Brakes()
    {
        brake = Input.GetKey(KeyCode.Space);

        if (brake)
            brakeForce = 500;
        else
            brakeForce = 0;

        frontLeft.brakeTorque = brakeForce;
        frontRight.brakeTorque = brakeForce;
        backLeft.brakeTorque = brakeForce;
        backRight.brakeTorque = brakeForce;
    }
}
