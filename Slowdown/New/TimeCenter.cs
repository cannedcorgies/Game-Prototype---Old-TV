using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCenter : MonoBehaviour
{

    public bool activated;
    public float timeScale = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) {

            activated = true;

        } else {

            activated = false;

        }
        
    }
}
