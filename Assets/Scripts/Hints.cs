using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    [SerializeField] int hintNumber;
    [SerializeField] Randomization randomization;
    [SerializeField] Canvas hintCanvas;
    [SerializeField] TextMeshProUGUI hintText;

    private HouseBehavior finishHouse = null;

    private void Start()
    {
        Debug.Log("Hints Start");
        HouseBehavior[] houses = randomization.houses;
        for (int i = 0; i < houses.Length; i++)
        {
            if (houses[i].isFinish)
            {
                finishHouse = houses[i];
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hintCanvas.enabled = true;
            if (hintCanvas.enabled)
            {
                hintText.SetText("The Kid lives in a house " + finishHouse.hintDescriptions[hintNumber] + ".");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hintCanvas.enabled = false;
        }
    }
}
