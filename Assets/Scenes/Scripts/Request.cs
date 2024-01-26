using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Request : MonoBehaviour
{
    public string owner;
    public List<KeyValuePair<string,bool>> parts = new List<KeyValuePair<string,bool>>();

    public float countdownDuration = 10f;
    public float time;

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            time = Mathf.Max(0, time);
        }
        else
        {
            Debug.Log("Countdown timer reached zero!");
        }
    }

    public List<string> getSatisfiedParts()
    {
        return parts.Where(pair => pair.Value == true).Select(pair => pair.Key).ToList();
    }
    public List<string> getUnsatisfiedParts()
    {
        return parts.Where(pair => pair.Value == false).Select(pair => pair.Key).ToList();
    }
    public void Initialize(float countdown, List<string> requirements, string person)
    {
        countdownDuration = countdown;
        parts = requirements.Select(str => new KeyValuePair<string, bool>(str, false)).ToList();
        owner = person;
    }
}
