using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCJalan : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    public Animator anim;
    public Transform currentPoint;
    public float speed;
    public float Circle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.enabled == true)
        {
            anim.SetBool("isWalk", true);
        }

        if (GetComponent<EnemyController>().Health == 0) return;

        Vector2 point = currentPoint.position - transform.position;
        rb.velocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
    }

    private void Flip()
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, Circle);
        Gizmos.DrawWireSphere(PointB.transform.position, Circle);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == PointB)
        {
            Flip();
            currentPoint = PointA.transform;
        }if(collision.gameObject == PointA)
        {
            Flip();
            currentPoint = PointA.transform;
        }
    }
}
