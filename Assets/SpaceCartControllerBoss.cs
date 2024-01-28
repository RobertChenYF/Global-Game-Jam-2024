
using UnityEngine;

public class SpaceCartControllerBoss : MonoBehaviour
{
    // A reference to the Rigidbody2D component
    public Boss boss;
    public GameObject square;
    public GameObject quote;
    // The speed of the player movement
    public float speed = 5f;
    public float moveRange = 1.5f;
    public float alphaChangeSpeed = 0.01f;
    public float maxSquareAlpha = 0.8f;

    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -10f;
    public float maxY = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer squareSR;
    private float moveTime;
    private float nextMoveTime;
    private Vector3 originLocation;
    private Vector3 moveDirection;

    public GameObject scrollBackground;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component from the game object
        rb = GetComponent<Rigidbody2D>();
        squareSR = square.GetComponent<SpriteRenderer>();
        moveTime = 0f;
        nextMoveTime = 0.3f;
        originLocation = transform.position;
        quote.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scrollBackground.transform.position -= new Vector3(0, 7 * Time.deltaTime, 0);
        if (boss.health > 0)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Create a vector for the movement direction
            Vector2 direction = new Vector2(horizontal, vertical);

            // Move the rigidbody in the direction with the speed
            rb.velocity = direction * speed;
        }
        else
        {
            moveTime += Time.deltaTime;
            if (moveTime >= nextMoveTime)
            {
                RandomizeMoveDirection();
                moveTime = 0;
                nextMoveTime = Random.Range(0.4f, 1.2f);
            }
            AutoMove();
            if (squareSR.color.a <= maxSquareAlpha)
            {
                Color spriteColor = squareSR.color;
                Debug.Log(Time.deltaTime);
                spriteColor.a += alphaChangeSpeed * Time.deltaTime;
                squareSR.color = spriteColor;
            }
            else
            {
                quote.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Bullet>() != null)
        {
            GlobalVariables.money -= Random.Range(8000,10000);
            Destroy(col.gameObject);
        }
    }

    void RandomizeMoveDirection()
    {
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void AutoMove()
    {
        if (transform.position.x - originLocation.x >= moveRange)
        {
            moveDirection.x = -Mathf.Abs(moveDirection.x);
        }
        else if (transform.position.x - originLocation.x <= - moveRange)
        {
            moveDirection.x = Mathf.Abs(moveDirection.x);
        }

        if (transform.position.y - originLocation.y >= moveRange)
        {
            moveDirection.y = -Mathf.Abs(moveDirection.y);
        }
        else if (transform.position.y - originLocation.y <= - moveRange)
        {
            moveDirection.y = Mathf.Abs(moveDirection.y);
        } 

        rb.velocity = moveDirection * speed * 0.6f;
    }
}