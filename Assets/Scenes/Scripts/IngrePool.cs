using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngrePool : MonoBehaviour
{
    public GameObject source;
    public string ingredientType;
    public int zPosition;

    private GameObject currentObject;
    private Vector3 mouseDownPosition;

    void Update()
    {    
        if (currentObject != null && Input.GetMouseButton(0))
        {
            UpdateObjectPosition();
        }
    }

    void OnMouseUp()
    {
        if (currentObject != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(currentObject.transform.position, Vector2.zero);            
            if (hit.collider != null && hit.collider.GetComponent<Pancake>() != null)
            {
                hit.collider.GetComponent<Pancake>().ingredient = currentObject;
            }
            else
            {
                Destroy(currentObject);
            }
        }
    }

    void OnMouseDown()
    {
        mouseDownPosition = Input.mousePosition;
        GenerateObject();
    }

    void GenerateObject()
    {
        currentObject = Instantiate(source, mouseDownPosition, Quaternion.identity);
        Ingredient ingredient = currentObject.GetComponent<Ingredient>();
        ingredient.type = ingredientType;
    }

    void UpdateObjectPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zPosition;
        currentObject.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }    
}
