using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [Header("Horizontal Movement Settings:")]
    [SerializeField] public float walkSpeed = 1;

    [Header("Ground Check Settings:")]
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    public float groundCheckRadius; // Add groundCheckRadius
    public float radius = 0.2f; // Set a default value
    [Space(5)]

    [Header("Dash Setting:")] 
    [SerializeField] public float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;
    //[SerializeField] GameObject dashEffect;
    [Space(5)]


    // References
    [HideInInspector] public PlayerStateList pState;
    private Rigidbody2D rb;
    private float xAxis;
    
    Animator anim;
    private bool canDash;
    private bool dashed;
    private bool isRight;

    public static PlayerController Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        pState = GetComponent<PlayerStateList>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        canDash = true; // Inisialisasi canDash ke true saat mulai permainan
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckPoint.position, radius);
        
       
    }

    void Update()
    {
        GetInputs();
        if (pState.dashing) return;
        Flip();
        Move();
        Jump();
        StartDash();
       
    }

    void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        
    }

    //Flip
    void Flip()
    {
        if(xAxis < 0)
        {
            isRight = false;
            transform.localScale = new Vector2(-1f, transform.localScale.y);
        }
        if(xAxis > 0)
        {
            isRight = true;
            transform.localScale = new Vector2(1f, transform.localScale.y);
        }
    }

    //move
    public void Move()
    {
        rb.velocity = new Vector2(walkSpeed * xAxis, rb.velocity.y);
        anim.SetBool("Walking", rb.velocity.x != 0 && Grounded());
        
    }

    //dash
    void StartDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !dashed)
        {
            StartCoroutine(Dash());
            dashed = true;
        }

        if (Grounded())
        {
            dashed = false;
        }
    }

    //dash
    IEnumerator Dash() //Untuk bagian dash
    {
        canDash = false;
        pState.dashing = true;
        anim.SetTrigger("Dashing");
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        // Menggunakan nilai xAxis untuk menentukan arah dash
        float dashDirection = Mathf.Sign(xAxis);
        if (isRight) dashDirection = 1;
        else dashDirection = -1;
        rb.velocity = new Vector2(dashDirection * dashSpeed, 0);
        //if (Grounded()) Instantiate(dashEffect, transform);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravity;
        pState.dashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }




    public bool Grounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
    }

    //jump
    void Jump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);

            pState.jumping = false;
        }
    }

    public void PlayerStepSound()
    {
        Lvl1AudioManager.instance.PlaySFX("PJalan");
    }
}
