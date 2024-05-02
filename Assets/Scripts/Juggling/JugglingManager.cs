using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MinMax = Circle.MaxMin;

public class JugglingManager : MonoBehaviour
{
    [SerializeField] public MinMax SpeedRange;
    [SerializeField] private List<ExitTrigger> _trigger = new List<ExitTrigger>();
    [SerializeField] private List<Trace>  _traces = new List<Trace>();
    [SerializeField] private List<Transform> _itemPlaces = new List<Transform>();
    [SerializeField] private SpriteRenderer _bg;
    [SerializeField] public static Level LoadingLevel;
    [SerializeField] private TimerJuggling _timer;
    [SerializeField] private MenuJuggling _menu;
    [SerializeField] private AttentionJuggling _atent;
    [SerializeField] private Errorbox _box;
    private bool _isSpareLive = false;

    private List<JugglingItem> _items = new List<JugglingItem> ();

    private void Awake()
    {
        if (LoadingLevel == null)
            LoadingLevel = GameAssets.i.levels[0];

        SpeedRange = new MinMax();
        SpeedRange.Min = -LoadingLevel.ItemSpeed;
        SpeedRange.Max = LoadingLevel.ItemSpeed;
        _bg.sprite = LoadingLevel.BackGround;
        _timer.TimeToEnd = LoadingLevel.Time;
        _timer.Setup();
        _timer.OnEnd += Win;

        _traces[0].Speed = LoadingLevel.TraceSpeed;
        _traces[1].Speed = -LoadingLevel.TraceSpeed;

        for (int i = 0; i < LoadingLevel.ItemCount; i++)
        {
            GameObject newItemGO = Instantiate(GameAssets.i.JugglingItems[i].gameObject, _itemPlaces[i]);
            JugglingItem item = newItemGO.GetComponent<JugglingItem>();
            item.Manager = this;
            _items.Add(item);
            item.Setup();
            item.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        foreach (ExitTrigger trigger in _trigger)
        {
            trigger.Chance = LoadingLevel.Chance;
        }
    }

    public void BuyDivide()
    {
        AttentionJuggling.Acti acti = _timer.Divide;
        _atent.SetText("It will cost 150");
        _atent.Show(acti);
    }

    public void BuyLive()
    {
        AttentionJuggling.Acti acti = BuySpareLive;
        _atent.SetText("It will cost 150");
        _atent.Show(acti);
    }

    public void BuySpareLive()
    {
        SaveData.Game game = SaveData.Load();
        game.Money -= 150;
        if (game.Money >= 0)
        {
            _isSpareLive = true;
            SaveData.Save(game);
        }

        else
        {
            _box.Show("Your balance too low");
        }
    }

    public void Lose()
    {
        if (!_isSpareLive)
        {
            if (!_menu.WinMenu.activeSelf && !_menu.LoseMenu.activeSelf)
            {
                stopGame();
                _menu.ShowLose();
            }
        }
        _isSpareLive = false;
    }

    public void Win()
    {
        if (!_menu.WinMenu.activeSelf && !_menu.LoseMenu.activeSelf)
        {
            stopGame();
            _menu.ShowWin((int)LoadingLevel.Win);
            SaveData.Game game = SaveData.Load();
            game.JugglingLevel++;
            game.Money += LoadingLevel.Win;
            SaveData.Save(game);
        }
    }

    private void stopGame()
    {
        foreach (Trace trace in _traces)
        {
            trace.IsWorking = false;
        }

        foreach (JugglingItem item in _items)
        {
            item.GetComponent<Rigidbody2D>().isKinematic = true;
            _timer.IsWork = false;
        }
    }

    public void StartGame()
    {
        _timer.IsWork = true;
        foreach (JugglingItem item in _items)
        {
            item.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    [System.Serializable]
    public class Level
    {
        public Sprite BackGround;
        public float Time;
        public float TraceSpeed;
        public float ItemSpeed;
        public int Chance;
        public int ItemCount;
        public float Win;
        public float Price;
    }
}
