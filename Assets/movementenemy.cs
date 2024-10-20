using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float speed = 2f; // Speed of enemy movement
    public float followDistance = 5f; // Distance at which the enemy starts following

    private Rigidbody2D rb; // Reference to the Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Get the distance between the player and the enemy
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If within follow distance, move toward the player
        if (distanceToPlayer < followDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the enemy horizontally toward the player
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

            // Flip the enemy to face the player
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Face left
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1); // Face right
            }
        }
        else
        {
            // Stop the enemy's movement if out of range
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}