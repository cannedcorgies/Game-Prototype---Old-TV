using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{

    public bool activated;

    public float speed;

    public GameObject path;
    public int index = 0;
    [SerializeField] private int maxIndex;
    [SerializeField] private Vector3 targetPos;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
        name = gameObject.name;

        maxIndex = path.transform.childCount;
        targetPos = path.transform.GetChild(index).transform.position;

        rb = gameObject.GetComponent<Rigidbody>();

        Debug.Log("hi from " + name);
        Debug.Log(" -- my speed: " + speed);
        Debug.Log(" -- my number of children: " + maxIndex);
        Debug.Log(" -- starting at child number " + index);
        Debug.Log(" -- starting target pos: " + targetPos);

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 currentPos = transform.position;
        
        //rb.MovePosition(targetPos * Time.deltaTime * speed);

        // Debug.Log(name + " targetPos: " + targetPos);
        // Debug.Log(" -- currentPos: " + currentPos);

        Vector3 targetDir = (targetPos - currentPos).normalized;

        // Debug.Log(" -- target direction: " + targetDir);

        rb.velocity = targetDir * speed;
        //rb.MovePosition(currentPos + targetDirection * speed * Time.deltaTime * -1);

        // Debug.Log(" -- velocity: " + rb.velocity);
        // Debug.Log(" --- calculation: " + (targetDir * speed));

    }


    void OnTriggerEnter(Collider other)
    {

        /*Debug.Log(name + " should've triggered");

        Debug.Log(" -- other id: " + other.GetInstanceID());
        Debug.Log("     - " + other.transform.position);
        Debug.Log(" -- child id: " + path.transform.GetChild(index).GetInstanceID());
        Debug.Log("     - " + path.transform.GetChild(index).transform.position);*/

        if (other.transform.position == path.transform.GetChild(index).transform.position) {

            //Debug.Log(" -- objects match");

            index += 1;
            if (index >= maxIndex) {

                index = 0;

            }

            targetPos = path.transform.GetChild(index).transform.position;

            //Debug.Log(name + " new target pos: " + targetPos);
            //Debug.Log(" -- new index: " + index);

        }

    }

}
