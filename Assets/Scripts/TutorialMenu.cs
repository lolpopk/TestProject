using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : TutorialJuggling
{
    protected override void Start()
    {
        SaveData.Game game = SaveData.Load();
        _needTutorial = game.TutorialMenu;
        game.TutorialMenu = false;
        SaveData.Save(game);
        base.Start();
    }
}
