using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothSwipe : MonoBehaviour
{
    [SerializeField] protected List<Transform> _positions = new List<Transform>();
    [SerializeField] protected Transform _movingT;

    protected int _index = 0;

    protected float _targetPos;
    protected bool _isWorking = false;
    protected virtual void Update()
    {
        if (_isWorking)
        {
            Vector3 pos = _movingT.position;
            pos.x = Mathf.Lerp(pos.x, _targetPos, 0.07f);
            _isWorking = !(Mathf.Abs(pos.x - _targetPos) <= 0.04f);
            if (!_isWorking) pos.x = _targetPos;

            _movingT.position = pos;
        }
    }

    public virtual void Swipe(int step)
    {
        _index += step;
        if (_index < 0) _index = 0;
        else if (_index >= _positions.Count) _index = _positions.Count - 1;
        //_index = Mathf.Clamp(_index, 0, _positions.Count-1);
        _targetPos = -_positions[_index].position.x;
        _isWorking = true;
    }
}
