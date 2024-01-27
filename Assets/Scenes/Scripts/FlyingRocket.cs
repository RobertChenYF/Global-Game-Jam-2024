using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRocket : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f; // 设置移动速度

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
