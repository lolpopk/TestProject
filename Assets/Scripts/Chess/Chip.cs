using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LerpVector))]
public class Chip : MonoBehaviour
{
    [SerializeField] public SpingShot Spingshot;
    [SerializeField] private float endForce = 0.6f;
    [SerializeField] private float _maxDistance = 2f;
    [SerializeField] private SpringJoint2D _sj1, _sj2;
    [SerializeField] public List<Transform> JountsRB = new List<Transform>();
    [SerializeField] public List<Rigidbody2D> statRB = new List<Rigidbody2D>();

    private bool _isPressed;
    public bool _isReleased = false;
    private bool _isCelling = false;

    private Rigidbody2D _rb;
    private LerpVector _lerp;

    public float ReleaseDelay = 0f;

    private List<Collider2D> _cells = new List<Collider2D>();
    public List<SpringJoint2D> Jounts = new List<SpringJoint2D>();
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lerp = GetComponent<LerpVector>();
        ReleaseDelay = 1 / (_sj1.frequency * 4);
        Jounts = GetComponents<SpringJoint2D>().ToList();
        Jounts[0].connectedBody = statRB[0].GetComponent<Rigidbody2D>();
        Jounts[1].connectedBody = statRB[1].GetComponent<Rigidbody2D>();  
        _lerp.Duration = 0.3f;
    }

    private void Update()
    {
        if (_isPressed)
        {
            if (!_isReleased)
                Drag();
        }

        if (!_isCelling)
            if (getSum(_rb.velocity) <= endForce && _isReleased)
            {
                SetToCell();
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Point point))
        {
            _cells.Add(collision);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ClipPlayer.I.Play(GameAssets.i.Pinko);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Point point))
        {
            _cells.Remove(collision);
        }
    }

    private void Drag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance1 = Vector2.Distance(mousePosition, JountsRB[0].position);

        if (distance1 > _maxDistance)
        {
            Vector2 direction = (mousePosition - (Vector2)JountsRB[0].position).normalized;
            _rb.position = (Vector2)JountsRB[0].position + direction * _maxDistance;
        }

        else
        {
            _rb.position = mousePosition;
        }

    }

    private void SetToCell()
    {
        _isCelling = true;
        if (_cells.Count > 0)
        {
            _rb.velocity = Vector2.zero;
            Collider2D result = null;

            for (int i = 0; i < _cells.Count; i++)
            {
                Point key = _cells[i].GetComponent<Point>();
                if (!key.IsBusy)
                {
                    result = _cells[i];
                    break;
                }
                if (i == _cells.Count - 1)
                {
                    DestroyMe();
                }
            }
            float distance = getDistance(transform.position, result.transform.position);

            for (int i = 1; i < _cells.Count; i++)
            {
                Collider2D key = _cells[i];
                float tempDistance = getDistance(transform.position, key.transform.position);
                if (tempDistance < distance)
                {
                    result = key;
                    distance = tempDistance;
                }
            }

            result.GetComponent<Point>().IsBusy = true;
            StartCoroutine(goToPoint(result.transform.position));
        }

        else
        {
            DestroyMe();
        }
    }

    public void DestroyMe()
    {
        Spingshot?.MakeNew();
        Destroy(gameObject);
    }

    private const float _deltaTime = 0.01f;
    private IEnumerator goToPoint(Vector3 pos)
    {
        _lerp.Reset();
        Vector3 startPos = _rb.position;
        while (_rb.position != (Vector2)pos)
        {
            _rb.position = _lerp.Lerp(_deltaTime, startPos, pos);
            yield return new WaitForSeconds(_deltaTime);
        }

        _rb.isKinematic = true;
        Spingshot?.MakeNew();
    }

    private float getSum(Vector3 vector)
    {
        float result = 0f;

        result += Mathf.Abs(vector.x);
        result += Mathf.Abs(vector.y);
        result += Mathf.Abs(vector.z);

        return result;
    }

    private float getDistance(Vector3 point1, Vector3 point2)
    {
        float distance = 0;

        distance += Mathf.Abs(point1.x - point2.x);
        distance += Mathf.Abs(point1.y - point2.y);
        distance += Mathf.Abs(point1.z - point2.z);

        return distance;
    }

    public void InteractOn()
    {
        _rb.isKinematic = true;
        Spingshot?.Interact(true);
        _isPressed = true;
    }

    public void InteractOff(bool coroutine = true)
    {
        _isPressed = false;
        _rb.isKinematic = false;

        if (Spingshot != null) 
            Spingshot.Interact(false);


        if (coroutine)
        StartCoroutine(release());
    }

    private void OnMouseDown()
    {
        InteractOn();
    }

    private void OnMouseUp()
    {
        InteractOff();
    }

    private IEnumerator release()
    {
        yield return new WaitForSeconds(ReleaseDelay);
        Releas();
        //_sj1.enabled = false;
    }

    public void Releas()
    {
        if (Spingshot != null)
            Spingshot.Realeas();

        foreach (SpringJoint2D jount in Jounts)
        {
            jount.enabled = false;
        }
        _isReleased = true;
    }
}
