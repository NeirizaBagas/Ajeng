using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth2 : MonoBehaviour
{
    public int health;
    public int MaxHealth;
    [HideInInspector] public PlayerStateList pState;
    Animator anim;
    public Slider healthBar;
    public int quantityData;
    public int healingValue;
    public TextMeshProUGUI quantityDataText;

    public static PlayerHealth2 Instance;
    public SceneManagement gameOver;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        health = MaxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        pState = GetComponent<PlayerStateList>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)//Kondisi mati
        {
            health = 0;
            //gameObject.GetComponent<PlayerHealth>().enabled = false;
            anim.Play("Player_Death");
            PlayerController.Instance.walkSpeed = 0;
            FindObjectOfType<SceneManagement>().EndGame();

        }

        if (quantityData != 0)//Heal 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                quantityData -= 1;
                quantityDataText.text = "" + quantityData;
                health += healingValue;
            }
        }


        healthBar.value = health;
    }

    public void TakeDamage(float damage)//kena damage
    {
        if (health <= 0) return;
        health -= Mathf.RoundToInt(damage);
        //anim.SetBool("TakeDamage", true);
        //Lvl1AudioManager.instance.PlaySFX("PTakeDamage");
        StartCoroutine(StopTakingDamage());

    }

    //
    IEnumerator StopTakingDamage()
    {
        pState.invicible = true;
        anim.SetTrigger("TakeDamage");
        ClampHealth();
        yield return new WaitForSeconds(1f);
        pState.invicible = false;
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, MaxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)//potion
    {
        if (collision.gameObject.CompareTag("Potion"))
        {
            Destroy(collision.gameObject);
            quantityData += 1;
            quantityDataText.text = "" + quantityData;
        }
    }


}