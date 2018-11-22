using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour {
    public GameObject Lightb;
    // Use this for initialization
    void Start () {
        Lightb.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse button clicked");
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit1;

            if (Physics.Raycast(ray1, out hit1))
            {
                if (hit1.transform.name == "ButtonB")
                {
                    Debug.Log("This is button");

                    if (Lightb.activeInHierarchy == true)
                        Lightb.SetActive(false);
                    else
                        Lightb.SetActive(true);
                }
            }
        }
    }
}
