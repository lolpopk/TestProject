using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomButtonPress : CustomButton
{
    public bool IsPressed { get; private set; }

    protected override void OnMouseDown()
    {
        IsPressed = true;
        base.OnMouseDown();
    }

    protected virtual void OnMouseUp()
    {
        IsPressed = false;
    }
}
