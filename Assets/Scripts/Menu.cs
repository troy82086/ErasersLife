using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] string scene = null;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }
    
    /// <summary>
    /// A place to change the volume and if they are imperical or metric users
    /// </summary>
    public void Settings()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
