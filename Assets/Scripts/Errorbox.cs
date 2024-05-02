using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Errorbox : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animator _animator;
    public void Show(string text)
    {
        _animator.SetTrigger("Show");
        _text.text = text;
    }

    public void Hide()
    {
        _animator.SetTrigger("Hide");
    }
}
