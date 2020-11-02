using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingSchoolScript : MonoBehaviour
{
    [SerializeField] string tag = null;
    [SerializeField] string nextScene = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(tag))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
