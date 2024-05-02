using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Level = JugglingManager.Level;

[RequireComponent(typeof(LerpFloat))]
public class LevelCell : MonoBehaviour
{
    public Level Level { get; private set; }
    [SerializeField] public int Index;
    [SerializeField] private Image _bgImage;
    [SerializeField] private TMP_Text _indexText;
    [SerializeField] public Transform LokingPart;
    [SerializeField] private ChooseLevel _manager;


    public void Setup(List<int> unlokedLevel)
    {
        Level = GameAssets.i.levels[Index];
        _indexText.text = "Level:" + Index.ToString();
        _bgImage.sprite = Level.BackGround;
        foreach (int lev in unlokedLevel)
        {
            if (lev == Index) LokingPart.gameObject.SetActive(false);
        }
    }

    public void Load()
    {
        if (LokingPart.gameObject.activeSelf)
        {
            _manager.Attention.Show(Level.Price, this);
        }

        else
        {
            _manager.Load(this);
        }
    }
}
