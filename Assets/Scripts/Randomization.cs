using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomization : MonoBehaviour
{
    [SerializeField] HouseBehavior[] houses = null;

    void Start()
    {
        houses[Random.Range(0, houses.Length)].isFinish = true;
    }
}
