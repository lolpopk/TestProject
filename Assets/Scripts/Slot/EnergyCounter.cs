using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Change(int count)
    {
        _text.text = count.ToString()+"/100";
    }
}
