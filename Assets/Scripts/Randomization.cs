using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomization : MonoBehaviour
{
    [SerializeField] HouseBehavior[] houses = null;

    void Start()
    {
        int i = Random.Range(0, houses.Length);
        houses[i].isFinish = true;
        Debug.Log(houses[i].name);
    }
}
