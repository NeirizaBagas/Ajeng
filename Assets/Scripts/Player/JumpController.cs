using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("Jump Setting:")]   
    [SerializeField] private float jumpForce = 45;
    private int jumpBufferCounter = 0;
    [SerializeField] private int jumpBufferFrames;
    

    [Header("Ground Check Setting:")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] private float checkRadius = 0.2f; // Set a default value
    

    [Header("Wall Slide Settings:")]
    [SerializeField] private Transform frontCheck;
    [SerializeField] private float wallSlidingSpeed;
    bool isTouchingFront;
    bool wallSliding;
    

    [Header("Wall Jump Settings:")]
    
    [SerializeField] private float yWallForce;
    [SerializeField] private float wallJumpTime;
    bool wallJumping;
    

    //Reference
    PlayerStateList pState;
    private Rigidbody2D rb;
    private float xAxis;
    Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        pState = GetComponent<PlayerStateList>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        UpdateJumpVariables();
        Inputs();
        WallClimbing();
        WallJumping();
        //Flip();
    }



    void WallJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && wallSliding)
        {
            wallJumping = true;
            rb.velocity = new Vector2(0, yWallForce);
        }

        // Periksa apakah pemain selesai melompat dari dinding
        if (wallJumping && rb.velocity.y <= 0)
        {
            wallJumping = false;
        }
    }





    void WallClimbing()
    {
        if (IsTouchingFront() && !Grounded() && Inputs() != 0)
        {
            wallSliding = true;
            anim.SetBool("WallClimbing", true);
        }
        else
        {
            wallSliding = false;
            anim.SetBool("WallClimbing", false);
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }


    float Inputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        return xAxis;
    }

    void Jump()
    {
        if (!pState.jumping)
        {
            if (jumpBufferCounter > 0 && Grounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                pState.jumping = true;
            }
        }


        anim.SetBool("Jumping", !Grounded());
    }

    void UpdateJumpVariables()
    {
        if (Grounded())
        {
            pState.jumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferFrames;
        }
        else
        {
            jumpBufferCounter--;
        }
    }

    public bool Grounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, whatIsGround);
    }

    public bool IsTouchingFront()
    {
        return Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);
    }
}
