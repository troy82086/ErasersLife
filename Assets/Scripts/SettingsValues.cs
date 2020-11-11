using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsValues : MonoBehaviour
{
    [SerializeField] Slider mini = null;
    [SerializeField] Slider vol = null;
    [SerializeField] TMP_Dropdown iM = null;

    private int miniPov = 300;
    private int volume = 50;
    private int impericalOrMetric = 1;

    private void Awake()
    {
        mini.value = miniPov;
        vol.value = volume;
        iM.value = impericalOrMetric;
    }

    void Update()
    {
        if (miniPov != mini.value) miniPov = (int)mini.value;
        if (volume != vol.value) volume = (int)vol.value;
        if (impericalOrMetric != iM.value) impericalOrMetric = iM.value;
    }
}
