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
    public int attackBuff;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple instances of ComboAttack detected! Destroying duplicate.");
            Destroy(gameObject);
        }
    }

    public void attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputReceived = true;
            canReceiveInput = false;
            PerformAttack();
        }
    }

    public void InputManager()
    {
        canReceiveInput = !inputReceived;
    }

    private void PerformAttack()
    {
        if (attackPoint == null)
        {
            Debug.LogError("Attack point is not assigned.");
            return;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (var enemy in hitEnemies)
        {
            var enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.EnemyHit(damage, (transform.position - enemy.transform.position).normalized, 100);
            }
            else
            {
                Debug.LogWarning("Enemy component not found on object: " + enemy.name);
            }

            var enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("EnemyController not found on object: " + enemy.name);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//keris
    {
        if (collision.gameObject.CompareTag("Keris"))
        {
            Destroy(collision.gameObject);
            damage += attackBuff;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
