using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerGameTembak : MonoBehaviour
{
    public DisableAttackPlayer1GameTembak disableAttackPlayer1;
    public DisableAttackPlayer2GameTembak disableAttackPlayer2;
    public Player1Control player1Control1;
    public Player2ControllerGameTembak Player2Control;

    public void OnPlayerHit(string playerTag)
    {
        if (playerTag == "Player1")
        {
            disableAttackPlayer1.DisablePlayer1Attack();
            disableAttackPlayer1.player1Controller.ReceiveDamagePlayer1();
            Debug.Log("Peluru mengenai Player 1 dari GameController!");
        }
        else if (playerTag == "Player2")
        {
            disableAttackPlayer2.DisablePlayer2Attack();
            // Panggil metode TakeDamage di Player2Control
            Player2Control.ReceiveDamagePlayer2();
            Debug.Log("Peluru mengenai Player 2 dari GameController!");
        }
    }
}
