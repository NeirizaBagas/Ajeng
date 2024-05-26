using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private const string ATTACK_PARAM = "Attack";
    private const string CHASING_PARAM = "IsChasing";

    [SerializeField] private ENEMY_STATE state;

    [Header("Patrol Setting:")]
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    private Transform currentPoint;
    [SerializeField] private float speed;
    [SerializeField] private float audioDelay;

    
    [Space(5)]

    [Header("Chase Setting:")]
    [SerializeField] private float chasingRange; // Jarak maksimum di mana musuh akan mengejar pemain
    private Transform playerTransform;
    private Transform enemyTransform;
    private PlayerController player;
    [Space(5)]

    [Header("Attack Setting:")]
    //[SerializeField] private float damage;
    [SerializeField] private float attackRange = 1f;
    private PlayerHealth health;
    [Space(5)]

    private Animator anim;
    private Vector2 defaultLocalScale;

    
   
    // Start is called before the first frame update
    void Start()
    {

        currentPoint = pointB.transform;
        defaultLocalScale = transform.localScale;
        
        player = PlayerController.Instance;
        if (player != null)
        {
            playerTransform = player.transform;
            health = playerTransform.GetComponent<PlayerHealth>();
        }
        enemyTransform = transform;
        anim = GetComponent<Animator>();
        
        if (state == ENEMY_STATE.PATROL)
        {
            StartCoroutine(PlayPatrolSound());
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        StateCheck();
    }

    private void StateCheck()
    {
        switch (state)
        {
            case ENEMY_STATE.PATROL:
                Patrol();
                break;
            case ENEMY_STATE.CHASE:
                Chase();
                break;
            case ENEMY_STATE.ATTACK:
                Attack();
                break;
        }
    }

    // Membalik arah enemy
    void Flip(bool isRight)
    {
        float XDir = isRight ? defaultLocalScale.x * 1 : defaultLocalScale.x * -1;
        
        transform.localScale = new Vector2(XDir, transform.localScale.y);
    }

    void Patrol()
    {

        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);

        float distance = Vector2.Distance(transform.position, currentPoint.position);

       

        if (distance <= 0.5f)
        {
            currentPoint = currentPoint == pointB.transform ? pointA.transform : pointB.transform;
        }

        float playerDistance = Vector2.Distance(transform.position, player.transform.position);

        if(playerDistance <= chasingRange)
        {
            Lvl1AudioManager.instance.PlaySFX("EChase");
            StopAllCoroutines();
            state = ENEMY_STATE.CHASE;
        }

        if (currentPoint.position.x > transform.position.x)
        {
            Flip(true);
        }
        else
        {
            Flip(false);
        }

        
    }

    //mengubah arah enemy ke player & Bergerak menuju player
    void Chase()
    {
        if (player == null && PlayerHealth.Instance.health <= 0) { return; }
        
        anim.SetBool(CHASING_PARAM, true);

        //nyari jarak player ke enemy
        float distanceToPlayer = Vector2.Distance(enemyTransform.position, player.transform.position);

        Vector2 pPose = player.transform.position;
        pPose.y = transform.position.y;
        transform.position = Vector2.MoveTowards(transform.position, pPose, speed * Time.deltaTime);

        if (playerTransform.position.x > transform.position.x)
        {
            Flip(true);
        }
        else if (playerTransform.position.x < transform.position.x)
        {
            Flip(false);
        }

        if (distanceToPlayer <= attackRange)
        {
            StopAllCoroutines();
            state = ENEMY_STATE.ATTACK;
        }
        else if (distanceToPlayer >= chasingRange)
        {
            StartCoroutine(PlayPatrolSound());
            state = ENEMY_STATE.PATROL;
        }

        
    }

    //Attack ke player
    void Attack()
    {
        if (PlayerHealth.Instance.health <= 0) return;

        anim.SetTrigger(ATTACK_PARAM);

        float distanceToPlayer = Vector2.Distance(enemyTransform.position, player.transform.position);

        if (distanceToPlayer >= attackRange)
            state = ENEMY_STATE.CHASE;

    }

    public void PlayAttackSound()
    {
        Lvl1AudioManager.instance.PlaySFX("EAttack");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);

        // Menampilkan lingkaran untuk area jangkauan chase
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingRange);

        // Menampilkan lingkaran untuk area jangkauan serang
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private IEnumerator PlayPatrolSound()
    {
        Lvl1AudioManager.instance.PlaySFX("EPatrol");
        yield return new WaitForSeconds(audioDelay);
        StartCoroutine(PlayPatrolSound());
    }
}

public enum ENEMY_STATE
{

    PATROL,
    CHASE,
    ATTACK,
}
