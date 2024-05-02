using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] private Trace _trace;
    [SerializeField] public int Chance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (getChance())
        {
            _trace.ItemsOnLine.Remove(collision.transform);
            collision.GetComponent<JugglingItem>().IsDropping = true;
            if (collision.TryGetComponent(out Rigidbody2D rb))
            {
                rb.isKinematic = false;
            }
        }
    }

    private bool getChance()
    {
        int randNum = Random.Range(0, 101);
        bool resultt = randNum <= Chance;
        return resultt;
    }
}
