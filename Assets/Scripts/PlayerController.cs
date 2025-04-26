using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float movespeed = 5f; // Speed of the player
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement(); // Call the movement handling method
    }
    private void HandleMovement()
    {
        // Get input from the player
        float moveX = Input.GetAxis("Horizontal"); // Horizontal input (A/D or Left/Right Arrow)
        float moveY = Input.GetAxis("Vertical"); // Vertical input (W/S or Up/Down Arrow)

        // Create a new Vector2 for movement direction
        Vector2 movement = new Vector2(moveX, moveY).normalized; // Normalize to prevent faster diagonal movement

        // Move the player using Rigidbody2D
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime); // Move the player based on input and speed
    }
}
