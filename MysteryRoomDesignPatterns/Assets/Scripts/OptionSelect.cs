using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSelect : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button clicked");
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit2;

            if (Physics.Raycast(ray2, out hit2))
            {
                if (hit2.transform.name == "A.")
                {
                    Debug.Log("This is an answer");
                }
            }
        }
    }

}
