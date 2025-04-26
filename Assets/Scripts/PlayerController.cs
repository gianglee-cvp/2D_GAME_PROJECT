using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float movespeed = 5f; // Speed of the player
    [SerializeField] private float jumpForce = 15f; // Jump force of the player
    [SerializeField] private LayerMask groundLayer; // Layer for the ground    
    [SerializeField] private Transform groundCheck; // Transform to check if the player is on the ground

    private bool isGrounded; // Check if the player is on the ground
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
        HandleJump(); // Call the jump handling method
    }
    private void HandleMovement()
    {
        // Get input from the player
        float moveInput = Input.GetAxis("Horizontal"); // Horizontal input (A/D or Left/Right Arrow)
        rb.linearVelocity = new Vector2(moveInput * movespeed, rb.linearVelocity.y); // Set the velocity of the player

        if(moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Face right
        }
        else if(moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }   
        
    }
    private void HandleJump(){
        if (Input.GetButtonDown("Jump")&&isGrounded) // Check if the jump button is pressed
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Apply an upward force to the player
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // Check if the player is on the ground
    }
    
}
