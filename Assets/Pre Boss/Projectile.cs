using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 direction;
    public float speed = 5f;

    public void Setup(Vector3 shootDirection)
    {
        direction = shootDirection.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}