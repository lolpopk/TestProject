using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpVector : MonoBehaviour
{
    private Vector3 _value;
    [SerializeField] public float Duration = 3f;
    public float TimeElapse { get; private set; } = 0f;

    public Vector3 Lerp(float deltaTime, Vector3 startPos, Vector3 endPos) 
    {
        if (TimeElapse < Duration)
        {
            float t = TimeElapse / Duration;
            _value = Vector3.Lerp(startPos, endPos, t);
            TimeElapse += deltaTime;
        }

        else
        {
            _value = endPos;
        }

        return _value;
    }

    public void Reset()
    {
        TimeElapse = 0f;
        _value = Vector3.zero;
    }
}
