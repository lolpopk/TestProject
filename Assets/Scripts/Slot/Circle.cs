using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LerpFloat))]
public class Circle : MonoBehaviour
{
    [SerializeField] private LerpFloat _lerp;
    [SerializeField] private MaxMin _rangeSpeed;
    [SerializeField] private float _step = 22.5f;
    [SerializeField] private MainMachine _machine;
    [SerializeField] private float _fineTuingTime;
    [SerializeField] private MaxMin _rangeStopSpeed;
    [SerializeField] private MaxMin _rangeStepSpeed;

    private float _speed;
    private float _stopSpeed;
    private float _stepSpeed;

    public bool IsSpining { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartSpin();
        }
    }

    public void StartSpin()
    {
        IsSpining = true;
        _machine.IsSpining();

        _speed = RandomMaxMin(_rangeSpeed);
        _stopSpeed = RandomMaxMin(_rangeStopSpeed);
        _stepSpeed = RandomMaxMin(_rangeStepSpeed);

        StartCoroutine(spining());
    }

    private const float _deltaTime = 0.01f;
    private IEnumerator spining()
    {
        _lerp.Reset();
        _lerp.Duration = _fineTuingTime;
        Vector3 rotation = transform.rotation.eulerAngles;

        while (_speed > _stopSpeed)
        {
            _speed -= _stepSpeed;

            rotation = transform.rotation.eulerAngles;
            rotation.z += _speed;

            if (rotation.z >= 360)
                rotation.z -= 360;

            transform.rotation = Quaternion.Euler(rotation);

            yield return new WaitForSeconds(_deltaTime);
        }

        float offset = ((int)(rotation.z / _step) + 1) * _step;
        float startPosZ = rotation.z;
        float difference = offset - startPosZ;
        float duratino = (difference / _speed) * _deltaTime;
        _lerp.Duration = duratino;

        while (rotation.z != offset)
        {
            rotation = transform.rotation.eulerAngles;
            rotation.z = _lerp.Lerp(_deltaTime, startPosZ, offset);
            transform.rotation = Quaternion.Euler(rotation);
            yield return new WaitForSeconds(_deltaTime);
        }

        IsSpining = false;
        ClipPlayer.I.Play(GameAssets.i.Stop);
        _machine.IsSpining();
    }

    public void TrySpinAgain()
    {
        _machine.ShowAttention(this);
    }

    public void SpinAgain()
    {
        if (!_machine.IsSpining())
        {
            if(_machine.SpinOne())
                StartSpin();
        }
    }

    public float RandomMaxMin(MaxMin maxMin)
    {
        float result = Random.Range(maxMin.Min, maxMin.Max);
        return result;
    }

    [System.Serializable]
    public struct MaxMin
    {
        public float Max;
        public float Min;
    }
}
