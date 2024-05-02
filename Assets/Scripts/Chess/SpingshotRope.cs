using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpingshotRope : MonoBehaviour
{
    private LineRenderer _line;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    public void UpdateRope()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        _line.SetPosition(1, pos);
    }
}
