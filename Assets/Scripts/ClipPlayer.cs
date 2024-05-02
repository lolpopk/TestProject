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
        updateVolume(clip);

        _source.loop = false;
        _source.clip = clip;

        _source.Play();
    }

    private void updateVolume(AudioClip clip)
    {
        float volume = 0.5f;
        SaveData.Game game = SaveData.Load();
        volume = _isMenu ? game.MenuSounds : game.GameSounds;

        if (!_isMenu && clip == GameAssets.i.Click)
        {
            volume = game.ButtonsGame;
        }

        _source.volume = volume;
    }
}
