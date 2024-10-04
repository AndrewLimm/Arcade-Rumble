using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTetrisBaseTetrisPiece : MonoBehaviour
{
    public GameTetrisBoard board { get; protected set; }
    public GameTetrisBoardPlayer2 boardPlayer2 { get; protected set; }
    public TetrominoData data { get; protected set; }
    public Vector3Int[] cells { get; protected set; }
    public Vector3Int position { get; protected set; }
    public int rotationIndex { get; protected set; }

}
