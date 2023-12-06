using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown_Audio : MonoBehaviour
{

    public GameObject timeCenter;
    private TimeCenter tc;
    
    public bool activated;

    private AudioSource[] sources;

    // Start is called before the first frame update
    void Start()
    {
        
        activated = false;

        tc = timeCenter.gameObject.GetComponent<TimeCenter>();

        sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];

    }

    // Update is called once per frame
    void Update()
    {

        sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];

        if (tc.activated) {
            
            Activate();

        } else {

            Deactivate();

        }

    }

    public void Activate() {

        activated = true;

        foreach (AudioSource source in sources) {

            source.pitch = (tc.timeScale * 10);

        }

    }

    public void Deactivate() {

        foreach (AudioSource source in sources) {

            source.pitch = 1;

        }

    }

}
