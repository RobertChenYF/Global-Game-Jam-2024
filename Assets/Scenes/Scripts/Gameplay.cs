using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public List<string> ingreList;
    public Pancake pancake;
    public Request request;

    private List<IngrePool> ingrePoolList;
    private string managerName = "Manager";
    private Vector3 pancakelocation;

    void Start()
    {
        ingrePoolList = new List<IngrePool>(FindObjectsOfType<IngrePool>());
        ingreList = ingrePoolList.Select(ingrepool => ingrepool.ingredientType).ToList();
        pancake = FindObjectsOfType<Pancake>()[0];
        pancakelocation = pancake.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if (request.time <= 0)
        // {
        //     GameOver();
        // }
        // else if (request.owner == managerName)
        // {
        //     MetManager();
        // }
        // else if (AreListsEqual(request.types, pancake.types))
        // {
        //     Score();
        // }
    }

    void GameOver()
    {

    }

    void MetManager()
    {

    }

    void Score()
    {

    }

    bool AreListsEqual<T>(List<T> list1, List<T> list2)
    {
        if (list1 == null || list2 == null || list1.Count != list2.Count)
        {
            return false;
        }

        for (int i = 0; i < list1.Count; i++)
        {
            if (!EqualityComparer<T>.Default.Equals(list1[i], list2[i]))
            {
                return false;
            }
        }

        return true;
    }
}
