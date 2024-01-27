using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pancake : MonoBehaviour
{
    public Request request;
    public List<AllIngridient.allIngri> types;
    public GameObject ingredient = null;

    public GameObject PancakePacked;

    public GameObject currentPancakeObject = null;

    public List<GameObject> PancakeCook;

    private void Start()
    {
        types = new List<AllIngridient.allIngri>();
    }

    void Update()
    {
        if (types.Count == 0 && ingredient != null)
        {
            if (ingredient.GetComponent<Ingredient>().type == 0)
            {
                types.Add((AllIngridient.allIngri)ingredient.GetComponent<Ingredient>().type);
                PancakeCook[0].SetActive(true);
            }
            Destroy(ingredient);
        }
        if (types.Count > 0 && ingredient != null )
        {
            AllIngridient.allIngri ingredientType = (AllIngridient.allIngri)ingredient.GetComponent<Ingredient>().type;
            if(!types.Contains(ingredientType))
            {
                types.Add(ingredientType);
                PancakeCook[(int)ingredient.GetComponent<Ingredient>().type].SetActive(true);
            }           
            Destroy(ingredient);
        }
    }


}
