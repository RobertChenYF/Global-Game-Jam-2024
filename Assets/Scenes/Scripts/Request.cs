using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Shapes;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AllIngridient
{
    public enum allIngri {面糊,鸡蛋,生菜,里脊肉,香肠,薄脆};
}

public class Request : MonoBehaviour
{
    public List<Sprite> customer;
    public GameObject chenGuanText;
    public Sprite Chengguan;

    public AudioSource soundEffectPlayer;

    public List<AudioClip> customerGreet;

    public List<AudioClip> customerSatisfied;

    public List<AudioClip> customerUnhappy;

    public float countdownDuration = 10f;
    public float time;
    public Pancake pancake;

    public List<Sprite> allIngridient;
    public List<SpriteRenderer> ingridientIndicator;
    public Image customerSprite;
    public List<AllIngridient.allIngri> requestIngridient;

    public Rectangle timeBar;

    public int orderSubmitted = 0;

    public int index;

    public int pancakeIncome = 10;

    public bool Inspace = false;

    private void Start()
    {
        requestIngridient = new List<AllIngridient.allIngri>();
        //start a new request
        startNewRequest();

    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            time = Mathf.Max(0, time);
            timeBar.Width = time/2.0f;
        }
        else
        {
            soundEffectPlayer.PlayOneShot(customerUnhappy[index]);
            startNewRequest();
            Debug.Log("Countdown timer reached zero!");
        }
    }

    public void startNewRequest()
    {
        time = countdownDuration;
        index = Random.Range(1, customer.Count);
        customerSprite.sprite = customer[index];
        soundEffectPlayer.PlayOneShot(customerGreet[index]);
        requestIngridient.Clear();
        requestIngridient.Add(AllIngridient.allIngri.面糊);
        PickRandomEnums(3);

        for(int i = 0; i < 3; i++)
        {
            ingridientIndicator[i].sprite = allIngridient[(int)requestIngridient[i+1]];
        }

    }

    public void startChenGuanRequest()
    {
        soundEffectPlayer.PlayOneShot(customerGreet[4]);
        time = 999;
        customerSprite.sprite = Chengguan;
        chenGuanText.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            ingridientIndicator[i].sprite = null;
        }
    }

    void PickRandomEnums(int num) // Define a function that takes the number of enum values to pick as a parameter
    {
        
        var values = AllIngridient.allIngri.GetValues(typeof(AllIngridient.allIngri)); // Get an array of all the enum values
        var used = new HashSet<int>();// Declare a hash set to store the used indices
        used.Add(0);
        for (int i = 0; i < num; i++) // Loop until you pick enough enum values
        {
            int index; // Declare a variable to store the random index
            do
            {
                index = Random.Range(0, values.Length); // Generate a random index between 0 and the length of the enum array
            } while (used.Contains(index)); // Repeat if the index is already used
            used.Add(index); // Add the index to the hash set
            requestIngridient.Add((AllIngridient.allIngri)values.GetValue(index)); // Add the enum value at the index to the list
        }
    }

    public void Submit()
    {
        bool correct = true;

        if (orderSubmitted > 5)
        {
            soundEffectPlayer.PlayOneShot(customerUnhappy[4]);
            if (Inspace)
            {
                SceneManager.LoadScene(4);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
            
        }

        for(int i = 0; i < requestIngridient.Count; i++)
        {
            if(!pancake.types.Contains(requestIngridient[i]))
            {
                correct = false;

            }

        }

        for (int i = 0; i < pancake.types.Count; i++)
        {
            if (!requestIngridient.Contains(pancake.types[i]))
            {
                correct = false;
            }

        }


        if (correct)
        {
        GlobalVariables.money += pancakeIncome;
        pancake.types.Clear();
        soundEffectPlayer.PlayOneShot(customerSatisfied[index]);
        foreach(GameObject a in pancake.PancakeCook)
        {
            a.SetActive(false);
        }
            orderSubmitted++;

            if (orderSubmitted > 5)
            {
                startChenGuanRequest();
            }
            else
            {
                startNewRequest();
            }
        }
        else
        {
            soundEffectPlayer.PlayOneShot(customerUnhappy[index]);
        }

    }

    public void trash()
    {
        pancake.types.Clear();
        foreach (GameObject a in pancake.PancakeCook)
        {
            a.SetActive(false);
        }
    }

}
