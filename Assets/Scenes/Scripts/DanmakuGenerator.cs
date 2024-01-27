using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanmakuGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // 需要生成的物体的预制体
    public float speed = 5f; // 物体的速度

    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0f);
        Vector3 targetPosition = Camera.main.ViewportToWorldPoint(randomPosition);
        Vector2 direction = (targetPosition - randomPosition).normalized;

        GameObject spawnedObject = Instantiate(objectPrefab, GetRandomSpawnPositionOutsideScreen(), Quaternion.identity);
        
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }
        else
        {
            Debug.LogError("物体上没有找到 Rigidbody2D 组件！");
        }
    }

    Vector3 GetRandomSpawnPositionOutsideScreen()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float randomX = Random.Range(1.2f, 2.2f) * screenWidth; // 在屏幕外右侧生成
        float randomY = Random.Range(0f, 1f) * screenHeight;

        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomX, randomY, 10f));

        return spawnPosition;
    }
}
