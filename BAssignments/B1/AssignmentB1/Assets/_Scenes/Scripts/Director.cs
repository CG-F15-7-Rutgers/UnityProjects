using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class Director : MonoBehaviour {

    //private List<GameObject> selectedUnits;
    private GameObject selectedUnit;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Agent" && Input.GetMouseButtonDown(0))
            {
                //selectedUnits.Add(hit.transform.gameObject);
                selectedUnit = hit.transform.gameObject;
                selectedUnit.SendMessage("Select", 1);
            }
            if (Input.GetMouseButtonDown(1))
            {
                selectedUnit.SendMessage("Destination", hit.point);
            }
            if (hit.transform.tag == "Ground" && Input.GetMouseButtonDown(0))
            {
                selectedUnit.SendMessage("Deselect", 1);
            }
        }
    }

}
