using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Variables
    /////////////

    private Rigidbody2D rb;
    private bool lookingRight;

    [HideInInspector] public float bulletSpeed;
    [HideInInspector] public GameObject player;

    // References
    //////////////

    // Initial values
    private void Start()
    {
        // Getting component
        rb = GetComponent<Rigidbody2D>();

        // Checking is player is looking right
        if (player.transform.localRotation.y == 0) lookingRight = false;
        else lookingRight = true;
    }

    // Move Bullet function
    private void FixedUpdate() => MoveBullet();

    // Move Bullet function
    private void MoveBullet()
    {
        // Moving Bullet
        if (lookingRight)
            rb.AddForce(Vector2.right * bulletSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        else
            rb.AddForce(Vector2.left * bulletSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Destroying bullet
        if (other.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
