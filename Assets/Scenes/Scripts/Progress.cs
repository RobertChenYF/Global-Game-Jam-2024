using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Progress : MonoBehaviour
{
    public BuyButton buyButton;
    public int progressCount;

    private List<string> progresses = new List<string>()
    {
        "90",
        "95",
        "98",
        "99",
        "99.5",
        "99.8",
        "99.9",
        "99.95",
        "99.98",
        "99.99",
        "99.995",
        "99.998",
        "99.999",
        "99.9995",
        "99.9998",
        "99.9999",
        "99.99995",
        "99.99998",
        "99.99999",
        "99.999995",
        "99.999998",
        "99.999999",
        "99.9999995",
        "99.9999998",
        "99.9999999",
        "99.99999995",
        "99.99999998",
        "99.99999999"
    };
    private TextMeshPro text;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        progressCount = progresses.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(buyButton.count < progressCount)
        {
            text.text = progresses[buyButton.count] + "%";
        }
        else
        {
            Debug.Log("Stage Clear");
        }
    }
}
