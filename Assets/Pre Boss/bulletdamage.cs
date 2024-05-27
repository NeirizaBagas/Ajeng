using UnityEngine;

public class bulletdamage : MonoBehaviour
{
    public float damage = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth2 playerHealth = other.GetComponent<PlayerHealth2>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Damage dealt to player: " + damage);
            }
            else
            {
                Debug.LogError("PlayerHealth2 component not found on Player");
            }
        }
    }
}