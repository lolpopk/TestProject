using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttentionLevel : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Errorbox _box;
    [SerializeField] private TMP_Text _text;
    public float Price = 50f;
    private LevelCell _cell;
    public void Show(float price, LevelCell cell)
    {
        _cell = cell;
        Price = price;
        _text.text = "It will cost\n" + Price.ToString();
        _animator.SetTrigger("Show");
    }

    public void Pay()
    {
        SaveData.Game game = SaveData.Load();
        if (game.Money >= Price)
        {
            game.UnlockingLvl.Add(_cell.Index);
            game.Money -= Price;
            _cell.LokingPart.gameObject.SetActive(false);
            SaveData.Save(game);
        }

        else
        {
            _box.Show("Your balance is too low");
        }

        Cancel();
    }

    public void Cancel()
    {
        _animator.SetTrigger("Hide");
    }
}
