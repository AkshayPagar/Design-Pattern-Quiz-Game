using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IDisplayComponent {

    public GameObject Light;

	// Use this for initialization
	void Start () {

        
    }

    public void display()
    {
        Light.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse button clicked");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Button")
                {
                    Debug.Log("This is button");

                    if (Light.activeInHierarchy == true)
                        Light.SetActive(false);
                    else
                        Light.SetActive(true);
                }
            }
        }
	}

   
    public void addSubComponent(IDisplayComponent c) {
    }
}
