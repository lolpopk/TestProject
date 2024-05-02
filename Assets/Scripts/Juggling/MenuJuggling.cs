using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuJuggling : MonoBehaviour
{
    [SerializeField] public GameObject LoseMenu;
    [SerializeField] public GameObject WinMenu;
    [SerializeField] private TMP_Text _winText;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Show()
    {
        _animator.SetTrigger("Show");
    }

    public void ShowLose()
    {
        LoseMenu.SetActive(true);
        Show();
    }

    public void ShowWin(int Win)
    {
        WinMenu.SetActive(true);
        _winText.text = "+" + Win.ToString();
        Show();
    }

}
