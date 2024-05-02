using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LerpFloat))]
public class SettingsManager : MonoBehaviour
{
    private LerpFloat _lerp;
    [SerializeField] List<Transform> _menuObjs = new List<Transform>();
    [SerializeField] List<Transform> _settingsObjs = new List<Transform>();

    private void Awake()
    {
        _lerp = GetComponent<LerpFloat>();
    }

    private const float deltaTime = 0.01f;
    public void LoadSettings()
    {
        StartCoroutine(loadingSettings());
    }

    public void LoadMenu()
    {
        StartCoroutine(loadingMenu());
    }
    private IEnumerator loadingSettings()
    {
        _lerp.Reset();
        _lerp.Duration = 0.05f;
        float startValue = 1f;
        float endValue = 1.2f;

        while (_menuObjs[0].localScale.x != endValue)
        {
            changeScale(_menuObjs, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }

        _lerp.Reset();
        _lerp.Duration = 0.1f;
        startValue = endValue;
        endValue = 0f;

        while (_menuObjs[0].localScale.x != endValue)
        {
            changeScale(_menuObjs, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }


        _lerp.Reset();
        _lerp.Duration = 0.1f;
        startValue = 0f;
        endValue = 1.2f;

        while (_settingsObjs[0].localScale.x != endValue)
        {
            changeScale(_settingsObjs, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }

        _lerp.Reset();
        _lerp.Duration = 0.05f;
        startValue = 1.2f;
        endValue = 1f;

        while (_settingsObjs[0].localScale.x != endValue)
        {
            changeScale(_settingsObjs, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }
    }
    private IEnumerator loadingMenu()
    {
        _lerp.Reset();
        _lerp.Duration = 0.05f;
        float startValue = 1f;
        float endValue = 1.2f;

        while (_settingsObjs[0].localScale.x != endValue)
        {
            changeScale(_settingsObjs, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }

        _lerp.Reset();
        _lerp.Duration = 0.1f;
        startValue = endValue;
        endValue = 0f;

        while (_settingsObjs[0].localScale.x != endValue)
        {
            changeScale(_settingsObjs, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }


        _lerp.Reset();
        _lerp.Duration = 0.1f;
        startValue = 0f;
        endValue = 1.2f;

        while (_menuObjs[0].localScale.x != endValue)
        {
            changeScale(_menuObjs, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }

        _lerp.Reset();
        _lerp.Duration = 0.05f;
        startValue = 1.2f;
        endValue = 1f;

        while (_menuObjs[0].localScale.x != endValue)
        {
            changeScale(_menuObjs, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }
    }

    private void changeScale(List<Transform> list, float startScale, float endScale)
    {
        float value = _lerp.Lerp(deltaTime, startScale, endScale);

        foreach (Transform obj in list)
        {
            obj.localScale = new Vector2(value, value);
        }
    }
}
