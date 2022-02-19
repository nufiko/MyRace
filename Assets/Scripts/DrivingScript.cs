using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingScript : MonoBehaviour
{
    public WheelScript[] wheels;
    public float torque = 200;
    public float maxSteerAngle = 30;
    public float maxBrakeTorque = 500;
    public float maxspeed = 200;
    public Rigidbody rb;
    public float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drive(float accel, float brake, float steer)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        brake = Mathf.Clamp(brake, 0, 1) * maxBrakeTorque;

        float thrustTorque = 0f;
        currentSpeed = rb.velocity.magnitude * 3;

        if(currentSpeed < maxspeed)
        {
            thrustTorque = accel * torque;
        }

        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = thrustTorque;
            if(wheel.frontWheel)
            {
                wheel.wheelCollider.steerAngle = steer;
            }
            else
            {
                wheel.wheelCollider.brakeTorque = brake;
            }

            wheel.wheelCollider.GetWorldPose(out Vector3 position, out Quaternion turn);
            wheel.wheel.transform.position = position;
            wheel.wheel.transform.rotation = turn;
        }
    }
}
