using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovenment : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 600;
    public float jumpForce = 10;
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius = 0.05f;
    public LayerMask groundLayer;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor;
    float lastTimeGrounded;

    // Execute when scean start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update every frame
    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
    }

    // Movenment
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float moveBy = x * speed;
        moveBy *= Time.deltaTime;
        
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

    }

    void Jump()
    {

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (colliders != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

}
