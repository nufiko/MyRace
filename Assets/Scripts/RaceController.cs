using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceController : MonoBehaviour
{
    public static bool racing = false;
    public static int totalLaps = 1;
    public int timer = 3;
    public CheckpointController[] carsController;
    public Text startText;
    AudioSource audioSource;
    public AudioClip count;
    public AudioClip start;
    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        HideStartText();
        endPanel.SetActive(false);
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
                endPanel.SetActive(true);
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
        startText.gameObject.SetActive(true);
        if(timer != 0)
        {
            Debug.Log("Rozpoczęcie wyścigu za " + timer);
            startText.text = timer.ToString();
            audioSource.PlayOneShot(count);
            timer--;
            return;
        }
        Debug.Log("Start!");
        startText.text = "START!!!";
        audioSource.PlayOneShot(start);
        racing = true;
        CancelInvoke(nameof(CountDown));
        Invoke(nameof(HideStartText), 1);
    }

    private void HideStartText()
    {
        startText.gameObject.SetActive(false);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
