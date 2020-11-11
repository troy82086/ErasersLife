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
    public class serializeValues
    {
        public int miniPov;
        public int volume;
        public int impericalOrMetric;
    }

    private serializeValues values;

    private void Awake()
    {
        DontDestroyOnLoad(SettingsCanvas);
        values = new serializeValues();
        mini.value = values.miniPov;
        vol.value = values.volume;
        iM.value = values.impericalOrMetric;
    }

    public void MiniMapValueChange() { values.miniPov = (int)mini.value; }
    public void VolumeValueChange() { values.volume = (int)vol.value; }
    public void ImpericalOrMetricValueChange() { values.impericalOrMetric = iM.value; }
}
