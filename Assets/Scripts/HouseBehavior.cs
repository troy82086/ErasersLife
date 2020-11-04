using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseBehavior : MonoBehaviour
{
    [SerializeField] string Tag = "Player";
    [SerializeField] GameObject door = null;
    [SerializeField] bool isFinish = false;
    [SerializeField] string endScene = "EndScene";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Tag) && isFinish)
        {
            SceneManager.LoadScene(endScene);
        }
    }
}
