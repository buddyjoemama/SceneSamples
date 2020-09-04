using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMove(InputValue move)
    {
        Vector2 movementVector = move.Get<Vector2>();
        this.movementX = movementVector.x;
        this.movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        if (onWall)
        {
            Physics.gravity = new Vector3(0, 0, Physics.gravity.magnitude);
            rb.AddForce(new Vector3(this.movementX, this.movementY, 0) * speed);
        }
        else
        {
            Physics.gravity = new Vector3(0, -Physics.gravity.magnitude);
            rb.AddForce(new Vector3(this.movementX, 0, this.movementY) * speed);
        }
    }

    bool onWall = false;

    private void OnCollisionStay(Collision collision)
    {
        onWall = collision.collider.CompareTag("GravityWall");
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
}
