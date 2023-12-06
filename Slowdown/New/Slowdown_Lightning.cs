using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown_Lightning : MonoBehaviour
{
    public GameObject timeCenter;
    private TimeCenter tc;
    [SerializeField] private float localTimescale;
    
    public bool activated;

    private Light light;

    public float intensity = 2000f;
    public float defIntensity;

    public float minTime = 5f;
    public float maxTime = 15f;
    [SerializeField] private float _nextTime;              // when it will flash next
    public float flashTime = 0.1f;             // how long it will flash for
    public float flashTime_between = 0.05f;     // time between flashes

    public AudioClip thunder;
    public float minTime_thunder = 0.1f;
    public float maxTime_thunder = 8f;
    [SerializeField] private float _thunderTime;           // how long for thunder to sound
    public float volume;

    public GameObject center;
    public float distanceStep;
    [SerializeField] private Vector3 _dir;
    [SerializeField] private float _xPos;
    [SerializeField] private float _yPos;

    [SerializeField] private bool _flashAvail;

    [SerializeField] private bool check_flash;
        [SerializeField] private bool check_flashPrep;
        [SerializeField] private float flash_timeStamp;
    [SerializeField] private bool check_thunder;
        [SerializeField] private bool check_thunderPrep;
        [SerializeField] private float thunder_timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        
        activated = false;

        tc = timeCenter.gameObject.GetComponent<TimeCenter>();
        localTimescale = 1.0f;

        light = GetComponent<Light>();
        defIntensity = light.intensity;

        check_flash = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (tc.activated) {
            
            Activate();

        } else {

            Deactivate();

        }

        LightningWrapper();

    }
    

    public void Activate() {

        if (!activated) { 

            activated = true;
            localTimescale = 100 / (tc.timeScale * 100);

        }

    }

    public void Deactivate() {

        if (activated) {
                
            activated = false;
            localTimescale = 1.0f;

        }

    }

    IEnumerator Flash() {

        check_flashPrep = false;

        light.intensity = intensity;

        yield return new WaitForSeconds(flashTime);         // time first flash happens for

        light.intensity = defIntensity;

        yield return new WaitForSeconds(flashTime_between); // time to second flash after first flash done

        light.intensity = intensity;

        yield return new WaitForSeconds(flashTime);         // time second flash happens for

        light.intensity = defIntensity;

        thunder_timeStamp = Time.time;
        check_thunderPrep = true;

    }

    public void LightningWrapper() {

        if (check_flash) {

            CooldownFlash();

        }

        if (check_thunder) {

            CooldownThunder();

        }

        if (Time.time >= flash_timeStamp + (_nextTime * localTimescale) && check_flashPrep) {

            StartCoroutine(Flash());

        }

        if (Time.time >= thunder_timeStamp + (_thunderTime * localTimescale) && check_thunderPrep) {

            check_thunder = true;
            check_thunderPrep = false;

        }

    }

    public void CooldownFlash() {

        check_flash = false;

        _nextTime = Random.Range(minTime, maxTime);
        _thunderTime = Random.Range(minTime_thunder, maxTime_thunder);

        _xPos = Random.Range(-1, 1);
        _yPos = Random.Range(-1, 1);
        var myDir = new Vector3(_xPos, 0, _yPos);

        _dir = center.transform.position + (myDir * (_thunderTime * distanceStep));

        check_flashPrep = true;

    }

    public void CooldownThunder() {

        check_thunder = false;
        check_flash = true;

        AudioSource.PlayClipAtPoint(thunder, _dir);

        flash_timeStamp = Time.time;

    }

}
