using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correcter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CustomButtonPress _press;
    private List<Transform> _objectsInside = new List<Transform>();
    public bool IsTouched = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _objectsInside.Add(collision.transform);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _objectsInside.Remove(collision.transform);
    }

    private void Update()
    {
        if(_press.IsPressed)
        {
            Up();
        }
    }

    public void Up()
    {
        foreach (Transform t in _objectsInside)
        {
            Rigidbody2D rb = t.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, _speed * Time.deltaTime));
        }
    }
}
