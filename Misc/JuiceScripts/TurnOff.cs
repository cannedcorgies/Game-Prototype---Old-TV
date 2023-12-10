using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{

    public float timeToOff = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SwitchOff(timeToOff));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SwitchOff(float timeToOff)
    {
        while (true)
        {

            yield return new WaitForSeconds(timeToOff);
            gameObject.SetActive(false);

        }
    }

    void OnEnable(){

        StartCoroutine(SwitchOff(timeToOff));

    }

}
