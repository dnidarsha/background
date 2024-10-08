using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character movement
    public Rigidbody2D rb; // Reference to the Rigidbody2D component
    public Animator animator; // Reference to the Animator component
    public GameObject knifePrefab; // Reference to the knife prefab
    public Transform knifeSpawnPoint; // Point from where the knife is thrown
    public float knifeSpeed = 10f; // Speed of the thrown knife

    private Vector2 movement; // Stores the player's movement
    private float timeBetweenPresses = 0.3f; // Time allowed between presses for combo
    private float lastSpacePressTime = 0f; // Tracks the time of the last space press
    private int spacePressCount = 0; // Tracks how many times space has been pressed

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input (A/D or Left/Right arrow keys)
        movement.x = Input.GetAxisRaw("Horizontal");

        // Set the animation state to 1 (walking) if moving, or 0 (idle) if not moving
        if (movement.x != 0)
        {
            animator.SetInteger("State", 1); // Walking
        }
        else
        {
            animator.SetInteger("State", 0); // Idle
        }

        // Handle space bar for attack 1, attack 2 (double space), and attack 3 (triple space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float currentTime = Time.time;

            if (currentTime - lastSpacePressTime < timeBetweenPresses)
            {
                // Increment space press count if pressed within time window
                spacePressCount++;
            }
            else
            {
                // Reset if too much time has passed since the last press
                spacePressCount = 1;
            }

            lastSpacePressTime = currentTime; // Update last press time

            // Determine the attack based on the number of space presses
            if (spacePressCount == 1)
            {
                Attack1(); // Single space press - first attack
            }
            else if (spacePressCount == 2)
            {
                Attack2(); // Double space press - second attack
            }
            else if (spacePressCount == 3)
            {
                Attack3(); // Triple space press - third attack
                spacePressCount = 0; // Reset count after the third attack
            }
        }

        // Throw knife on Shift press
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            ThrowKnife(); // Call the function to throw a knife
        }

        // Flip the character sprite when moving left or right
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Face right
        }
    }

    // FixedUpdate is called a fixed number of times per second
    void FixedUpdate()
    {
        // Move the character horizontally using Rigidbody2D
        rb.MovePosition(rb.position + new Vector2(movement.x, 0f) * moveSpeed * Time.fixedDeltaTime);
    }

    // Function for the first attack (single space press)
    void Attack1()
    {
        animator.SetTrigger("Attack1"); // Trigger the first attack animation
        Debug.Log("Attack 1 triggered!");
    }

    // Function for the second attack (double space press)
    void Attack2()
    {
        animator.SetTrigger("Attack2"); // Trigger the second attack animation
        Debug.Log("Attack 2 triggered!");
    }

    // Function for the third attack (triple space press)
    void Attack3()
    {
        animator.SetTrigger("Attack3"); // Trigger the third attack animation
        Debug.Log("Attack 3 triggered!");
    }

    // Function to throw a knife when Shift is pressed
    void ThrowKnife()
    {
        // Instantiate the knife prefab at the spawn point
        GameObject knife = Instantiate(knifePrefab, knifeSpawnPoint.position, knifeSpawnPoint.rotation);

        // Get the Rigidbody2D component of the knife
        Rigidbody2D knifeRb = knife.GetComponent<Rigidbody2D>();

        // Determine the direction to throw the knife based on the character's facing direction
        Vector2 throwDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        // Apply force to the knife to throw it in the direction the character is facing
        knifeRb.velocity = throwDirection * knifeSpeed;

        Debug.Log("Knife thrown!");
    }
}
