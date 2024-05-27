using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float health = 100f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        // Tambahkan logika kemenangan pemain
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Logika untuk menyerang pemain
        }
    }
}