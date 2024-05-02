using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTutorial : TutorialJuggling
{
    [SerializeField] private Rigidbody2D _rb;
    protected override void Start()
    {
        _rb.isKinematic = true;
        SaveData.Game game = SaveData.Load();
        _needTutorial = false;

        if (game.TutorialChess)
        {
            _needTutorial = true;
            game.TutorialChess = false;
            SaveData.Save(game);
        }

        base.Start();
    }

    private void OnDestroy()
    {
        _rb.isKinematic = false;
    }
}
