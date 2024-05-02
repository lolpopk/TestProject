using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private bool _isMenu = false;
    public static ClipPlayer I;
    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        I = this;
    }

    private void OnEnable()
    {
        I = this;
    }

    public void Play(AudioClip clip)
    {
        float value = 0.5f;
        string key = _isMenu ? "SoundsMenu" : "Sounds";
        if (!_isMenu && clip == GameAssets.i.Click)
        {
            key = "ButtonsSound";
            value = 0f;
        }

        if (PlayerPrefs.HasKey(key))
            value = PlayerPrefs.GetFloat(key);
        else
            PlayerPrefs.SetFloat(key, value);

        _source.volume = value;

        _source.loop = false;
        _source.clip = clip;

        _source.Play();
    }
}
