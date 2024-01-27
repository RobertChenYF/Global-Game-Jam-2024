using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public BuyButton buyButton;
    public Progress progress;
    public float scaleIndex;

    private Vector3 basicScale;
    void Start()
    {
        basicScale = transform.localScale;
        scaleIndex = 1.0f;
    }

    void Update()
    {
        if (buyButton.count < progress.progressCount)
        {
            scaleIndex  = 1 + 0.1f * buyButton.count;
        }
        transform.localScale = scaleIndex * basicScale;
        
    }
}
