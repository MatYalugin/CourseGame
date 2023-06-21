using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    float speed;
    public float defaultSpeed;
    public float sprintSpeed;
    public float jumpForce;
    bool sprintOn;
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = defaultSpeed;
    }

    private void Update()
    {
        Jump();
        Sprint();
        Move();

        if (sprintOn == true)
        {
            speed = sprintSpeed;
        }
        if (sprintOn == false)
        {
            speed = defaultSpeed;
        }
    }

    public void Move()
    {
        if(CheckGround())
        {
            float H = Input.GetAxis("Horizontal");
            float V = Input.GetAxis("Vertical");
            Vector3 Move = transform.right * H * speed + transform.forward * V * speed;
            rb.velocity = new Vector3(Move.x, rb.velocity.y, Move.z);
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && CheckGround())
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    public void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            sprintOn = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprintOn = false;
        }
    }

    public bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y + 0.1f);
    }
}
