using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public BuyButton buyButton;
    public Progress progress;

    private Vector3 basicScale;
    void Start()
    {
        basicScale = transform.localScale;
        Debug.Log(basicScale);
    }

    void Update()
    {
        if (buyButton.count <= progress.progressCount)
        {
            transform.localScale = basicScale * (1 + 0.1f * buyButton.count);
        }
    }
}
