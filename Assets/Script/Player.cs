using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Variables
    /////////////

    private float moveKey;
    private Rigidbody2D rb;

    [Header("Values")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float groundCheckRadius;

    [Header("Components & Others")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject groundCheck;

    // References
    //////////////

    // Getting components
    private void Start() => rb = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        // Getting input
        moveKey = Input.GetAxis("Horizontal");

        // Move function
        if (moveKey != 0) Move();

        // Flip function
        Flip();

        // Jump function
        if (Input.GetKey(KeyCode.Space)) Jump();
    }

    // Move function
    private void Move()
    {
        rb.velocity = (new Vector2(moveKey * walkSpeed * Time.fixedDeltaTime, rb.velocity.y));
    }

    // Flip function
    private void Flip()
    {
        // Fliping Player
        if (moveKey > 0)
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 180, transform.localRotation.z);
        else if (moveKey < 0)
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 0, transform.localRotation.z);
    }

    // Jump function
    private void Jump()
    {
        // Check if player is grounded
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);

        // If grounded, jump
        if (isGrounded)
            rb.velocity = (new Vector2(rb.velocity.x, jumpHeight * Time.fixedDeltaTime));
    }

    // Kill player
    public void Kill() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
