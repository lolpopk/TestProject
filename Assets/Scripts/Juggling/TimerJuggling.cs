using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerJuggling : MonoBehaviour
{
    [SerializeField] private TMP_Text _myText;
    [SerializeField] private Errorbox _box;
    public float TimeToEnd = 30f;
    public bool IsWork = false;
    public event Action OnEnd;

    public void Setup()
    {
        UpdateText();
    }

    private void Update()
    {
        if (IsWork)
        {
            if (TimeToEnd > 0)
            {
                TimeToEnd -= Time.deltaTime;
                UpdateText();
            }

            else
            {
                OnEnd?.Invoke();
                IsWork = false;
            }

        }
    }

    private void UpdateText()
    {
        _myText.text = Mathf.RoundToInt(TimeToEnd).ToString();
    }

    public void Divide()
    {
        if (MinusMoney())
        {
            TimeToEnd = TimeToEnd / 2;
            UpdateText();
        }
    }

    public bool MinusMoney()
    {
        bool result = false;
        SaveData.Game game = SaveData.Load();
        game.Money -= 100;

        if (game.Money >= 0)
        {
            result = true;
            SaveData.Save(game);
        }

        else
        {
            _box.Show("Your balance too low");
        }

        return result;
    }
}
