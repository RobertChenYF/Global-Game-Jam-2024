using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DanmakuGenerator : MonoBehaviour
{
    public GameObject danmaku;
    public GameObject player;
    public float speed = 2f;
    public float minPercent = 0.3f;
    public float maxPercent = 0.7f;
    public float minKey;
    public Dictionary<float,string> danmakus = new Dictionary<float,string>() {
        {0.5f, "在这个神秘的星球上"},
        {2.5f, "藏着一个令人不安的谜团"},
        {5.5f, "一位幽灵漂浮在星球的废弃"},
        {8.5f, "时常出没于废墟之间"},
        {11.0f, "星球的居民"},
        {12.5f, "奇异而友好的生物"},
        {15.0f, "发现他们对一种特殊煎饼"},
        {18.0f, "产生了强烈的需求"},
        {20.5f, "这种煎饼不仅味道美妙"},
        {23.5f,"还具有神秘的能量"},
        {25.5f,"使得食用者充满活力"},
        {27.5f,"煎饼成为了他们日常生活的"},
        {31.0f,"不可或缺的一部分"},
        {33.0f,"而在传说中"},
        {34.5f,"煎饼与幽灵有某种特殊的联"},
        {38.0f,"于是寻找煎饼的秘密"},
        {41.5f,"成为了居民们共同的使命"}
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
        Vector3 randomPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(minPercent, maxPercent), Random.Range(-0.3f, -0.5f), 0.2f));
        randomPosition.z = -2f;
        GameObject spawnedObject = Instantiate(danmaku, randomPosition, Quaternion.identity);
        spawnedObject.GetComponent<Danmaku>().SetText(text);
        spawnedObject.GetComponent<Danmaku>().SetSpeed(Random.Range(0.5f, 0.8f) * speed);
    }

    private float GetMinDanmakuKey()
    {
        return Mathf.Min(danmakus.Keys.ToArray());
    }
}
