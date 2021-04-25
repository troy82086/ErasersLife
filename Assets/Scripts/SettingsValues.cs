using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsValues : MonoBehaviour
{
    [SerializeField] Slider mini = null;
    [SerializeField] Slider sfxVol = null;
    [SerializeField] Slider musicVol = null;
    [SerializeField] TMP_Dropdown iM = null;
    [SerializeField] GameObject SettingsCanvas = null;
    [SerializeField] AudioMixer sfx;
    [SerializeField] AudioMixer music;

    [Serializable]
    public static class serializeValues
    {
        public static int miniPov = 300;
        public static float sfxVolume = 50;
        public static float musicVolume = 50;
        public static int impericalOrMetric = 1;
    }


    private int miniPov;
    private int impericalOrMetric;

    private void Awake()
    {
        miniPov = serializeValues.miniPov;
        impericalOrMetric = serializeValues.impericalOrMetric;
        mini.value = miniPov;
        sfxVol.value = serializeValues.sfxVolume;
        musicVol.value = serializeValues.musicVolume;
        sfx.SetFloat("sfx", serializeValues.sfxVolume - 40);
        music.SetFloat("music", serializeValues.musicVolume - 40);
        if (iM != null) iM.value = impericalOrMetric;
    }

    public void MiniMapValueChange() { serializeValues.miniPov = (int)mini.value; }
    
    public void SFXVolumeValueChange()
    {
        serializeValues.sfxVolume = sfxVol.value;
        sfx.SetFloat("sfx", serializeValues.sfxVolume - 40);
    }
    
    public void MusicVolumeValueChange()
    {
        serializeValues.musicVolume = musicVol.value - 40;
        music.SetFloat("music", serializeValues.musicVolume - 40);
    }
    
    public void ImpericalOrMetricValueChange() { if (iM != null) serializeValues.impericalOrMetric = iM.value; }

    public int GetImpericalOrMetric() { return serializeValues.impericalOrMetric; }
}
