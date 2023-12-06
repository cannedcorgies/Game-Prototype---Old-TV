using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown_Once : MonoBehaviour
{
    
    public GameObject timeCenter;
    private TimeCenter tc;
    
    [SerializeField] private bool activated;

    [SerializeField] private float timeScaleRestore;
    
    [SerializeField] private Vector3 savedVelocity;
    [SerializeField] private bool savedGravity;
    public float maxVelocity = 100f;
    
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        activated = false;

        rb = gameObject.GetComponent<Rigidbody>();

        tc = timeCenter.gameObject.GetComponent<TimeCenter>();
        timeScaleRestore = 100 / (tc.timeScale * 100);

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

            savedVelocity = rb.velocity;
            savedGravity = rb.useGravity;

            rb.useGravity = false;

            rb.velocity *= tc.timeScale;
            rb.angularVelocity *= tc.timeScale;

        }

    }

    public void Deactivate() {

        if (activated) {
                
            activated = false;

            rb.velocity *= timeScaleRestore;
            rb.angularVelocity *= timeScaleRestore;

            if (savedGravity) { rb.useGravity = savedGravity; }
            if (rb.velocity == Vector3.zero) { rb.velocity = savedVelocity; }

            if (rb.velocity.x > maxVelocity) { rb.velocity = new Vector3(maxVelocity, rb.velocity.y, rb.velocity.z); }
            if (rb.velocity.x < -maxVelocity) { rb.velocity = new Vector3(-maxVelocity, rb.velocity.y, rb.velocity.z); }

            if (rb.velocity.y > maxVelocity) { rb.velocity = new Vector3(rb.velocity.x, maxVelocity, rb.velocity.z); }
            if (rb.velocity.y < -maxVelocity) { rb.velocity = new Vector3(rb.velocity.x, -maxVelocity, rb.velocity.z); }

        }

    }

    //// NOTE ////
    //  - i do not remember what this was for
    //

    /* void OnEnable() {

        if (tfc.activated) {

            activated = true;

            savedVelocity = rb.velocity;
            savedGravity = rb.useGravity;

            rb.useGravity = false;

            rb.velocity *= tfc.timeScale;
            rb.angularVelocity *= tfc.timeScale;

        }

    }*/

}
