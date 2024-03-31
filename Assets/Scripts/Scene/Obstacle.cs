using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float damage = 10;
    public float cdDamage = 1;
    private bool isDamaging = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDamaging = true;
            StartCoroutine(ApplyDamage(collision.gameObject.GetComponent<PlayerHealth>()));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDamaging = false;
        }
    }

    private IEnumerator ApplyDamage(PlayerHealth playerHealth)
    {
        while (isDamaging)
        {
            playerHealth.TakeDamage(damage);
            yield return new WaitForSeconds(cdDamage); // Adjust this value according to your needs
        }
    }
}
