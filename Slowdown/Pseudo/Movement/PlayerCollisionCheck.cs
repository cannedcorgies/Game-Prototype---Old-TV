using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionCheck : MonoBehaviour
{

    public LayerMask ground;

    public bool onGround;
    

    public float collisionRadius = 0.25f;
    public Vector3 bottomOffset;
    private Color debugCollisionColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.OverlapSphere(transform.position + bottomOffset, collisionRadius, ground).Length > 0) {
            onGround = true;
        } else {
            onGround = false;
        }

        //Debug.Log(onGround);

    }

}
