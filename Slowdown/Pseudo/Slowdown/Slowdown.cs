using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : MonoBehaviour
{

    [SerializeField] private bool activated;

    [SerializeField] private Vector3 savedVelocity;
    [SerializeField] private Vector3 savedAngularVelocity;
    [SerializeField] private bool savedGravity;

    private Rigidbody rb;

    public GameObject timeCenter;
    private TimeFlowCenter tfc;

    // Start is called before the first frame update
    void Start()
    {

        name = gameObject.name;

        activated = false;

        Debug.Log("hi! i am " + name);
        
        rb = gameObject.GetComponent<Rigidbody>();

        tfc = timeCenter.gameObject.GetComponent<TimeFlowCenter>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (tfc.activated) {
            
            if (!activated) { 
                
                
                activated = true;

                savedVelocity = rb.velocity;
                savedAngularVelocity = rb.angularVelocity;
                savedGravity = rb.useGravity;

                rb.useGravity = false;

            }

            rb.velocity *= tfc.timeScale;
            rb.angularVelocity *= tfc.timeScale;
            
        } else {

            if (activated) {
                
                activated = false;

                rb.velocity = savedVelocity;
                rb.angularVelocity = savedAngularVelocity;
                rb.useGravity = savedGravity;

            }

        }

    }
}
