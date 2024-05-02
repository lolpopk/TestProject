using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class CustomButton : MonoBehaviour
{
    [SerializeField]
    protected Button.ButtonClickedEvent _onClick = new Button.ButtonClickedEvent();

    protected virtual void OnMouseDown()
    {
        _onClick.Invoke();
        playSound();
    }

    protected virtual void playSound()
    {
        ClipPlayer.I.Play(GameAssets.i.Click);
    }
}
