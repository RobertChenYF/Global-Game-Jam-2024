using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bullet : MonoBehaviour
{
    public float bulletLife = 1f;  // Defines how long before the bullet is destroyed
    public float rotation = 0f;
    public float speed = 1f;
    public char chara = ' ';

    private Vector2 spawnPoint;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
        GetComponent<TextMeshPro>().text = chara.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if(timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }


    private Vector2 Movement(float timer) {
        // Moves down according to the bullet's rotation
        float x = timer * speed * transform.right.y;
        float y = - timer * speed * transform.right.x;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }
}

