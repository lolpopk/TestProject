using UnityEngine;

public class LerpFloat : MonoBehaviour
{
    private float _lerpedValue;
    [SerializeField] public float Duration = 3f;
    public float TimeElapsed { get; private set; } = 0;

    public float Lerp(float deltaTime, float startValue, float endValue)
    {
        if (TimeElapsed < Duration)
        {
            float t = TimeElapsed / Duration;
            _lerpedValue = Mathf.Lerp(startValue, endValue, t);
            TimeElapsed += deltaTime;
        }

        else
        {
            _lerpedValue = endValue;
        }

        return _lerpedValue;
    }

    public void Reset()
    {
        TimeElapsed = 0;
        _lerpedValue = 0;
    }
}
