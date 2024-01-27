using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform GrannyCartPos;
    private Vector3 offset;

    private Vector3 screenShakeOffset;



    // The camera that will shake
    public Camera mainCamera;

    // The duration of the shake in seconds
    public float shakeDuration = 0.5f;

    // The magnitude of the shake in units
    public float shakeMagnitude = 0.1f;

    // The original position of the camera
    private Vector3 originalPosition;

    // A flag to indicate if the shake is active
    private bool isShaking = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - GrannyCartPos.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(GrannyCartPos.position.x + offset.x, 2, transform.position.z) + screenShakeOffset;
    }

    private IEnumerator ShakeCoroutine()
    {
        // Save the original position of the camera

        // Set the flag to true
        isShaking = true;

        // Keep track of the elapsed time
        float elapsedTime = 0f;

        // Loop until the shake duration is reached
        while (elapsedTime < shakeDuration)
        {
            // Increase the elapsed time by the time between frames
            elapsedTime += Time.deltaTime;

            // Calculate a random offset based on the shake magnitude
            float offsetX = Random.Range(-shakeMagnitude, shakeMagnitude);
            float offsetY = Random.Range(-shakeMagnitude, shakeMagnitude);

            screenShakeOffset = new Vector3(offsetX, offsetY, 0);
            // Apply the offset to the camera position
            //mainCamera.transform.position = originalPosition + new Vector3(offsetX, offsetY, 0f);

            // Wait for the next frame
            yield return null;
        }

        // Reset the camera position to the original position
        //mainCamera.transform.position = originalPosition;
        screenShakeOffset = Vector3.zero;

        // Set the flag to false
        isShaking = false;
    }

    public void Shake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        // Check if the shake is not already active
        if (!isShaking)
        {
            // Start the coroutine
            StartCoroutine(ShakeCoroutine());
        }
    }

}

