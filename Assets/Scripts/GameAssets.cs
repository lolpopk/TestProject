using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    [SerializeField] public Chess ChessPrefab;
    [SerializeField] public ProtectedChess ProtectedChessPrefab;
    [SerializeField] public List<JugglingItem> JugglingItems;
    [SerializeField] public List<JugglingManager.Level> levels;
    [SerializeField] public AudioClip Spin;
    [SerializeField] public AudioClip Stop;
    [SerializeField] public AudioClip Pickup;
    [SerializeField] public AudioClip Pinko;
    [SerializeField] public GameObject TempSoundP;
    [SerializeField] public AudioClip Click;
}
