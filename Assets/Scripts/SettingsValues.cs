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
        public static int miniPov = 300;
        public static int volume = 50;
        public static int impericalOrMetric = 1;
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
        if(iM != null) iM.value = impericalOrMetric;
    }

    public void MiniMapValueChange() { serializeValues.miniPov = (int)mini.value; }
    public void VolumeValueChange() { serializeValues.volume = (int)vol.value; }
    public void ImpericalOrMetricValueChange() { if(iM != null) serializeValues.impericalOrMetric = iM.value; }

    public int GetImpericalOrMetric() { return serializeValues.impericalOrMetric; }
    public int GetVolume() { return serializeValues.volume; }
}
