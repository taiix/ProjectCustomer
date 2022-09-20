using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Wheel Colliders")]
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider backLeft;
    [SerializeField] WheelCollider backRight;

    [Header("Wheel Objects")]
    [SerializeField] Transform frontLeftTrans;
    [SerializeField] Transform frontRightTrans;
    [SerializeField] Transform backLeftTrans;
    [SerializeField] Transform backRightTrans;

    public float maxTorque;
    public float maxAngle;
    public float brakeForce;

    public static float speedometer;

    private bool brake;
    private float speed;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Speed Limit
        if (rb.velocity.magnitude <= 25)
        {
            speed = Input.GetAxis("Vertical") * maxTorque;
            MotorTorque(speed);
        }
        else { speed = 0; }

        float steering = Input.GetAxis("Horizontal") * maxAngle;

        Steering(steering);
        Friction(speed);
        Brakes();

        UpdateWheelPos(frontLeft, frontLeftTrans);
        UpdateWheelPos(frontRight, frontRightTrans);

        speedometer = (float)rb.velocity.magnitude * 3.6f;

    }

    void MotorTorque(float speed)
    {
        frontLeft.motorTorque = speed;
        frontRight.motorTorque = speed;
    }

    void Friction(float speed)
    {
        if (speed > 0) rb.drag = 0;
        else rb.drag = 0.2f;
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
            brakeForce = 600;
        else
            brakeForce = 0;

        frontLeft.brakeTorque = brakeForce;
        frontRight.brakeTorque = brakeForce;
        backLeft.brakeTorque = brakeForce;
        backRight.brakeTorque = brakeForce;
    }

    void UpdateWheelPos(WheelCollider col, Transform wheel)
    {
        Vector3 pos;
        Quaternion rot;

        col.GetWorldPose(out pos, out rot);

        wheel.transform.position = pos;
        wheel.transform.rotation = rot;
    }
}
