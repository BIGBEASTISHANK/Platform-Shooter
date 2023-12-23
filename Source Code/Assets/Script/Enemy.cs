using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables
    /////////////

    private Vector2 position, target;

    [Header("Components & Others")]
    [SerializeField] private float speed;
    [SerializeField] private GameObject player;

    // Getting player gameobject
    private void Start() => player = GameObject.Find("Player");


    private void FixedUpdate()
    {
        // Move speed
        float step = speed * Time.fixedDeltaTime;

        // Positions
        position = gameObject.transform.position;
        target = player.transform.position;

        // Moving enemy to player
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Killing enemy
        if (other.gameObject.tag == "Bullet")
            Destroy(gameObject);
        else if (other.gameObject.tag == "Player")
        {
            // Getting player Script
            Player playerScript = player.GetComponent<Player>();

            // Killing player
            playerScript.Kill();
        }
    }
}
