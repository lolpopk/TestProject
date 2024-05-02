using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Trace _removedTracer;
    [SerializeField] private Trace _addedTracer;
    [SerializeField] private Vector2 _targetPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _removedTracer.ItemsOnLine.Remove(collision.transform);
        collision.transform.position = _targetPos;
        //_addedTracer.AddItem(collision.transform);
    }
}
