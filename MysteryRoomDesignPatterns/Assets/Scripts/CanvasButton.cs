using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButton : MonoBehaviour {

    public GameObject FamTree;

    // Use this for initialization
    void Start () {
        FamTree.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse button clicked");
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit1;

            if (Physics.Raycast(ray1, out hit1))
            {
                if (hit1.transform.name == "Paint")
                {
                    Debug.Log("This is frame");

                    if (FamTree.activeInHierarchy == true)
                        FamTree.SetActive(false);
                    else
                        FamTree.SetActive(true);
                }
            }
        }
    }
}
