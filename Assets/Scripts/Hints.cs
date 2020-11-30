﻿using System.Collections;
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
    [SerializeField] TextMeshProUGUI hintMenuText;
    [SerializeField] bool hasBeenTriggered = false;

    private HouseBehavior finishHouse = null;

    private void Start()
    {
        HouseBehavior[] houses = randomization.houses;
        if (houses != null)
        {
            for (int i = 0; i < houses.Length; i++)
            {
                if (houses[i].isFinish == true && houses[i] != null)
                {
                    finishHouse = houses[i];
                    break;
                }
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
                if (hintNumber > finishHouse.hintDescriptions.Length) hintNumber = Random.Range(0, finishHouse.hintDescriptions.Length);
                hintText.SetText("The Kid lives in a house " + finishHouse.hintDescriptions[hintNumber] + ".");
                if (!hasBeenTriggered)
                {
                    hintMenuText.SetText(hintMenuText.text + (hintNumber + 1)+ ".) " +hintText.text + "\n");
                    hasBeenTriggered = true;
                }
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
