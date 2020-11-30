using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseBehavior : MonoBehaviour
{
    [SerializeField] string Tag = "Player";
    [SerializeField] string endScene = "EndScene";
    [SerializeField] GameObject SorryUI = null;
    public string[] hintDescriptions;
    
    public bool isFinish = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Tag) && isFinish)
        {
            SceneManager.LoadScene(endScene);
        }
        else if (collision.collider.CompareTag(Tag))
        {
            SorryUI.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(Tag))
        {
            SorryUI.SetActive(false);
        }
    }
}
