using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
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

    private void OnFire()
    {

    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(this.movementX, 0.0f, this.movementY) * speed);
    }
}
