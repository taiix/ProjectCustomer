using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxTorque;
    public float maxAngle;
    public float brakeForce;

    public AudioClip[] clip;

    public static float speedometer;

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

    public AudioSource[] audioSource;
    
    private bool brake;
    private float speed;
    private Rigidbody rb;

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
        
        Audio();

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
        else rb.drag = 0.4f;
    }

    void Steering(float steering)
    {
        frontLeft.steerAngle = steering;
        frontRight.steerAngle = steering;
    }
    
    void Audio() 
    {

        //Car engine sound
        if (!audioSource[0].isPlaying && speed == 0)
        {
            audioSource[0].PlayOneShot(clip[0]);
        }

        //Car acceleration sound
        if (Input.GetKeyDown(KeyCode.W) && rb.velocity.magnitude <= 20) 
        {
            audioSource[1].loop = true;
            audioSource[1].Play();
        }
        else if(Input.GetKeyUp(KeyCode.W) || rb.velocity.magnitude >= 20)
        {
            audioSource[1].loop = false;
            audioSource[1].Stop();
        }

        //Horn
        if (Input.GetKeyDown(KeyCode.H)) {
            audioSource[2].Play();
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) && rb.velocity.magnitude >= 5 ) {
            audioSource[3].Play();
        }
    }

    void Brakes()
    {
        brake = Input.GetKey(KeyCode.Space);

        if (brake)
            brakeForce = 5000;
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
