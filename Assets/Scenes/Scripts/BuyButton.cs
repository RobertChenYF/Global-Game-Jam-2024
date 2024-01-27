using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public int count = 0;
    void Start()
    {
        DisplayCount();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseCount();           
        }
    }

    void OnMouseDown()
    {        
        IncreaseCount();        
    }

    public void IncreaseCount()
    {
        count++;
        DisplayCount();
    }

    void DisplayCount()
    {
        // 将计数显示在控制台
        Debug.Log("Count: " + count);
    }
}
