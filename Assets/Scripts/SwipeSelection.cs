using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSelection : SmoothSwipe
{
    [SerializeField] protected Transform _sectionsParent;
    [SerializeField] protected Transform _posParent;

    [SerializeField] protected List<GameObject> _sections = new List<GameObject>();

    public GameObject CurrentSection;

    private void Awake()
    {
        foreach (Transform childPos in _posParent)
        {
            _positions.Add(childPos);
        }

        foreach (Transform childSections in _sectionsParent)
        {
            _sections.Add(childSections.gameObject);
        }
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Swipe(int step)
    {
        base.Swipe(step);
        CurrentSection = _sections[_index];
        turnOnChild();
    }

    private void turnOnChild()
    {
        foreach(Transform child in CurrentSection.transform)
        {
            child.localScale = Vector3.one;
        }
    }
}
