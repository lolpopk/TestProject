using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BalanceText : MonoBehaviour
{
    [SerializeField] public TMP_Text Balance;
    [SerializeField] public TMP_Text WinSum;
    [SerializeField] private Animator _animator;
    private float _balanceSum;
    public void Add(float amount, float balance, string cha = "+")
    {
        _balanceSum = balance;
        WinSum.text = cha+amount.ToString();
        _animator.SetTrigger("Show");
    }

    public void UpdateBalance()
    {
        Balance.text = _balanceSum.ToString();
    }
}
