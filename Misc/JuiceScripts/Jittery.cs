using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jittery : MonoBehaviour
{

    public float strength = 5f;
    private Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {

        initialPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        var sphereGuess = Random.insideUnitSphere;
        transform.position = (initialPos) + (sphereGuess * strength);
        
    }
}
