
using UnityEngine;

public class SpaceCartController : MonoBehaviour
{
    // A reference to the Rigidbody2D component
    private Rigidbody2D rb;

    // The speed of the player movement
    public float speed = 5f;

    // The boundaries of the game area
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -10f;
    public float maxY = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component from the game object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a vector for the movement direction
        Vector2 direction = new Vector2(horizontal, vertical);

        // Move the rigidbody in the direction with the speed
        rb.velocity = direction * speed;

        // Clamp the position of the rigidbody within the boundaries
        //rb.position = new Vector2(Mathf.Clamp(rb.position.x, minX, maxX), Mathf.Clamp(rb.position.y, minY, maxY));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log($"Player Hit by {col.name}");
    }
}