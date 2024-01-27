// Bullet Spawner

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBulletSpawner : MonoBehaviour
{
    [Header("Bullet Attributes")]
    public GameObject[] bullets;
    public float bulletLife = 1f;    
    public float speed = 1f;


    [Header("Spawner Attributes")]
    public float firingRate = 0.4f;

    private GameObject spawnedBullet;
    private float timer = 0f;

    void Start()
    {
        transform.eulerAngles = new Vector3(0f,0f,90f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= firingRate) {
            Fire();
            timer = 0;
        }
    }

    private void Fire() {
        GameObject bullet = bullets[Random.Range(0, bullets.Length)];
        if (bullet) {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.transform.rotation = transform.rotation;
            spawnedBullet.GetComponent<GoodBullet>().speed = speed;
            spawnedBullet.GetComponent<GoodBullet>().bulletLife = bulletLife;    
        }
    }
}
