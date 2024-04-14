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
    private PlayerController playerController;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
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
                enemy.GetComponent<EnemyController>().TakeDamage(10);
            }
            
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
