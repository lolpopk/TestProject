using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTutorial : TutorialJuggling
{
    protected override void Start()
    {
        SaveData.Game game = SaveData.Load();
        _needTutorial = false;

        if (game.TutorialSlot)
        {
            _needTutorial = true;
            game.TutorialSlot = false;
            SaveData.Save(game);
        }

        base.Start();
    }
}
