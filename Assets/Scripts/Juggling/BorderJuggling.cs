using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderJuggling : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out JugglingItem item))
        {
            item.Manager.Lose();
        }
    }
}
