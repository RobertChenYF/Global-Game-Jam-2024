// Bullet Spawner

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public string quote;
    public float bulletLife = 1f;
    public float speed = 1f;


    [Header("Spawner Attributes")]
    public SpawnerType spawnerType;
    public float firingRate = 1f;
    public float spawnerLife = 4f;


    private GameObject spawnedBullet;
    private float timer = 0f;
    private float spawnTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        if(spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+1f);
        if(timer >= firingRate) {
            Fire();
            timer = 0;
        }
        if (spawnTimer >= spawnerLife){
            Destroy(gameObject);
        }
    }

    private void Fire() {
        if(bullet) {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().chara = quote[Random.Range(0, quote.Length)];
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
