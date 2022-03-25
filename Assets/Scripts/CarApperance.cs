using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarApperance : MonoBehaviour
{
    public string playerName;
    public Color carColor;
    public Text nameText;
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = playerName;
        nameText.color = carColor;
        var carRenderer = car.GetComponentsInChildren<MeshRenderer>();
        foreach(var part in carRenderer)
        {
            part.material.color = carColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
