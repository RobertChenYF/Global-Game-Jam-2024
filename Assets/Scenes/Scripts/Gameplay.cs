using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public string mian = "Mian";
    public int score = -1;
    public int requestTime = 10;
    public string managerName = "Manager";
    public List<string> ingreList;
    public Pancake pancake;
    public Request request;

    private List<IngrePool> ingrePoolList; 
    private Vector3 pancakelocation;
    private Vector3 requestlocation;
    private GameObject requestObject;

    void Start()
    {
        ingrePoolList = new List<IngrePool>(FindObjectsOfType<IngrePool>());
        ingrePoolList[0].ingredientType = mian;
        ingreList = ingrePoolList.Select(ingrepool => ingrepool.ingredientType).ToList();
        request = FindObjectsOfType<Request>()[0];
        pancake = FindObjectsOfType<Pancake>()[0];
        pancakelocation = pancake.transform.position;
        requestlocation = request.transform.position;
        Score();
        CreateRequest();
    }

    // Update is called once per frame
    void Update()
    {
        if (request.time <= 0)
        {
            GameOver();
        }
        else if (request.owner == managerName)
        {
            MetManager();
        }
        else if (AreListsEqual(request.getSatisfiedParts(), pancake.types))
        {
            Score();
            CreateRequest();
        }
    }

    void GameOver()
    {

    }

    void MetManager()
    {

    }

    void Score()
    {
        Destroy(request);
        Destroy(pancake);
        score++;
    }

    void CreateRequest()
    {
        string person = "Man";
        List<string> requirements = new List<string> () {"Mian", "Egg", "CuiBing"};
        requestObject = Instantiate(request.GetComponent<GameObject>(), requestlocation, Quaternion.identity);
        requestObject.GetComponent<Request>().Initialize(requestTime, requirements, person);
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
