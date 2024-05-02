using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LerpFloat))]
public class ChooseLevel : MonoBehaviour
{
    private LerpFloat _lerp;
    [SerializeField] private List<Transform> _menuObj = new List<Transform>();
    [SerializeField] private List<Transform> _levelObj = new List<Transform>();
    [SerializeField] private List<LevelCell> _celles = new List<LevelCell>();
    [SerializeField] public AttentionLevel Attention;
    [SerializeField] private SmoothLoader _loader;
    [SerializeField] public SwipeSelection _swipe;

    private void Awake()
    {
        int index = 0;
        _lerp = GetComponent<LerpFloat>();
        SaveData.Game game = SaveData.Load();
        foreach (Transform childSwipe in _swipe.transform)
        {
            foreach (Transform child in  childSwipe)
            {
                LevelCell cell = child.GetComponentInChildren<LevelCell>();
                cell.Index = index;
                cell.Setup(game.UnlockingLvl);
                index++;
            }
        }

        Debug.Log(index);
    }

    private void Start()
    {
        //SaveData.Game game = SaveData.Load();
        //foreach (LevelCell cell in _celles)
        //{
        //    cell.Setup(game.UnlockingLvl);
        //}
    }

    public void Load(LevelCell cell)
    {
        JugglingManager.LoadingLevel = cell.Level;
        _loader.LoadLevel(2);
    }

    public void LoadMenu()
    {
        StartCoroutine(loadingMenu());
    }

    public void LoadLevels()
    {
        StartCoroutine(loadingLevels());
    }

    private const float deltaTime = 0.01f;
    private IEnumerator loadingLevels()
    {
        List<Transform> cells = new List<Transform>();
        foreach (Transform cild in _swipe.CurrentSection.transform)
        {
            cells.Add(cild);
        }
        _lerp.Reset();
        _lerp.Duration = 0.05f;
        float startValue = 1f;
        float endValue = 1.2f;

        while (_menuObj[0].localScale.x != endValue)
        {
            changeScale(_menuObj, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }

        _lerp.Reset();
        _lerp.Duration = 0.1f;
        startValue = endValue;
        endValue = 0f;

        while (_menuObj[0].localScale.x != endValue)
        {
            changeScale(_menuObj, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }


        _lerp.Reset();
        _lerp.Duration = 0.1f;
        startValue = 0f;
        endValue = 1.2f;

        while (_levelObj[0].localScale.x != endValue)
        {
            changeScale(_levelObj, startValue, endValue);
            changeScale(cells, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }

        _lerp.Reset();
        _lerp.Duration = 0.05f;
        startValue = 1.2f;
        endValue = 1f;

        while (_levelObj[0].localScale.x != endValue)
        {
            changeScale(_levelObj, startValue, endValue);
            changeScale(cells, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }

    }
    private IEnumerator loadingMenu()
    {
        List<Transform> cells = new List<Transform>();
        foreach (Transform cild in _swipe.CurrentSection.transform)
        {
            cells.Add(cild);
        }
        _lerp.Reset();
        _lerp.Duration = 0.05f;
        float startValue = 1f;
        float endValue = 1.2f;

        while (_levelObj[0].localScale.x != endValue)
        {
            changeScale(_levelObj, startValue, endValue);
            changeScale(cells, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }

        _lerp.Reset();
        _lerp.Duration = 0.1f;
        startValue = endValue;
        endValue = 0f;

        while (_levelObj[0].localScale.x != endValue)
        {
            changeScale(_levelObj, startValue, endValue);
            changeScale(cells, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }


        _lerp.Reset();
        _lerp.Duration = 0.1f;
        startValue = 0f;
        endValue = 1.2f;

        while (_menuObj[0].localScale.x != endValue)
        {
            changeScale(_menuObj, startValue, endValue);
            yield return new WaitForSeconds(deltaTime);
        }

        _lerp.Reset();
        _lerp.Duration = 0.05f;
        startValue = 1.2f;
        endValue = 1f;

        while (_menuObj[0].localScale.x != endValue)
        {
            changeScale(_menuObj, startValue, endValue);
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
