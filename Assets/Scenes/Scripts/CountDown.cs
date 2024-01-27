using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public BuyButton buyButton;
    public Progress progress;

    public float countdownDuration = 10f;
    private float time;
    private TextMeshPro text;

    void Start()
    {
        time = countdownDuration;
        text = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            time = Mathf.Max(0, time);
            text.text = $"{time.ToString("F2")}";
        }
        else if (buyButton.count < progress.progressCount)
        {
            Debug.Log("Game Over");
        }
    }
}
