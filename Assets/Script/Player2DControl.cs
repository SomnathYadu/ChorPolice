using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DControl : MonoBehaviour
{
    public float walkSpeed = 8f;                    // The fastest the player can travel in the x axis.
    public float jumpForce = 400f;                  // With how much force player will jump
    public LayerMask whatIsGround;                  // A mask determining what is ground to the character
    public float groundedRadius = 0.2f;
    Transform groundCheck;
    public float move = 0;
    Rigidbody2D rb;
    Animator anim;

    public bool grounded = false;
    bool facingLeft = true;

    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }

        //FOnr constant walking of player
        rb.velocity = new Vector2(walkSpeed / 2, rb.velocity.y);

        //For walk
        if (Input.GetKey(KeyCode.D) || move > 0)
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) || move < 0)
        {
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }

        //For Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("VSpeed", Mathf.Abs(rb.velocity.y));

        if (rb.velocity.x < 0)
        {
            if (!facingLeft)
                Flip();
        }
        //HELP:: joystick control if(fJoystick.Horizontal < 0f)
        else if (rb.velocity.x > 0)
        {
            if (facingLeft)
                Flip();
        }

    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    public void Jump()
    {
        if(grounded)
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
    }
}
