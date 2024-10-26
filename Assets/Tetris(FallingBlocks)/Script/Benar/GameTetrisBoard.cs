using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[DefaultExecutionOrder(-1)]
public class GameTetrisBoard : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }
    // Ubah menjadi single instance, bukan array

    public GameTetrisPieces activePiece;
    public TetrominoData[] tetrominoes;
    public Vector2Int boardSize = new Vector2Int(10, 20);

    // Boundary configuration
    public int leftBound = -10; // Set batas kiri
    public int rightBound = -4; // Set batas kanan
    public int bottomBound = -10; // Batas bawah
    public int topBound = 10; // Batas atas (opsional)

    public Vector3Int spawnPosition = new Vector3Int(-1, 8, 0);

    [SerializeField] GameTetrisScoreManager gameTetrisScoreManager;

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        activePiece = GetComponentInChildren<GameTetrisPieces>();

        for (int i = 0; i < tetrominoes.Length; i++)
        {
            tetrominoes[i].Initialize();
        }
    }

    public void SpawnPiece()
    {
        int randomIndex = Random.Range(0, tetrominoes.Length);
        TetrominoData data = tetrominoes[randomIndex];

        activePiece.Initialize(this, spawnPosition, data);

        if (IsValidPosition(activePiece, spawnPosition))
        {
            Set(activePiece);
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

    // Use manual boundary checks here instead of RectInt Bounds
    public bool IsValidPosition(GameTetrisBaseTetrisPiece piece, Vector3Int position)
    {
        // Check boundaries manually (leftBound and rightBound)
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            // Check if tile is within the left and right boundaries
            if (tilePosition.x < leftBound || tilePosition.x > rightBound)
            {
                return false; // Out of horizontal bounds
            }

            // Check bottom bound if necessary
            if (tilePosition.y < bottomBound)
            {
                return false; // Out of vertical bounds
            }

            // Check if there's already a tile in that position
            if (tilemap.HasTile(tilePosition))
            {
                return false; // Tile is occupied
            }
        }
        return true;
    }

    public void ClearLines()
    {
        int linesCleared = 0;
        int row = bottomBound;

        // Clear from bottom to top
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
            gameTetrisScoreManager.AddScorePlayer1(linesCleared);
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
        // Clear all tiles in the row
        for (int col = leftBound; col <= rightBound; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            tilemap.SetTile(position, null);
        }

        // Shift every row above down one
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
