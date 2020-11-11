using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderWithValue : MonoBehaviour
{

    public Slider slider;
    public TMP_InputField input;
    public string unit;
    public byte decimals = 2;


    public void OnEnable()
    {
        slider.onValueChanged.AddListener(ChangeValue);
        ChangeValue(slider.value);
    }
    void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }

    void ChangeValue(float value)
    {
        input.text = value.ToString("n" + decimals) + " " + unit;
    }

    public void InputValueChanged()
    {
        if (slider.value != float.Parse(input.text)) slider.value = float.Parse(input.text);
    }
}
