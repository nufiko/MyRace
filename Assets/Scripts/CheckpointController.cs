using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public int lap = 0;
    public int checkpoint = -1;
    int pointCount;
    public int nextPoint;
    public GameObject lastCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        pointCount = checkpoints.Length;
        for (int i = 0; i < pointCount; i++)
        {
            if (checkpoints[i].name == "0")
            {
                lastCheckpoint = checkpoints[i];
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            int thisPoint = int.Parse(other.gameObject.name);
            Debug.Log("This checkpoint: " + thisPoint + " expected: " + nextPoint);
            if (thisPoint == nextPoint)
            {
                Debug.Log("Checkpoint: " + thisPoint);
                checkpoint = thisPoint;
                lastCheckpoint = other.gameObject;
                if (checkpoint == 0)
                {
                    lap++;
                    Debug.Log("Lap: " + lap);
                }

                nextPoint++;
                nextPoint = nextPoint % pointCount;
            }
        }
    }
}
