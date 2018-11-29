using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LightsBehaviour : MonoBehaviour
{
    private Light myLight;
    private Light pl;
    private GameObject[] pointLights;
    private GameObject car7;
    private GameObject car1;
    private GameObject car2;
    // Use this for initialization
    void Start()
    {
        pointLights = GameObject.FindGameObjectsWithTag("pointlight");
        car7 = GameObject.FindWithTag("Car7");
        car1 = GameObject.FindWithTag("Car1");
        car2 = GameObject.FindWithTag("Car2");
        myLight = GetComponent<Light>();
        InvokeRepeating("triggerLights", 2.0f, 4.0f);
    }
    void triggerLights()
    {
        myLight.enabled = !myLight.enabled;
        foreach (GameObject pointlight in pointLights)
        {
            pl = pointlight.GetComponent<Light>();
            pl.enabled = !myLight.enabled;
        }
        Renderer renderer = car7.GetComponent<Renderer>();
        Renderer renderer1 = car1.GetComponent<Renderer>();
        Renderer renderer2 = car2.GetComponent<Renderer>();

        if (myLight.enabled)
        {
            Texture2D Car7Texture, Car1Texture, Car2Texture;
            Car7Texture = (Texture2D)Resources.Load("Car7TextureNew");
            Car1Texture = (Texture2D)Resources.Load("Car1TextureNew");
            Car2Texture = (Texture2D)Resources.Load("Car2TextureNew");
            renderer.material.SetTexture("_MainTex", Car7Texture);
            renderer1.material.SetTexture("_MainTex", Car1Texture);
            renderer2.material.SetTexture("_MainTex", Car2Texture);
        }
        else
        {
            Texture2D Car7Texture, Car1Texture, Car2Texture;
            Car7Texture = (Texture2D)Resources.Load("Car7Texture");
            Car1Texture = (Texture2D)Resources.Load("Car1Texture");
            Car2Texture = (Texture2D)Resources.Load("Car2Texture");
            renderer.material.SetTexture("_MainTex", Car7Texture);
            renderer1.material.SetTexture("_MainTex", Car1Texture);
            renderer2.material.SetTexture("_MainTex", Car2Texture);
        }
    }
}