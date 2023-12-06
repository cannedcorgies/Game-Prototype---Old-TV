using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampVelocity : MonoBehaviour
{

    public float maxVel = 100f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity =  Vector3.ClampMagnitude(rb.velocity, maxVel);

    }
}
