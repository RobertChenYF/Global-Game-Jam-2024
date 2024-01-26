using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // The spawn points to choose from

    public float spawnInterval = 3f; // The time between each spawn

    public List<GameObject> pool; // The object pool
    private float timer; // The timer for spawning

    void Start()
    {

        // Reset the timer
        timer = spawnInterval;
    }

    void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;
        // If the timer reaches zero, spawn objects
        if (timer <= 0)
        {
            // Pick a random number of objects to spawn (1 or 2)
            int numObjects = Random.Range(1, 3);
            // Shuffle the spawn points
            Shuffle(spawnPoints);
            // Loop through the number of objects to spawn
            for (int i = 0; i < numObjects; i++)
            {
                // Pick an inactive object from the pool
                GameObject obj = pool.Find(x => !x.activeSelf);
                // If there is an inactive object, spawn it
                if (obj != null)
                {
                    // Set the object to active
                    obj.SetActive(true);
                    // Move the object to a spawn point
                    obj.transform.position = spawnPoints[i].position;
                }
            }
            // Reset the timer
            timer = spawnInterval;
        }
    }

    // A method to shuffle an array
    void Shuffle<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            // Pick a random index
            int j = Random.Range(i, array.Length);
            // Swap the elements at i and j
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
