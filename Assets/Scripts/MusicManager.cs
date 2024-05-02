using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
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
        ChangeVolume();

        _source.clip = _clip;
        _source.loop = true;
        _source.Play();
    }

    public void ChangeVolume()
    {
        float value = 0.5f;

        SaveData.Game game = SaveData.Load();
        value = _isMenu ? game.MenuMusic : game.GameMusic;

        _source.volume = value;
    }
}
