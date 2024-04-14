using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxScript : MonoBehaviour
{
    public float damage;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.TryGetComponent(out PlayerHealth health))
        //{
        //    health.TakeDamage(10);
        //}

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit");
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
