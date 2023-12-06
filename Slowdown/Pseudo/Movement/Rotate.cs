using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotateSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
        name = gameObject.name;
        
        Debug.Log("hi! my name is " + name);
        Debug.Log(" -- rotateSpeed " + rotateSpeed);

        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        rb.angularVelocity = new Vector3(0, 0, rotateSpeed);

    }
}
