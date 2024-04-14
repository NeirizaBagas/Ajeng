using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrog : MonoBehaviour
{
    public float attackRange;
    public Animator anim;
    public Transform attackPoint;
    public LayerMask playerMask;

    // Update is called once per frame
    void Update()
    {
        Attacking();
    }

    void Attacking()
    {
        Collider2D[] detectPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);
        foreach (Collider2D item in detectPlayer)
        {
            //menyerang player ketika sudah dekat player
            anim.SetTrigger("Attack");
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
