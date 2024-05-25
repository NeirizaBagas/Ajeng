using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComboAttack : MonoBehaviour
{
    public static ComboAttack Instance;

    public bool canReceiveInput;
    public bool inputReceived;

    [Header("Attack Settings:")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] float damage;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputReceived = true;
            canReceiveInput = false;
            PerformAttack();
        }
        else
        {
            return;
        }
    }

    public void InputManager()
    {
        if (!inputReceived)
        {
            canReceiveInput = true;
        }
        else
        {
            canReceiveInput = false;
        }
    }

    private void PerformAttack()
    {
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

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
