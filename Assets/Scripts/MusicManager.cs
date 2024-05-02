using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private bool _isMenu = false;
    private AudioSource _source;
    private string _key = "Music";
    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _key = _isMenu ? "MusicMenu" : _key;
        ChangeVolume();

        _source.clip = _clip;
        _source.loop = true;
        _source.Play();
    }

    public void ChangeVolume()
    {
        float value = 0.5f;

        if (PlayerPrefs.HasKey(_key))
            value = PlayerPrefs.GetFloat(_key);
        else
            PlayerPrefs.SetFloat(_key, value);
        _source.volume = value;
    }
}
