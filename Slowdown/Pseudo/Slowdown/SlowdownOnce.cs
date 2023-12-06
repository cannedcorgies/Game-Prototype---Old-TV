using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownOnce : MonoBehaviour
{

    [SerializeField] private bool activated;

    [SerializeField] private float timeScaleRestore;
    
    [SerializeField] private Vector3 savedVelocity;
    [SerializeField] private bool savedGravity;
    public float maxVelocity = 100f;
    
    private Rigidbody rb;

    public GameObject timeCenter;
    private TimeFlowCenter tfc;

    // Start is called before the first frame update
    void Start()
    {

        name = gameObject.name;

        activated = false;

        //Debug.Log("hi! i am " + name);
        //Debug.Log(" - my max velocity: " + maxVelocity);
        
        rb = gameObject.GetComponent<Rigidbody>();

        tfc = timeCenter.gameObject.GetComponent<TimeFlowCenter>();
        timeScaleRestore = 100 / (tfc.timeScale * 100);

    }

    // Update is called once per frame
    void Update()
    {

        if (tfc.activated) {
            
            if (!activated) { 

                activated = true;

                savedVelocity = rb.velocity;
                savedGravity = rb.useGravity;

                rb.useGravity = false;

                rb.velocity *= tfc.timeScale;
                rb.angularVelocity *= tfc.timeScale;

            }

            

        } else {

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

    }

    void OnEnable() {

        if (tfc.activated) {

            activated = true;

            savedVelocity = rb.velocity;
            savedGravity = rb.useGravity;

            rb.useGravity = false;

            rb.velocity *= tfc.timeScale;
            rb.angularVelocity *= tfc.timeScale;

        }

    }

}
