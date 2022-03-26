using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    DrivingScript drivingScript;
    float lastTimeMoving = 0;
    CheckpointController checkpointController;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        drivingScript = GetComponent<DrivingScript>();
        checkpointController = drivingScript.rb.GetComponent<CheckpointController>();
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        if (drivingScript.rb.velocity.magnitude > 1 || !RaceController.racing)
        {
            lastTimeMoving = Time.time;
        }

        if (Time.time > lastTimeMoving + 4 ||
            drivingScript.rb.gameObject.transform.position.y < -5)
        {
            drivingScript.rb.transform.position =
                checkpointController.lastCheckpoint.transform.position + Vector3.up * 1.2f;

            drivingScript.rb.transform.rotation =
                checkpointController.lastCheckpoint.transform.rotation * Quaternion.Euler(0, 90, 0);

            drivingScript.rb.gameObject.layer = 6;

            Invoke(nameof(ResetLayer), 3);
        }

        if (!RaceController.racing) accel = 0;
        drivingScript.Drive(accel, brake, steer);
    }

    void ResetLayer()
    {
        drivingScript.rb.gameObject.layer = 0;
    }
}
