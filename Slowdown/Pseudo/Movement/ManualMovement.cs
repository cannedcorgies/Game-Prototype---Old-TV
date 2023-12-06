// Required Scripts: /////
//  - PlayerCollisionCheck.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMovement : MonoBehaviour
{

    private Rigidbody rb;
    private PlayerCollisionCheck coll;

    private float xMovement;
    private float yMovement;
    private Vector2 dir;

    public float speed = 10f;
    public float interpolation = 10f;
    public float jumpForce = 10f;

    public float fallMult = 2.5f;
    public float lowJumpMult = 2f;

    // Start is called before the first frame update
    void Start()
    {
        name = gameObject.name;

        rb = GetComponent<Rigidbody>();
        coll = GetComponent<PlayerCollisionCheck>();

        Debug.Log("hello from " + name);
        Debug.Log(" -- my speed: " + speed);
        Debug.Log(" -- my interpolation: " + interpolation);
        Debug.Log(" -- my fall multiplier: " + speed);
        Debug.Log(" -- my low jump multiplier: " + lowJumpMult);

    }

    // Update is called once per frame
    void Update()
    {

        xMovement = Input.GetAxis("Horizontal");
        yMovement = Input.GetAxis("Vertical");
        dir = new Vector2(xMovement, yMovement);
        
        Walk(dir);
        if (Input.GetKeyDown(KeyCode.UpArrow)) {

            if (coll.onGround) {

                Jump(Vector2.up);

            }

        }

        if (rb.velocity.y < 0) {

            rb.velocity += Vector3.up * Physics2D.gravity.y * (fallMult - 1) * Time.deltaTime;

        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow)) {

            rb.velocity += Vector3.up * Physics2D.gravity.y * (lowJumpMult - 1) * Time.deltaTime;

        }
        
    }

    void Walk(Vector2 dir)
    {

        rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), interpolation * Time.deltaTime);

    }

    void Jump(Vector2 dir) {

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity +=  new Vector3(dir.x, dir.y, 0f) * jumpForce;

    }
}


// Citations /////
//  - Adopted from mixandjam's Celeste Movement on GitHub:
//      https://github.com/mixandjam/Celeste-Movement