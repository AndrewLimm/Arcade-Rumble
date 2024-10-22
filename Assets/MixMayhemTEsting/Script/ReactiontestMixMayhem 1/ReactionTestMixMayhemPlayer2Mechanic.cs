using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTestMixMayhemPlayer2Mechanic : MonoBehaviour
{
    public ReactionTestMixMayhemGameManager reactionMechanic;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Player 1 pressed L");
            reactionMechanic.PlayerWin(2);
        }
    }
}
