using UnityEngine;

public class ShooterController: MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to instantiate
    public float bulletSpeed = 10f; // The speed of the bullet
    public Transform firePoint; // The point where the bullet will be spawned

    // Update is called once per frame
    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a new bullet instance
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            // Get the rigidbody component of the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            // Add a force to the bullet in the direction of the fire point
            rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
