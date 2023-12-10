using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticController : MonoBehaviour
{
    public GameObject timeCenter;
    private TimeCenter tc;

    public GameObject passiveStatic;
    public GameObject slowedStatic;
    
    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        
        activated = true;

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

            passiveStatic.SetActive(false);
            slowedStatic.SetActive(true);

        }

    }

    public void Deactivate() {

        if (activated) {
                
            activated = false;

            passiveStatic.SetActive(true);
            slowedStatic.SetActive(false);

        }

    }
}
