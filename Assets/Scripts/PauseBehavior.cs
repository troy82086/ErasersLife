using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehavior : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas = null;
    [SerializeField] Canvas settings = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.enabled = !pauseCanvas.enabled;
        }

        if (pauseCanvas.enabled) Time.timeScale = 0;
        if (!pauseCanvas.enabled) Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseCanvas.enabled = !pauseCanvas.enabled;

        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Settings()
    {
        settings.enabled = true;
    }
}
