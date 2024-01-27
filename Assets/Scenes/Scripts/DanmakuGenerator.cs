using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DanmakuGenerator : MonoBehaviour
{
    public GameObject danmaku;
    public GameObject player;
    public float speed = 2f;
    public float minKey;
    public Dictionary<float,string> danmakus = new Dictionary<float,string>() {
        {1.0f, "示例文本1"},
        {2.0f, "示例文本2"},
        {3.0f, "示例文本3"},
        {4.0f, "示例文本4"},
        {5.0f, "示例文本5"},
        {6.0f, "示例文本6"},
        {7.0f, "示例文本7"},
        {8.0f, "示例文本8"},
        {9.0f, "示例文本9"},
        {10.0f, "示例文本10"},
        {11.0f, "示例文本11"},
        {12.0f, "示例文本12"},
        {12.5f, "示例文本13"},
        {13.0f, "示例文本14"},
        {13.5f, "示例文本15"},
        {14.0f, "示例文本16"},
        {15.0f, "示例文本17"},
        {16.0f, "示例文本18"},
        {18.0f, "示例文本19"}
    };

    private float time = 0f;
    
    void Start()
    {
        time = 0f;
        minKey = GetMinDanmakuKey();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > minKey && danmakus.Count > 0)
        {
            Generate(danmakus[minKey]);
            danmakus.Remove(minKey);
            if (danmakus.Count >0)
            {
                minKey = GetMinDanmakuKey();
            }
        }

    }
    
    public void Generate(string text)
    {
        Vector3 randomPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(1.1f, 1.2f), 0.2f));
        randomPosition.z = -2f;
        GameObject spawnedObject = Instantiate(danmaku, randomPosition, Quaternion.identity);
        spawnedObject.GetComponent<Danmaku>().SetText(text);
        spawnedObject.GetComponent<Danmaku>().SetSpeed(Random.Range(1f, 2f) * speed);
    }

    private float GetMinDanmakuKey()
    {
        return Mathf.Min(danmakus.Keys.ToArray());
    }
}
