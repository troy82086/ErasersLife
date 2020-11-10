using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehavior : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(pauseCanvas.enabled);
            pauseCanvas.enabled = !pauseCanvas.enabled;
        }

        if (pauseCanvas.enabled) Time.timeScale = 0;
        if (!pauseCanvas.enabled) Time.timeScale = 1;


    }
}
