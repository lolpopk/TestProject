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
        result = getByKey(_key);

        _slider.value = result;
    }

    public void OnChange()
    {
        float value = _slider.value;
        setByKey(_key, value);
    }

    private void setByKey(string key, float value)
    {
        SaveData.Game game = SaveData.Load();
        switch (key)
        {
            case "MusicMenu":
                game.MenuMusic = value;
                break;

            case "SoundsMenu":
                game.MenuSounds = value;
                break;

            case "Music":
                game.GameMusic = value;
                break;

            case "Sounds":
                game.GameSounds = value;
                break;

            case "ButtonsSound":
                game.ButtonsGame = value;
                break;

        }

        SaveData.Save(game);
    }

    private float getByKey(string key)
    {
        float result = 0.5f;

        SaveData.Game game = SaveData.Load();
        switch (key)
        {
            case "MusicMenu":
                result = game.MenuMusic;
                break;

            case "SoundsMenu":
                result = game.MenuSounds;
                break;

            case "Music":
                result = game.GameMusic;
                break;

            case "Sounds":
                result = game.GameSounds;
                break;

            case "ButtonsSound":
                result = game.ButtonsGame;
                break;

        }

        return result;
    }

}
