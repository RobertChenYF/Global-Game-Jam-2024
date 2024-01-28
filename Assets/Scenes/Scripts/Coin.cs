using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: MonoBehaviour
{
    public int coinValue;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<CartController>() != null)
        {
            GlobalVariables.money += coinValue;
            Destroy(gameObject);
        }
    }
}
