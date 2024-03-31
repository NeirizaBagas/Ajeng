using System.Collections;
using UnityEngine;

public class DashMechanic : MonoBehaviour
{
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;
    [SerializeField] private GameObject dashEffect;

    private bool canDash = true;
    private bool dashed = false;
    private PlayerStateList pState;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        pState = GetComponent<PlayerStateList>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void StartDash()
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

    IEnumerator Dash()
    {
        canDash = false;
        pState.dashing = true;
        anim.SetTrigger("Dashing");
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        float dashDirection = transform.localScale.x;
        rb.velocity = new Vector2(transform.localScale.x * dashSpeed, 0);
        if (Grounded()) Instantiate(dashEffect, transform);

        yield return new WaitForSeconds(dashTime);

        rb.gravityScale = originalGravity;
        pState.dashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true; // Mengatur canDash menjadi true setelah cooldown selesai
    }


    private bool Grounded()
    {
        // Implementasi deteksi tanah sesuai kebutuhan Anda
        return Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }
}
