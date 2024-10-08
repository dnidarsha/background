using UnityEngine;

public class ManualEnemyMovement : MonoBehaviour
{
    public float speed = 5.0f;  // Speed of the enemy movement

    void Update()
    {
        // Get input from horizontal axis (left/right arrow keys or A/D keys)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Move the enemy based on input
        Vector3 movement = new Vector3(moveHorizontal * speed * Time.deltaTime, 0, 0);
        transform.Translate(movement);
    }
}