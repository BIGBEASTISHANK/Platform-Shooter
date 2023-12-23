using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Variables
    /////////////

    private float nextFire;

    [Header("Values")]
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;

    [Header("Components & Others")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject player;

    // References
    //////////////

    private void FixedUpdate()
    {
        // Shoot function
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextFire)
        {
            // Controlling firerate
            Shoot();
            nextFire = Time.time + 1f / fireRate;
        }
    }

    // Shoot function
    private void Shoot()
    {
        // Creating bullet
        GameObject shootBullet = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
        shootBullet.SetActive(true);

        // Getting bullet script
        Bullet bulletScript = shootBullet.GetComponent<Bullet>();
        bulletScript.enabled = true;

        // Passing argument
        bulletScript.bulletSpeed = bulletSpeed;
        bulletScript.player = player; 
    }
}
