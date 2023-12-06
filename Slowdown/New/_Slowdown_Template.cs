using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Slowdown_Template : MonoBehaviour
{
    
    public GameObject timeCenter;
    private TimeCenter tc;
    
    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        
        activated = false;

        tc = timeCenter.gameObject.GetComponent<TimeCenter>();

    }

    // Update is called once per frame
    void Update()
    {

        if (tc.activated) {
            
            Activate();

        } else {

            Deactivate();

        }

    }

    public void Activate() {

        if (!activated) { 

            activated = true;

        }

    }

    public void Deactivate() {

        if (activated) {
                
            activated = false;

        }

    }

}
