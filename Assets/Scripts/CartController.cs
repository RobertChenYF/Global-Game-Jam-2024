using System.Collections;
using UnityEngine;

public class CartController : MonoBehaviour
{
    // The speed of the cart in units per second
    public float speed = 10f;

    // The y positions of the lanes that the cart can switch to
    public float[] lanes;

    // The current lane index of the cart
    private int laneIndex = 1;

    // The time it takes for the cart to switch lanes
    public float switchTime = 0.5f;

    // The angle of the cart when switching lanes
    public float switchAngle = -15f;

    // The current switch progress
    private float switchProgress = 0f;

    // The direction of the switch (-1 for down, 1 for up, 0 for none)
    private int switchDirection = 0;

    // The initial position and rotation of the cart
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    // The coroutine for switching lanes
    private Coroutine switchCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position and rotation of the cart
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the cart to the right at a constant speed
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Check the input for switching lanes
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Switch up if possible
            SwitchUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Switch down if possible
            SwitchDown();
        }
    }

    // Switch the cart up
    void SwitchUp()
    {
        // Check if the cart is not already switching or at the top lane
        if (switchDirection == 0 && laneIndex < lanes.Length - 1)
        {
            // Increment the lane index
            laneIndex++;

            // Set the switch direction to 1
            switchDirection = 1;

            // Store the initial position and rotation of the cart
            initialPosition = transform.position;
            initialRotation = transform.rotation;

            gameObject.GetComponent<SpriteRenderer>().sortingOrder -= 1;

            // Start the coroutine for switching lanes
            switchCoroutine = StartCoroutine(SwitchLane());
        }
    }

    // Switch the cart down
    void SwitchDown()
    {
        // Check if the cart is not already switching or at the bottom lane
        if (switchDirection == 0 && laneIndex > 0)
        {
            // Decrement the lane index
            laneIndex--;

            // Set the switch direction to -1
            switchDirection = -1;

            // Store the initial position and rotation of the cart
            initialPosition = transform.position;
            initialRotation = transform.rotation;

            gameObject.GetComponent<SpriteRenderer>().sortingOrder += 1;

            // Start the coroutine for switching lanes
            switchCoroutine = StartCoroutine(SwitchLane());
        }
    }

    // The coroutine for switching lanes
    IEnumerator SwitchLane()
    {
        // Loop until the switch progress reaches 1
        while (switchProgress < 1f)
        {
            // Update the switch progress
            switchProgress += Time.deltaTime / switchTime;

            // Clamp the switch progress between 0 and 1
            switchProgress = Mathf.Clamp01(switchProgress);

            // Lerp the position and rotation of the cart based on the switch progress and direction
            // Use the x and z values of the cart's position, and the y value of the lane
            transform.position = Vector3.Lerp(initialPosition, new Vector3(initialPosition.x + switchTime * speed, lanes[laneIndex], transform.position.z), switchProgress);
            // Use Quaternion.Euler to set the rotation of the cart to the exact angles
            transform.rotation = Quaternion.Euler(0, 0, -switchAngle * switchDirection * switchProgress);

            // Yield until the next frame
            yield return null;
        }

        // Reset the switch progress and direction
        switchProgress = 0f;
        switchDirection = 0;

        // Stop the coroutine
        StopCoroutine(switchCoroutine);

        // Set the rotation of the cart back to normal
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("hit car");
        }
    }
}
