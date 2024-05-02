using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attention : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private MainMachine _machine;
    private Circle _circle;
    public void Show(MainMachine mahcine, Circle circle)
    {
        _machine = mahcine;
        _circle = circle;
        _animator.SetTrigger("Show");
    }

    public void Buy()
    {
        _circle.SpinAgain();
    }

    public void Pay()
    {
        _animator.SetTrigger("HideBuy");
    }

    public void Cancel()
    {
        _animator.SetTrigger("Cancel");
    }
}
