// Bullet Spawner

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public enum SpawnerType { Straight, Spin, Circle }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public string quote;
    public float bulletLife = 1f;
    public float speed = 1f;


    [Header("Spawner Attributes")]
    public SpawnerType spawnerType;
    public int bulletNums = 15;
    public int bulletCounter = 0;
    public float spawnerLife = 4f;

    private GameObject spawnedBullet;
    private float timer = 0f;
    private float spawnTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (spawnerType == SpawnerType.Circle)
        {
            float intervalAngle = 360f/ bulletNums;
            int randomIndex = Random.Range(0, quote.Length);
            for (int i = 0; i < bulletNums; i++)
            {
                transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z + intervalAngle);
                Fire(i + randomIndex);
            }
            Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;
            spawnTimer += Time.deltaTime;           
            if(spawnerType == SpawnerType.Spin)
            {
                transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+1f);
            }
            if(timer >= spawnerLife / bulletNums) {
                Fire(bulletCounter);
                bulletCounter++;
                timer = 0;
            }
            if (spawnTimer >= spawnerLife){
                Destroy(gameObject);
                bulletCounter = Random.Range(0, quote.Length);
            }
        }
    }

    private void Fire(int index) {
        if(bullet) {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().chara = quote[index % quote.Length];
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
