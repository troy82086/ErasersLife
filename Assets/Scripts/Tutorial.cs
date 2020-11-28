using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialItems = null;

    private static int number = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {           
            NextTutorialItem();
        }
        if (number + 1 >= tutorialItems.Length)
        {
            gameObject.SetActive(false);
        }        
    }

    public void NextTutorialItem()
    {
        tutorialItems[number].SetActive(false);
        tutorialItems[number + 1].SetActive(true);
        number++;
    }
}
