using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Mechanic : MonoBehaviour
{
    public ReactionMechanic reactionMechanic;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Player 1 pressed A");
            reactionMechanic.PlayerWin(1);
        }
    }
}
