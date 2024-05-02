using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionMenu : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SmoothLoader _loader;
    [SerializeField] private Errorbox _box;

    public void Show()
    {
        _animator.SetTrigger("Show");
    }

    public void Pay()
    {
        SaveData.Game game = SaveData.Load();
        if (game.Money >= 50)
        {
            game.Money -= 50;
            SaveData.Save(game);
            _loader.LoadLevel(3);
        }

        else
        {
            _box.Show("Your balance is too low");
        }
    }

    public void Cancel()
    {
        _animator.SetTrigger("Hide");
    }
}
