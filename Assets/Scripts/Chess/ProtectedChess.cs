using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectedChess : Chess
{
    public bool IsProtected = true;
    [SerializeField] private GameObject _frame;
    private BoxCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsProtected = false;
        _collider.isTrigger = true;
        _frame.SetActive(false);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsProtected)
            base.OnTriggerEnter2D(collision);
    }
}
