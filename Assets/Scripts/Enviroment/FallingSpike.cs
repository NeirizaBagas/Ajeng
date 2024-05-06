using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bcoll;
    public float distance;
    bool isFalling;
    public float damage;
    private bool damageDealt;
    public float gravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bcoll = GetComponent<BoxCollider2D>();
    }

    void OnDrawGizmosSelected()
    {
        // Draw a gizmo indicating the distance
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * distance);
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position,Vector2.down * distance, Color.red);

            if(hit.transform != null) 
            {
                if (hit.transform.tag == ("Player"))
                {
                    rb.gravityScale =gravity;
                    isFalling = true;
                }
               /* else if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    // Stop falling if collides with ground
                    rb.gravityScale = 0;
                    rb.velocity = Vector2.zero;
                    isFalling = true;
                }*/
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth.Instance.TakeDamage(damage);
            damageDealt = true;

            damage = 0;
            Destroy(gameObject);
        }
        else
        {
           Destroy(gameObject);
        }
    }

    

}
