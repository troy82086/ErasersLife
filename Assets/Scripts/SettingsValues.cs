using System;
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
    [SerializeField] GameObject SettingsCanvas = null;

    [Serializable]
    public static class serializeValues
    {
        public static int miniPov;
        public static int volume;
        public static int impericalOrMetric;
    }

    private int miniPov;
    private int volume;
    private int impericalOrMetric;

    private void Awake()
    {
        miniPov = serializeValues.miniPov;
        volume = serializeValues.volume;
        impericalOrMetric = serializeValues.impericalOrMetric;
        mini.value = miniPov;
        vol.value = volume;
        iM.value = impericalOrMetric;
        Debug.Log(miniPov);
        Debug.Log(volume);
        Debug.Log(impericalOrMetric);
    }

    public void MiniMapValueChange() { serializeValues.miniPov = (int)mini.value; }
    public void VolumeValueChange() { serializeValues.volume = (int)vol.value; }
    public void ImpericalOrMetricValueChange() { serializeValues.impericalOrMetric = iM.value; }
}
