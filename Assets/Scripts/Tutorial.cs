using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialItems = null;

    public int number = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {           
            NextTutorialItem();
        }
        if (number + 1 >= tutorialItems.Length)
        {
            tutorialItems[number].SetActive(false);  
            number = 0;
            tutorialItems[number].SetActive(true);
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
