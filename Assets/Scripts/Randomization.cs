using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomization : MonoBehaviour
{
    public HouseBehavior[] houses = null;

    void Start()
    {
        Debug.Log("Randomization Start");
        int i = Random.Range(0, houses.Length);
        houses[i].isFinish = true;
        Debug.Log(houses[i].name);
    }
}
