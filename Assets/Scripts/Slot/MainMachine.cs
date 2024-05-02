using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainMachine : MonoBehaviour
{
    [SerializeField] private Circle[] _circles = new Circle[3];
    [SerializeField] private BalanceText _text;
    [SerializeField] private Attention _attention;
    [SerializeField] private EnergyCounter _energy;
    [SerializeField] private Errorbox _error;
    private AudioSource _source;

    private void Start()
    {
        SaveData.Game game = SaveData.Load();
        _text.Balance.text = game.Money.ToString();
        _energy.Change(game.Energy);
        _source = GetComponent<AudioSource>();
        _source.clip = GameAssets.i.Spin;
        _source.loop = true;
        float volume = 0.5f;

        if (PlayerPrefs.HasKey("Sounds"))
            volume = PlayerPrefs.GetFloat("Sounds");

        else
            PlayerPrefs.SetFloat("Sounds", volume);

        _source.volume = volume;
    }

    public void ShowAttention(Circle circle)
    {
        _attention.Show(this, circle);
    }

    public bool SpinOne()
    {
        bool result = false;
        if (!IsSpining())
        {
            SaveData.Game game = SaveData.Load();
            result = game.Money >= 150;
            if (result)
            {
                _source.Play();
                game.Money -= 150;
                SaveData.Save(game);
                _text.Add(150, game.Money, "-");
            }

            else
            {
                _error.Show("Your balance too low");
            }
        }

        return result;
    }

    public void SpinAll()
    {
        SaveData.Game game = SaveData.Load();
        if (game.Energy > 0)
        {
            _source.Play();
            game.Energy--;
            SaveData.Save(game);
            _energy.Change(game.Energy);
            if (!IsSpining())
            {
                foreach (Circle circle in _circles)
                {
                    circle.StartSpin();
                }
            }
        }

        else
        {
            _error.Show("Your energy is too low, go menu and play chess");
        }

    }

    private bool _oldSpin = false;
    public bool IsSpining()
    {
        bool result = _circles[0].IsSpining;

        for (int i = 1; i < _circles.Length; i++)
        {
            result = result || _circles[i].IsSpining;
        }

        if (_oldSpin && !result)
        {
            CheckResult();
        }

        _oldSpin = result;

        return result;
    }

    public void CheckResult()
    {
        bool firstSecond = checkTwoCircle(_circles[0], _circles[1]);
        bool secondThird = checkTwoCircle(_circles[1], _circles[2]);

        bool x2 = firstSecond || secondThird;
        bool x3 = firstSecond && secondThird;
        if (x3)
        {
            Add(300);
        }

        else if (x2)
        {
            Add(100);
        }

        _source.Stop();
    }

    private void Add(float amout)
    {
        SaveData.Game game = SaveData.Load();
        game.Money += amout;
        SaveData.Save(game);
        _text.Add(amout, game.Money);
    }

    private bool checkTwoCircle(Circle first, Circle second)
    {
        bool result = false;
        Vector3 firstRotation = first.transform.rotation.eulerAngles;
        Vector3 secondRotation = second.transform.rotation.eulerAngles;

        result = firstRotation.z == secondRotation.z;
        result = firstRotation.z + 180f == secondRotation.z || result;
        result = firstRotation.z == secondRotation.z + 180f || result;

        return result;

    }
}
