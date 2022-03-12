using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static bool racing = false;
    public static int totalLaps = 2;
    public int timer = 3;
    public CheckpointController[] carsController;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("---------------------------------");
        InvokeRepeating(nameof(CountDown), 4, 1);
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        carsController = new CheckpointController[cars.Length];
        for(int i = 0; i < cars.Length; i++)
        {
            carsController[i] = cars[i].GetComponent<CheckpointController>();
        }
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        int finishedRace = 0;
        foreach(CheckpointController controller in carsController)
        {
            if(controller.lap == totalLaps + 1) finishedRace ++;
            if(finishedRace == carsController.Length && racing)
            {
                Debug.Log("Race Finished");
                racing = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CountDown()
    {
        if(timer != 0)
        {
            Debug.Log("Rozpoczęcie wyścigu za " + timer);
            timer--;
            return;
        }
        Debug.Log("Start!");
        racing = true;
        CancelInvoke(nameof(CountDown));
    }

}
