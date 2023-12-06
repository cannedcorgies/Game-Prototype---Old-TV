using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public bool activated;

    public float speed;

    public GameObject spawn;
    public GameObject target;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
        name = gameObject.name;

        rb = gameObject.GetComponent<Rigidbody>();

        Debug.Log("hi from " + name);
        Debug.Log(" -- my speed: " + speed);

        transform.position = spawn.transform.position;

        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.transform.position;

        Vector3 targetDir = (targetPos - currentPos).normalized;

        rb.velocity = targetDir * speed;

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnEnable() {

        transform.position = spawn.transform.position;

        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.transform.position;

        Vector3 targetDir = (targetPos - currentPos).normalized;

        rb.velocity = targetDir * speed;

    }

}
