using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown_ParticleSystem : MonoBehaviour
{

    public GameObject timeCenter;
    private TimeCenter tc;
    
    [SerializeField] private bool activated;

    [SerializeField] private float timeScaleRestore;

    private ParticleSystem ps;
    public ParticleSystem.MainModule main;
        private ParticleSystem.MinMaxCurve startLifetime_def;
    private ParticleSystem.VelocityOverLifetimeModule velocityModule;
        private ParticleSystem.MinMaxCurve speedModifier_def;
    

    // Start is called before the first frame update
    void Start()
    {

        activated = false;

        tc = timeCenter.gameObject.GetComponent<TimeCenter>();

        ps = gameObject.GetComponent<ParticleSystem>();
            main = ps.main;
            velocityModule = ps.velocityOverLifetime;

        startLifetime_def = main.startLifetime;
        speedModifier_def = velocityModule.speedModifier;
        
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

            main.startLifetime = 100 / (tc.timeScale * 100);
            velocityModule.speedModifier = tc.timeScale;

        }

    }

    public void Deactivate() {

        if (activated) {
                
            activated = false;

            main.startLifetime = startLifetime_def;
            velocityModule.speedModifier = speedModifier_def;

        }

    }

}
