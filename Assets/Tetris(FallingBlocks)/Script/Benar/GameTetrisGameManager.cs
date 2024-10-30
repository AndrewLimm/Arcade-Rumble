using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTetrisGameManager : MonoBehaviour
{
    [SerializeField] GameTetrisBoard gameTetrisBoard;
    [SerializeField] GameTetrisBoardPlayer2 gameTetrisBoardPlayer2;
    [SerializeField] GameTetrisPiecePlayer2 gameTetrisPiecePlayer2;
    [SerializeField] GameTetrisPieces gameTetrisPieces;
    [SerializeField] GameTetrisCoutnDOwn gameTetrisCoutnDOwn;
    [SerializeField] GameTetrisTImer gameTetrisTImer;


    public void StartGame()
    {
        gameTetrisCoutnDOwn.StartCountDownTimer();

    }

    public void AfterCountDown()
    {
        gameTetrisBoard.SpawnPiece();
        gameTetrisBoardPlayer2.SpawnPiecePlayer2();
        gameTetrisPieces.StartPieceGame();
        gameTetrisPiecePlayer2.StartPieceGamePlayer2();
        gameTetrisTImer.StartTimer();
    }
}
