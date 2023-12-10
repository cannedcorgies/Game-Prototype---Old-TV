using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewindTime : MonoBehaviour
{
    
    public Ray mouseRay;
    bool isRewinding;
    Rigidbody rb;
    Vector3 objPos;
    LinkedList<ObjProperties> rewindPoints;
    public float recordTime = 6f;

    void Start()
    {
        // initialize stuff
        isRewinding = false;
        rewindPoints = new LinkedList<ObjProperties>();
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            RewindHitDetected();
            Debug.Log("button pressed");
        }
        if (Input.GetKeyUp(KeyCode.R)) {
            StopRewind();
        }
	}

    void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void RewindHitDetected() 
    {
        // start the rewind
        isRewinding = true;
        rb.isKinematic = true;

        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity)) 
        {
            Debug.Log("YAYYYYYYYY");
            Rewind();
        }
    }

    void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }

    void Rewind()
    {
        Debug.Log("in rewind function");

        if (rewindPoints.Count > 0)
		{
			
            ObjProperties latestPoint = rewindPoints.Last.Value;
            Debug.Log(latestPoint);
            transform.position = latestPoint.position;
			transform.rotation = latestPoint.rotation;
            rb.velocity = latestPoint.velocity;
			rewindPoints.RemoveLast();
		} else
		{
			StopRewind();
		}
    }

    void Record() 
    {
        // only record for 6 seconds else we remove from the front of the linked list
        // so that the linked list isnt filled with an enourmouse amount of values
        if (rewindPoints.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
		    rewindPoints.RemoveFirst();
		}
        rewindPoints.AddLast(new ObjProperties(transform.position, transform.rotation, rb.velocity));
    }
}
