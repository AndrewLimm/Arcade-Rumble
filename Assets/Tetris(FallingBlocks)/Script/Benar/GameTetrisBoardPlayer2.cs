using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTetrisBoardPlayer2 : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }
    public GameTetrisPiecePlayer2 activepieceplayer2 { get; private set; }
    public TetrominoData[] tetrominoes;
    public Vector3Int spawnPosition = new Vector3Int(1, 8, 0); // Posisi spawn untuk Player 2

    public Vector2Int boardSize = new Vector2Int(10, 20);


    public int leftBound = -10; // Set batas kiri
    public int rightBound = -4; // Set batas kanan
    public int bottomBound = -10; // Batas bawah
    public int topBound = 10; // Batas atas (opsional)


    [SerializeField] GameTetrisScoreManager gameTetrisScoreManager;

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        activepieceplayer2 = GetComponentInChildren<GameTetrisPiecePlayer2>();
        gameTetrisScoreManager = FindObjectOfType<GameTetrisScoreManager>();

        for (int i = 0; i < tetrominoes.Length; i++)
        {
            tetrominoes[i].Initialize();
        }
    }


    public void SpawnPiecePlayer2()
    {
        int randomIndex = Random.Range(0, tetrominoes.Length);
        TetrominoData data = tetrominoes[randomIndex];

        activepieceplayer2.Initialize(this, spawnPosition, data);

        if (IsValidPosition(activepieceplayer2, spawnPosition))
        {
            Set(activepieceplayer2);
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        tilemap.ClearAllTiles();
        // Add additional game over logic here...
    }

    public void Set(GameTetrisBaseTetrisPiece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    public void Clear(GameTetrisBaseTetrisPiece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, null);
        }
    }

    public bool IsValidPosition(GameTetrisBaseTetrisPiece piece, Vector3Int position)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            if (tilePosition.x < leftBound || tilePosition.x > rightBound)
            {
                return false; // Out of horizontal bounds
            }

            if (tilePosition.y < bottomBound)
            {
                return false; // Out of vertical bounds
            }

            if (tilemap.HasTile(tilePosition))
            {
                return false; // Tile is occupied
            }
        }
        return true;
    }

    public void ClearLines()
    {
        int row = bottomBound;
        int linesCleared = 0;

        while (row < topBound)
        {
            if (IsLineFull(row))
            {
                LineClear(row);
                linesCleared++;
            }
            else
            {
                row++;
            }
        }
        if (linesCleared > 0 && gameTetrisScoreManager != null)
        {
            gameTetrisScoreManager.AddScorePlayer2(linesCleared); // Tambahkan skor berdasarkan garis yang dihancurkan
            FindObjectOfType<gameTetrisUiScoreManager>().UpdateScoreUI(); // Perbarui skor pada UI
        }
    }

    public bool IsLineFull(int row)
    {
        for (int col = leftBound; col <= rightBound; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            if (!tilemap.HasTile(position))
            {
                return false;
            }
        }

        return true;
    }

    public void LineClear(int row)
    {
        for (int col = leftBound; col <= rightBound; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            tilemap.SetTile(position, null);
        }

        for (int r = row + 1; r < topBound; r++)
        {
            for (int col = leftBound; col <= rightBound; col++)
            {
                Vector3Int abovePosition = new Vector3Int(col, r, 0);
                TileBase aboveTile = tilemap.GetTile(abovePosition);

                Vector3Int currentPosition = new Vector3Int(col, r - 1, 0);
                tilemap.SetTile(currentPosition, aboveTile);
            }
        }
    }
}
