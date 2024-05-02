using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugTutorial : TutorialJuggling
{
    protected override void Start()
    {
        SaveData.Game game = SaveData.Load();
        _needTutorial = false;

        if (game.TutorialJuggling)
        {
            _needTutorial = true;
            game.TutorialJuggling = false;
            SaveData.Save(game);
        }

        base.Start();
    }
}
