﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseBehavior : MonoBehaviour
{
    [SerializeField] string Tag = "Player";
    [SerializeField] GameObject door = null;
    [SerializeField] string endScene = "EndScene";
    
    public bool isFinish = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Tag) && isFinish)
        {
            SceneManager.LoadScene(endScene);
        }
    }
}
