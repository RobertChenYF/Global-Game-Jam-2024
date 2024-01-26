using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pancake : MonoBehaviour
{
    public Request request;
    public List<string> types = new List<string>();
    public GameObject ingredient = null;

    void Update()
    {
        if (ingredient != null)
        {
            string ingredientType = ingredient.GetComponent<Ingredient>().type;
            if(!types.Contains(ingredientType) && request.getUnsatisfiedParts().Contains(ingredientType))
            {
                types.Add(ingredientType);
            }           
            Destroy(ingredient);
        }
    }
}
