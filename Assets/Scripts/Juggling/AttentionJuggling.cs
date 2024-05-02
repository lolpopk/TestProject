using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttentionJuggling : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _text;
    public delegate void Acti();
    private Acti _acti;
    public void Show(Acti acti)
    {
        _acti = acti;
        _animator.SetTrigger("Show");
    }

    public void Pay()
    {
        _acti?.Invoke();
        Cancel();
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void Cancel()
    {
        _animator.SetTrigger("Hide");
    }
}
