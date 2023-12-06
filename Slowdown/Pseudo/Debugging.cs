using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging : MonoBehaviour
{

    private Rigidbody rb;

    public bool vel = true;
    public bool angVel = true;

    // Start is called before the first frame update
    void Start()
    {

        name = gameObject.name;
        
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (vel || angVel) {

            Debug.Log("DEBUG - " + name);

            if (vel) { Debug.Log(" -- velocity: " + rb.velocity); }

            if (angVel) {Debug.Log(" -- angular velocity: " + rb.angularVelocity); }

        }

    }
}
