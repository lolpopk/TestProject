using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpingShot : MonoBehaviour
{
    [SerializeField] public Chip Chip;
    [SerializeField] private Chip _chipPrefab;
    [SerializeField] private SpingshotRope _rope;
    [SerializeField] private Transform _middle;
    [SerializeField] private Gate _gate;
    [SerializeField] private EnergyCounter _energy;
    [SerializeField] private List<Rigidbody2D> _jountBody = new List<Rigidbody2D>();

    private bool _isInteract = false;
    private Rigidbody2D _ropeRB;
    private void Awake()
    {
        _ropeRB = _rope.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        int energy = SaveData.Load().Energy;
        _energy.Change(energy);
    }


    public void Realeas()
    {
        Chip = null;
    }

    public void Interact(bool interact)
    {
        _ropeRB.isKinematic = interact;
        _isInteract = interact;
    }

    public void AddEnergy()
    {
        SaveData.Game game = SaveData.Load();
        game.Energy++;
        SaveData.Save(game);
        _energy.Change(game.Energy);
    }

    public void MakeNew()
    {
        GameObject newChip = Instantiate(_chipPrefab.gameObject, transform);
        Chip = newChip.GetComponent<Chip>();
        Chip.Spingshot = this;
        Chip.JountsRB.Clear();
        Chip.JountsRB.Add(_middle);
        Chip.statRB.Add(_jountBody[0]);
        Chip.statRB.Add(_jountBody[1]);
        _gate.SwitchGate(true);
    }

    private void Update()
    {
        if (Chip != null)
        {
            _ropeRB.position = Chip.transform.position;
            _rope.UpdateRope();
            //if (_isInteract) _trajectory.Simulate(Chip);
        }
    }


}
