using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Chess : MonoBehaviour
{
    public Point MyCell;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Chip chip))
        {
            chip.Spingshot.AddEnergy();
            DestroyMe();
        }
    }

    public void DestroyMe()
    {
        playSound();
        MyCell.IsBusy = false;
        Destroy(gameObject);
    }

    private void playSound()
    {
        GameObject sound = Instantiate(GameAssets.i.TempSoundP);
        TempSound temp = sound.GetComponent<TempSound>();
        temp.Setup(GameAssets.i.Pickup);
    }

    public ProtectedChess MakeProtected()
    {
        GameObject newChess = Instantiate(GameAssets.i.ProtectedChessPrefab.gameObject, transform.parent);
        ProtectedChess chessScript = newChess.GetComponent<ProtectedChess>();
        return chessScript;
    }
}
