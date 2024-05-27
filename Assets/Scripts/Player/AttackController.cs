using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour
{
    [Header("Attack Settings:")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] float damage;
    
    private float yAxis;
    private bool attack = false;
    private float timeBetweenAttack = 0.5f;
    private float timeSinceAttack = 0f;
    
    
    //public Transform attackJarak;
    
    private Animator anim;
    private PlayerController pCon;
    private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pCon = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInputs();
       
        Attack();
    }

    private void GetInputs()
    {
        attack = Input.GetKeyDown("n");
        yAxis = Input.GetAxisRaw("Vertical");
    }

    private void Attack()
    {
        timeSinceAttack += Time.deltaTime;

        if (attack && timeSinceAttack >= timeBetweenAttack )
        {
            timeSinceAttack = 0;
            anim.SetTrigger("Attacking");
            Lvl1AudioManager.instance.PlaySFX("PAttack");
            //pCon.enabled = false;
            //rb.velocity = Vector2.zero;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            for (int i = 0; i < hitEnemies.Length; i++)
            {
                if (hitEnemies[i].GetComponent<Enemy>() != null)
                {
                    hitEnemies[i].GetComponent<Enemy>().EnemyHit(damage, (transform.position - hitEnemies[i].transform.position).normalized, 100);

                }
            }

            foreach (var enemy in hitEnemies)
            {
                // Memastikan enemy memiliki komponen EnemyController sebelum memanggil TakeDamage
                var enemyController = enemy.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.TakeDamage(10);
                }
                else
                {
                    Debug.LogWarning("Enemy does not have an EnemyController component.");
                }

                // Memastikan enemy memiliki komponen Enemy sebelum memanggil EnemyHit
                var enemyComponent = enemy.GetComponent<Enemy>();
                if (enemyComponent != null)
                {
                    enemyComponent.EnemyHit(damage, (transform.position - enemy.transform.position).normalized, 100);
                }
                else
                {
                    Debug.LogWarning("Enemy does not have an Enemy component.");
                }
            }
            
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
