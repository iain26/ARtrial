using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARmanipulations : MonoBehaviour {

    Ray ray;

    public GameObject UMPText;
    public GameObject SoldierText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        UMPText.SetActive(false);
        SoldierText.SetActive(false);
        if (Input.touchCount > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "UMP")
                {
                    UMPText.SetActive(true);
                }
                if (hit.collider.name == "Soldier")
                {
                    SoldierText.SetActive(true);
                }
            }
        }
    }
}
