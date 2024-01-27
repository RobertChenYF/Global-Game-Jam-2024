using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carSpeed = 1;
    private float timer = 0;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<SpriteRenderer>().material;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 5)
        {
            timer = 0;
            gameObject.SetActive(false);
        }

        transform.Translate(new Vector3(carSpeed * -1 * Time.deltaTime, 0, 0), Space.World);
    }


}
