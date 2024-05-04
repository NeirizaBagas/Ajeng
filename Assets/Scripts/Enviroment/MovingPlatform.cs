using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    int direction = 1;
    public bool requirePlayerOnPlatform = true; // Variable to control player requirement

    private void FixedUpdate()
    {
        if (!requirePlayerOnPlatform || IsPlayerOnPlatform()) // Check if the player is on the platform if required
        {
            Vector2 target = currentMoveTarget();

            Rigidbody2D platformRb = platform.GetComponent<Rigidbody2D>();
            if (platformRb != null)
            {
                Vector2 newPosition = Vector2.MoveTowards(platform.position, target, speed * Time.fixedDeltaTime);
                platformRb.MovePosition(newPosition);
            }
            else
            {
                platform.position = Vector2.Lerp(platform.position, target, speed * Time.fixedDeltaTime);
            }

            float distance = Vector2.Distance(target, platform.position);

            if (distance <= 0.1f)
            {
                direction *= -1;
            }
        }
    }

    Vector2 currentMoveTarget()
    {
        return direction == 1 ? startPoint.position : endPoint.position;
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.position, startPoint.position);
            Gizmos.DrawLine(platform.position, endPoint.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0;
            }
            requirePlayerOnPlatform = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 1;
            }
        }
    }

    bool IsPlayerOnPlatform()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(platform.position, platform.localScale.x / 2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
