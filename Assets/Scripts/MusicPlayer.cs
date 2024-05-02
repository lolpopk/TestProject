using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private bool _isMenu = false;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (_source == null) _source = GetComponent<AudioSource>();
        UpdateVolume();
        _source.clip = _clip;
        _source.loop = true;
        _source.Play();
    }

    public void UpdateVolume()
    {
        float volume = _isMenu ? 0f : 0.5f;
        string key = _isMenu ? "MusicMenu" : "Music";

        if (PlayerPrefs.HasKey(key))
            volume = PlayerPrefs.GetFloat(key);
        else
            PlayerPrefs.SetFloat(key, volume);

        _source.volume = volume;
    }
}