using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsBehaviour : MonoBehaviour {
    private Light myLight;
    private Light pl;
    private GameObject[] pointLights;


    // Use this for initialization
    void Start() {
        pointLights = GameObject.FindGameObjectsWithTag("pointlight");
        myLight = GetComponent<Light>();
        InvokeRepeating("ShiftToNight", 2.0f, 4.0f);
        InvokeRepeating("ShiftToDay", 5.0f, 5.0f);

    }
    void ShiftToNight() {
        myLight.enabled = false;
        foreach (GameObject pointlight in pointLights)
        {
            pl = pointlight.GetComponent<Light>();
            pl.enabled = true;

        }
    }

    void ShiftToDay() {
        myLight.enabled = true;
        foreach (GameObject pointlight in pointLights)
        {
            pl = pointlight.GetComponent<Light>();
            pl.enabled = false;

        }
    }

    // Update is called once per frame
    void Update () {

       

    }
}
