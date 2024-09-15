using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Mechanic : MonoBehaviour
{
    public ReactionMechanic reactionMechanic;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Player 2 pressed L");
            reactionMechanic.PlayerWin(2);
        }
    }
}
