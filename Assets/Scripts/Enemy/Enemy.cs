using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    //[SerializeField] protected float recoilLength;
    //[SerializeField] protected float recoilFactor;
    //[SerializeField] protected bool isRecoiling = false;

    [SerializeField] protected PlayerController player;
    //[SerializeField] protected float speed;

    [SerializeField] protected float damage;
    [SerializeField] protected int battleAreaIndex;

    protected float recoilTimer;
    protected Rigidbody2D rb;
    private Animator anim;

    

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //player = PlayerController.Instance;
        anim = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        

        
    }


    public virtual void EnemyHit(float _damageDone, Vector2 _hitDirection, float _hitForce)
    {
        health -= _damageDone;
        //if (!isRecoiling)
        //{
        //    rb.AddForce(-_hitForce * recoilFactor * _hitDirection);
        //}

        if (health <= 0)
        {
            anim.SetBool("IsDead", true);
            gameObject.SetActive(false);
            BattleManager.instance.DeactivateBattleArea(battleAreaIndex);
        }
    }

    protected virtual void Attack()
    {
        PlayerHealth.Instance.TakeDamage(damage);
        anim.SetTrigger("IsAttacking");
    }
}
