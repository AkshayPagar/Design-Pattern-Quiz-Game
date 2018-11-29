using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrderScript : MonoBehaviour {
    public GameObject Order;
    // Use this for initialization
    void Start () {
        Order.SetActive(false);
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
                if (hit1.transform.name == "Burger")
                {
                    Debug.Log("This is frame");

                    if (Order.activeInHierarchy == true)
                        Order.SetActive(false);
                    else
                        Order.SetActive(true);
                }
            }
        }
    }
}
