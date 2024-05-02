using System.Collections.Generic;
using UnityEngine;
using MaxMin = Circle.MaxMin;

public class ChessDesk : MonoBehaviour
{
    [SerializeField] private MaxMin _rangeChess;
    [SerializeField] private MaxMin _rangeProtectedChess;
    [SerializeField] private EnergyCounter _energy;
    private List<Chess> _chesses = new List<Chess>();

    [SerializeField] private List<Transform> _parentsCell = new List<Transform>();
    private List<Point> _cells = new List<Point>();

    private void Awake()
    {
        foreach (Transform parentCell in _parentsCell)
        {
            foreach (Transform childCell in parentCell)
            {
                _cells.Add(childCell.GetComponent<Point>());
            }
        }

        int chessCount = Random.Range((int)_rangeChess.Min, (int)_rangeChess.Max);
        int protectedChessCount = Random.Range((int)_rangeProtectedChess.Min, (int)_rangeProtectedChess.Max);

        List<Point> cellsWithChess = new List<Point>();
        List<Point> cellsWithProtectedChess = new List<Point>();

        List<Point> cells = new List<Point>();
        foreach (Point cell in _cells) cells.Add(cell);

        for (int i = 0; i < chessCount; i++)
        {
            int randomIndex = Random.Range(0, cells.Count);

            Point cell = cells[randomIndex];

            InstantiateChess(GameAssets.i.ChessPrefab, cell);

            cells.RemoveAt(randomIndex);

            cellsWithChess.Add(cell);
        }

        for (int i = 0; i < protectedChessCount; i++)
        {
            int randomIndex = Random.Range(0, cellsWithChess.Count);
            Point key = cellsWithChess[randomIndex];

            InstantiateChess(GameAssets.i.ProtectedChessPrefab, key);

            cellsWithChess.RemoveAt(randomIndex);
            cellsWithProtectedChess.Add(key);
        }
    }

    public Chess InstantiateChess(Chess chessPrefab, Point cell)
    {
        cell.IsBusy = true;
        GameObject chessGo = Instantiate(chessPrefab.gameObject, cell.transform);
        Chess chess = chessGo.GetComponent<Chess>();
        chess.MyCell = cell;
        return chess;
    }
}
