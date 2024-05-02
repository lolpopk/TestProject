using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private string _key;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _defaultValue = 0.5f;

    private void Start()
    {
        float result = _defaultValue;

        if (PlayerPrefs.HasKey(_key))
            result = PlayerPrefs.GetFloat(_key);

        else 
            PlayerPrefs.SetFloat(_key, result);

        _slider.value = result;
    }

    public void OnChange()
    {
        float value = _slider.value;
        PlayerPrefs.SetFloat(_key, value);
    }

}
