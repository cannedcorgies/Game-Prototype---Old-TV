////    CAMERA MUST HAVE PARENT ////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlowCenter : MonoBehaviour
{

    public bool activated;
    [SerializeField] private bool energized;
    [SerializeField] private bool rise;
    public float tiredTime = 7f;
    
    public float timeScale = 0.02f;
    public float chargeMax = 50f;
    public float charge;
    //public float chargeInSeconds = 5;

    public Camera cam;
    [SerializeField] private float camFOVOriginal;
    public float zoomOutScale = 1.3f;
    [SerializeField] private float zoomTarget;
    public float zoomTargetScale = 0.7f;
    public float zoomDifference;
    public float zoomVelocity;
    public float smoothTime;// = 5f;
    [SerializeField] private float elapsedTime = 0f;

    public AnimationCurve curve;
    public float curveScale = 0.5f;
    public float screenShakeDuration;
    public float warningLevel = 20f;
    [SerializeField] private float camXOffset;
    [SerializeField] private float camYOffset;
    [SerializeField] private float camZOffset;
    [SerializeField] private Vector3 camOffsetVector;

    // Start is called before the first frame update
    void Start()
    {

        name = gameObject.name;

        activated = false;
        energized = true;
        rise = false;
        zoomDifference = zoomOutScale - zoomTargetScale;

        charge = chargeMax;
        
        Debug.Log("hello! i am " + name);
        Debug.Log(" -- my slowdown lasts " + chargeMax);
        Debug.Log(" -- i zoom out by camera fov by " + zoomOutScale);
        Debug.Log(" -- i zoom in by camera fov by " + zoomTargetScale);
        Debug.Log(" -- my zoom velocity is " + zoomVelocity);
        Debug.Log(" -- screen shake strength scale is " + curveScale);
        Debug.Log(" -- the estimated time to get there is " + smoothTime);

        Debug.Log(" -- and my difference between zoom and shake time is " + warningLevel);

        camFOVOriginal = cam.fieldOfView;

        screenShakeDuration = warningLevel/10f;
        
        Debug.Log(cam.transform.parent.transform.position.y);
        Debug.Log(cam.transform.position.y);
        Debug.Log(cam.transform.parent.transform.position.y - cam.transform.position.y);

        camXOffset = cam.transform.parent.transform.position.x - cam.transform.position.x;
        camYOffset = cam.transform.parent.transform.position.y - cam.transform.position.y;
        camZOffset = cam.transform.parent.transform.position.z - cam.transform.position.z;
        camOffsetVector = new Vector3(camXOffset, camYOffset, camZOffset);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (charge <= 0) {

            if (rise) {     // on deactivation

                rise = false;
                cam.fieldOfView = camFOVOriginal;

                cam.transform.position = cam.transform.parent.transform.position - camOffsetVector;
                
                StartCoroutine(Recharge());

            }

            activated = false;

        }

        if (energized) {                   // is able to use charge

            if (activated) {
                
                if (!rise) {       // on activation

                    rise = true;

                    zoomTarget = cam.fieldOfView * zoomTargetScale;                                                 // save the target zoom in
                    cam.fieldOfView *= (zoomTargetScale + (zoomDifference * (charge/chargeMax)));                    // zoom outsies relative to wheel ratio

                    elapsedTime = 0f;
                
                }


                if (charge > 0) {                       // decrease charge

                    charge -= 10 * Time.deltaTime;

                }


                if (charge <= warningLevel) {             // while under threshold, shake camera

                    elapsedTime += Time.deltaTime;
                    float strength = (curve.Evaluate(elapsedTime / screenShakeDuration)) * curveScale;
                
                    var sphereGuess = Random.insideUnitSphere;

                    cam.transform.position = (cam.transform.parent.transform.position - camOffsetVector) + (sphereGuess * strength);

                }


                cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, zoomTarget, ref zoomVelocity, charge/10f);  // [1]      // zoom in smoothly
            

            }  else {


                if (rise) {     // on deactivation

                    rise = false;
                    cam.fieldOfView = camFOVOriginal;

                    cam.transform.position = cam.transform.parent.transform.position - camOffsetVector;

                }


                if (charge < chargeMax) {       // increase

                    charge += 30 * Time.deltaTime;

                }


            }

        }

    }


    IEnumerator Recharge() {

        energized = false;

        yield return new WaitForSeconds(tiredTime);

        energized = true;
        charge = chargeMax;

    }


    /*IEnumerator Deactivate() {

        StartCoroutine(Shaking());

        yield return new WaitForSeconds(chargeInSeconds);

        activated = false;
 
    }

    IEnumerator Shaking() {     // [2]

        yield return new WaitForSeconds(chargeInSeconds - 2);

        float elapsedTime = 0f;

        while (elapsedTime < screenShakeDuration) {

            elapsedTime += Time.deltaTime;
            float strength = (curve.Evaluate(elapsedTime / screenShakeDuration)) * curveScale;
            
            var sphereGuess = Random.insideUnitSphere;

            cam.transform.position = (cam.transform.parent.transform.position - camOffsetVector) + (sphereGuess * strength);

            yield return null;

        }

    }*/ 


////    CREDITS ////
//
//  1. Zoom-in adapted from bendux on YouTube
//      - https://youtu.be/HxnpWhxjJwE?si=VDGvuFu0mayTn_t1 
//
//  2. Screen shake from Thomas Friday on Youtube
//      - https://youtu.be/BQGTdRhGmE4?si=yYM5drUn7hIK2Qj_&t=130 
//

}
