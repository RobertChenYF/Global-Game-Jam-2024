using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Danmaku : MonoBehaviour
{   
    private TextMeshPro text;
    private float ySpeed = 0;

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * ySpeed;
        if (transform.position.y > 100)
        {
            Destroy(gameObject);
        }
    }
    
    public void SetText(string targetText)
    {
        text = GetComponent<TextMeshPro>();
        for (int i = 0; i < targetText.Length; i++)
        {
            text.text += targetText[i] + "\n";
        }
    }
    public void SetSpeed(float speed)
    {
        ySpeed = speed;
    }
    
}
