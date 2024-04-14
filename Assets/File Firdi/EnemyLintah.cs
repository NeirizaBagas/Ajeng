using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLintah : MonoBehaviour
{
    public float attackRange;
    public Animator anim;
    public Transform attackPoint;
    public LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (GetComponent<EnemyController>().Health <= 0)
        //{
        //    return;
        //}

        //if (GetComponent<EnemyController>().Health > 0)
        //{
        //}
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        Collider2D[] detectPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);
        foreach (Collider2D item in detectPlayer)
        {
            yield return new WaitForSeconds(0.5f);
            anim.SetTrigger("Attack");
            GetComponent<EnemyController>().isDie = true;
            GetComponent<EnemyController>().Health = -10;
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
