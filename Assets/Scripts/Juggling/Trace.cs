using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Trace : MonoBehaviour
{
    public List<Transform> ItemsOnLine = new List<Transform>();
    [SerializeField] private float _durationAdd = 0.2f;
    [SerializeField] public float Speed = 1f;
    public bool IsWorking = true;

    public void AddItem(Transform item)
    {
        StartCoroutine(addingIem(item, item.GetComponent<LerpFloat>()));
    }

    private IEnumerator addingIem(Transform item, LerpFloat lerp)
    {
        float startPos = item.position.y;
        lerp.Reset();
        lerp.Duration = _durationAdd;
        JugglingItem jugglingItem = item.GetComponent<JugglingItem>();
        while (item.position.y != transform.position.y && !jugglingItem.IsDropping) 
        {
            Vector2 pos = new Vector2(item.position.x, 0);
            pos.y = lerp.Lerp(Time.fixedDeltaTime, startPos, transform.position.y);
            item.position = pos;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }

    private void Update()
    {
        if (IsWorking)
        {
            foreach (Transform item in ItemsOnLine)
            {
                Vector2 pos = item.position;
                pos.x += Speed * Time.deltaTime;
                item.position = pos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemsOnLine.Add(collision.transform);
        if (collision.TryGetComponent(out Rigidbody2D rb))
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
        }

        collision.GetComponent<JugglingItem>().IsDropping = false;

        AddItem(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody rb))
        {
            rb.isKinematic = false;

        }
        collision.GetComponent<JugglingItem>().IsDropping = true;
        ItemsOnLine.Remove(collision.transform);
    }
}
