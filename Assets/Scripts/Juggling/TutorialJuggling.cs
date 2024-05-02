using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialJuggling : MonoBehaviour
{
    [SerializeField] private Transform _menu;
    [SerializeField] private List<Transform> _clouds = new List<Transform>();
    private int _currentIndex = 0;
    protected bool _needTutorial = false;
    protected virtual void Start()
    {
        if (_needTutorial)
        {
            _menu.gameObject.SetActive(true);
            if (_clouds.Count > 0 )
            {
                _clouds[0].gameObject.SetActive(true);
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void NextCloud()
    {
        if ( _currentIndex + 1 < _clouds.Count)
        {
            _clouds[_currentIndex].gameObject.SetActive(false);
            _currentIndex++;
            _clouds[_currentIndex].gameObject.SetActive(true);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
