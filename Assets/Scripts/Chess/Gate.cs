using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Gate : MonoBehaviour
{
    private BoxCollider2D _collider;
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Chip chip))
        {
            if (chip._isReleased)
                SwitchGate(false);

        }
    }

    public void SwitchGate(bool switcher)
    {
        _collider.isTrigger = switcher;
    }
}
