using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adaptor : MonoBehaviour {
    public GameObject plug;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button clicked");
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit1;

            if (Physics.Raycast(ray1, out hit1))
            {
                if (hit1.transform.name == "PlugA")
                {
                    Debug.Log("This is button");
                }
            }
        }
    }
}
