using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public float Health;
    public float walkSpeed;
    public bool flip;
    public float detectRange;
    public GameObject detect;
    public Transform playerPos;
    public LayerMask playerlayer;
    public Animator anim;
    //private AudioSource enemySound;
    //public AudioClip hurt;
    //public AudioClip die;
    //public float volume;
    public bool isDie;
    public GameObject PatrolDir;
    private NPCJalan npcJalan;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        npcJalan = GetComponent<NPCJalan>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Health == 0) return;

        //enemySound = GetComponent<AudioSource>();
        //if (PlayerStatus.instance.isDie)
        //{
        //    anim.enabled = false;
        //    this.enabled = false;
        //}

        DetectPlayer();
        Physics2D.IgnoreLayerCollision(6, 6, true);
        if (isDie)
        {
            npcJalan.speed = 0;
            walkSpeed = 0;
            this.enabled = false;
            PatrolDir.SetActive(false);
            Physics2D.IgnoreLayerCollision(6, 8, true);
        }
    }
    void DetectPlayer() //Deteksi Player dalam jangkauan gizmo, lalu mengejarnya
    {
        float Direction = playerPos.position.x - transform.position.x;
        Collider2D[] enemyDetect = Physics2D.OverlapCircleAll(detect.transform.position, detectRange, playerlayer);
        RaycastHit2D DetectPlayer = Physics2D.Raycast(detect.transform.position, Vector2.left, detectRange, playerlayer);

        if(DetectPlayer.collider == null)
        {
            anim.SetFloat("Walk", Mathf.Abs(0));
            StartCoroutine(Patrol()); //musuh kembali patroli jika tidak mendeteksi player
        }

        foreach (Collider2D player in enemyDetect) //mengejar player ketika mendeteksi player
        {
            rb.velocity = new Vector2(Direction * walkSpeed * Time.deltaTime, rb.velocity.y);

            StartCoroutine(Flip());
            anim.SetFloat("Walk", Mathf.Abs(walkSpeed));
            anim.SetBool("isWalk", false);

            npcJalan.enabled = false;
            PatrolDir.transform.position = gameObject.transform.position;
            //PatrolDir.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (detect == null) return;

        Gizmos.DrawWireSphere(detect.transform.position, detectRange);
    }

    IEnumerator Patrol() // delai lalu kembali patrol
    {
        yield return new WaitForSeconds(1);
        PatrolDir.SetActive(true);
        npcJalan.enabled = true;
    }

    IEnumerator Flip()
    {
        Vector2 scale = transform.localScale;
        if (playerPos.position.x > transform.position.x)
        {
            yield return new WaitForSeconds(0);
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }
        else
        {
            yield return new WaitForSeconds(0);
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);

        }
        transform.localScale = scale;
    }

    public void TakeDamage(float damage) //Musuh menerima damage
    {
        Health -= damage;
        anim.SetTrigger("Hurt");

        if(Health <= 0)
        {
            Health = 0;
            Die();
            GetComponent<EnemyController>().isDie = true;
        }
        //enemySound.PlayOneShot(hurt, volume);
    }
    void Die() // musuh mati
    {
        anim.SetBool("isDead", true);
        //enemySound.PlayOneShot(die, volume);
        this.enabled = false;
        //GetComponent<Collider2D>().enabled = false;
        npcJalan.enabled = false;
        //rb.gravityScale = 1;
    }
    
}
