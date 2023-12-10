using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind_Rain : MonoBehaviour
{

    public bool activated;

    private ParticleSystem ps;
    private ParticleSystem.VelocityOverLifetimeModule velocityModule;

    public float offset;
    public Vector3 defPos;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
        activated = true;

        ps = gameObject.GetComponent<ParticleSystem>();
            velocityModule = ps.velocityOverLifetime;

        defPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R)) {

            RewindActivate();

        } else if (Input.GetKeyUp(KeyCode.R)) {

            RewindDeactivate();

        }

    }

    public void RewindActivate(){

        if (!activated) {

            activated = true;
            //transform.position = new Vector3 (transform.position.x, transform.position.y - offset, transform.position.z);
            transform.position = player.transform.position;
            velocityModule.speedModifier = -1f;

        }

    }

    public void RewindDeactivate(){

        if (activated) {

            activated = false;
            //transform.position = new Vector3 (transform.position.x, transform.position.y + offset, transform.position.z);

            transform.position = new Vector3( transform.position.x, defPos.y, transform.position.z );
            velocityModule.speedModifier = 1f;

        }

    }

}
