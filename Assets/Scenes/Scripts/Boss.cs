using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 40;
    public GameObject spawner;
    public float moveRange = 1.5f;
    public float moveInterval = 2f;
    public float moveSpeed = 1f;  
    public float minPercent = 0.3f;
    public float maxPercent = 0.7f;
    public float minBulletSpeed = 2.0f;
    public float maxBulletSpeed = 4.0f;
    public float minBulletLife = 4.0f;
    public float maxBulletLife = 8.0f;
    public int minBulletNums = 10;
    public int maxBulletNums = 20;
    public float minSpawnerLife = 6.0f;
    public float maxSpawnerLife = 8.0f;


    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector3 originLocation;
    private float moveTimer;
    private float nextMoveTime;
    private float bulletTimer;
    private float nextBulletTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextBulletTime = 0.1f;
        nextMoveTime = 0.3f;
        bulletTimer = 0f;
        moveTimer = 0f;
        originLocation = transform.position;
    }

    void Update()
    {
        moveTimer += Time.deltaTime;
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= nextBulletTime) {
            GenerateRandomSpawner();
            GenerateRandomSpawner();
            bulletTimer = 0;
            nextBulletTime = Random.Range(1.5f, 2.5f);
        }

        if (moveTimer >= nextMoveTime) {
            RandomizeMoveDirection();
            moveTimer = 0;
            nextMoveTime = Random.Range(0.4f, 1.2f);
        }

        Move();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<GoodBullet>() != null)
        {
            Destroy(col.gameObject);
            health -= 1;
            Debug.Log($"Good Bullet Destroyed, Current Health {health}");
        }
    }

    void GenerateRandomSpawner()
    {
        Vector3 randomPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(minPercent, maxPercent), Random.Range(0.5f, 1.0f), 0.2f));
        randomPosition.z = -2f;
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(180f, 360f));
        float bulletLife = Random.Range(minBulletLife, maxBulletLife);
        float speed = Random.Range(minBulletSpeed, maxBulletSpeed);
        int bulletNums = Random.Range(minBulletNums, maxBulletNums);
        float spawnerLife = Random.Range(minSpawnerLife, maxSpawnerLife);
        BulletSpawner.SpawnerType spawnerType = (Random.Range(0f, 1f) > 0.40f) ? BulletSpawner.SpawnerType.Spin : BulletSpawner.SpawnerType.Circle;      
        GenerateSpawner(randomPosition, randomRotation, bulletLife, speed, bulletNums, spawnerLife, spawnerType);
    }

    void GenerateSpawner(Vector3 location, Quaternion rotation, float bulletLife, float speed, int bulletNums, float spawnerLife, BulletSpawner.SpawnerType spawnerType)
    {
        GameObject spawnerObject = Instantiate(spawner, location, rotation);
        spawnerObject.GetComponent<BulletSpawner>().speed = speed;
        spawnerObject.GetComponent<BulletSpawner>().bulletLife = bulletLife;
        spawnerObject.GetComponent<BulletSpawner>().spawnerLife = spawnerLife;
        spawnerObject.GetComponent<BulletSpawner>().bulletNums = bulletNums;
        spawnerObject.GetComponent<BulletSpawner>().spawnerType = spawnerType;
    }

    void RandomizeMoveDirection()
    {
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Move()
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

        rb.velocity = moveDirection * moveSpeed;
    }
}
