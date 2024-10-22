using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTestMixMayhemPlayer1Mechanic : MonoBehaviour
{
    public ReactionTestMixMayhemGameManager reactionMechanic;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Player 1 pressed A");
            reactionMechanic.PlayerWin(1);
        }
    }
}
