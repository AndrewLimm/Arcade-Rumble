using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTembakMixMayhemGameCOntroll : MonoBehaviour
{
    public GameTembakMixMayhemDisableAttackPlayer1 disableAttackPlayer1;
    public GameTembakMixMayhemDisableAttackPlayer2 disableAttackPlayer2;

    public void OnPlayerHit(string playerTag)
    {
        if (playerTag == "Player1")
        {
            disableAttackPlayer1.DisablePlayer1Attack();
            Debug.Log("Peluru mengenai Player 1 dari GameController!");
        }
        else if (playerTag == "Player2")
        {
            disableAttackPlayer2.DisablePlayer2Attack();
            // Panggil metode TakeDamage di Player2Control
            Debug.Log("Peluru mengenai Player 2 dari GameController!");
        }
    }
}
