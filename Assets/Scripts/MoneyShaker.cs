using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyShaker : MonoBehaviour
{
    public TextMeshPro moneyText; // The text object to shake
    // The money variable to track

    // The coroutine function to shake the text object

    private void Update()
    {
        OnValidate();
    }

    private IEnumerator ShakeText(int moneyDelta)
    {

        // The original position of the text object
        Vector3 originalPosition = moneyText.transform.localPosition;

        // The shake length and magnitude parameters
        float shakeLength = Mathf.Clamp(Mathf.Abs(moneyDelta) * 0.1f, 0f, 2f); // The shake length depends on the money changed, but is capped at 2 seconds
        float shakeMagnitude = Mathf.Clamp(Mathf.Abs(moneyDelta) * 0.01f, 0f, 0.5f); // The shake magnitude depends on the money changed, but is capped at 0.5 units

        // The shake timer
        float shakeTimer = 0f;

        // The shake loop
        while (shakeTimer < shakeLength)
        {
            // Increment the shake timer
            shakeTimer += Time.deltaTime;

            // Generate random values for the shake offset
            float x = Mathf.PerlinNoise(shakeTimer * 10f, 0f) * 2f - 1f;
            float y = Mathf.PerlinNoise(0f, shakeTimer * 10f) * 2f - 1f;

            // Apply the shake offset to the text object position
            moneyText.transform.localPosition = originalPosition + new Vector3(x, y, 0f) * shakeMagnitude;

            // Wait for the next frame
            yield return null;
        }

        // Reset the text object position to the original position
        moneyText.transform.localPosition = originalPosition;
    }

    // The function to detect changes in the editor
    private void OnValidate()
    {
        // Check if the money variable has changed
        if (GlobalVariables.money != int.Parse(moneyText.text.Substring(0,moneyText.text.Length - 1)))
        {
            // Calculate the money delta
            int moneyDelta = GlobalVariables.money - int.Parse(moneyText.text.Substring(0, moneyText.text.Length - 1));

            // Update the text object with the new money value
            moneyText.text = GlobalVariables.money.ToString() + "¥";

            // Start the shake coroutine with the money delta
            StartCoroutine(ShakeText(moneyDelta));
        }
    }

    // The custom setter function to detect changes at runtime
    public void SetMoney(int newMoney)
    {
        // Check if the new money value is different from the current one
        if (newMoney != GlobalVariables.money)
        {
            // Calculate the money delta
            int moneyDelta = newMoney - GlobalVariables.money;

            // Update the money variable with the new value
            GlobalVariables.money = newMoney;

            // Update the text object with the new money value
            moneyText.text = GlobalVariables.money.ToString();

            // Start the shake coroutine with the money delta
            StartCoroutine(ShakeText(moneyDelta));
        }
    }
}





