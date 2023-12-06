using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DilateActivate : MonoBehaviour
{

    public GameObject timeCenter;
    private TimeFlowCenter tfc;

    // Start is called before the first frame update
    void Start()
    {
        
        name = gameObject.name;

        Debug.Log("hi! i am " + name);

        tfc = timeCenter.gameObject.GetComponent<TimeFlowCenter>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space")) {

            tfc.activated = true;

        }

        if (Input.GetKeyUp("space")) {

            tfc.activated = false;

        }
        
    }
    
}
