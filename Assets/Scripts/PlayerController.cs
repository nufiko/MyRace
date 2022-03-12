using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    DrivingScript drivingScript;

    // Start is called before the first frame update
    void Start()
    {
        drivingScript = GetComponent<DrivingScript>();    
    }

    // Update is called once per frame
    void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        if(!RaceController.racing) accel = 0;
        drivingScript.Drive(accel, brake, steer);
    }
}
