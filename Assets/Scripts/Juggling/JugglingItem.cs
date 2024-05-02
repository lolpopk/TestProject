using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugglingItem : MonoBehaviour
{
    private Vector2 stepForce;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] public JugglingManager Manager;
    public bool IsDropping = true;

    public void Setup()
    {
        float[] speeds = new float[2];
        speeds[0] = Random.Range(-0.7f, Manager.SpeedRange.Min);
        speeds[1] = Random.Range(0.7f, Manager.SpeedRange.Max);
        stepForce = new Vector2(0, speeds[Random.Range(0, speeds.Length)]);
    }

    private void Update()
    {
        _rb.AddForce(stepForce);
    }

}
