using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Progress : MonoBehaviour
{
    public BuyButton buyButton;
    public Rocket rocket;
    public float maxSpeed = 4.0f;
    public int progressCount;
public RunStateManager runStateManager;


    private Camera mainCamera;
    private float currentSpeed;
    private float originSpeed;
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
    private float maxScaleIndex;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        mainCamera = Camera.main;
        progressCount = progresses.Count;
        currentSpeed = 0.3f * maxSpeed;       
    }

    // Update is called once per frame
    void Update()
    {
        if(buyButton.count < progressCount)
        {
            text.text = progresses[buyButton.count] + "%";
            maxScaleIndex = rocket.scaleIndex;            
        }
        else
        {
           text.text = "100% 助力成功";
            runStateManager.changeToShooterState();
           MoveObjects();
        }
        
    }

    void MoveObjects()
    {       
        currentSpeed = Mathf.Min(maxSpeed, currentSpeed + 0.1f * maxSpeed * Time.deltaTime);
        if (originSpeed <= 0)
        {
            originSpeed = currentSpeed;
        }
        Vector3 newCameraPosition = mainCamera.transform.position + Vector3.up * currentSpeed * Time.deltaTime;
        Vector3 direction = newCameraPosition - rocket.transform.position;
        direction.z = 0;
        Vector3 newRocketPosition = rocket.transform.position + 1.4f * direction.normalized * currentSpeed * Time.deltaTime;
        mainCamera.transform.position = newCameraPosition;
        rocket.transform.position = newRocketPosition;
        rocket.scaleIndex = Mathf.Max(1.0f, maxScaleIndex * (originSpeed/currentSpeed));
    }
}
