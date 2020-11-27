using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseBehavior : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas = null;
    [SerializeField] Canvas settings = null;
    [SerializeField] GameObject map = null;
    [SerializeField] GameObject hints = null;
    [SerializeField] Text hintButton = null;

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

    public void Hints()
    {
        map.SetActive(!map.activeSelf);
        hints.SetActive(!hints.activeSelf);
        if (map.activeSelf)
        {
            hintButton.text = "Hints";
        }
        else
        {
            hintButton.text = "Map";
        }
    }
}
