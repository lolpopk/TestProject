using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCustomButton : CustomButton
{
    protected virtual void playSound()
    {
        ClipPlayer.I.Play(GameAssets.i.Click);
    }


}
