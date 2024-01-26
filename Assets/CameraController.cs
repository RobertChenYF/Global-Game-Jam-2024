using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform GrannyCartPos;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - GrannyCartPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(GrannyCartPos.position.x + offset.x, transform.position.y, transform.position.z);
    }
}
