using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Mechanic : MonoBehaviour
{

    public ReactionMechanic reactionMechanic;
    private bool isInputEnabled = false; // Flag untuk mengendalikan input

    void Update()
    {
        if (isInputEnabled)
        {
            HandlePlayer2Input(); // Hanya periksa input jika diizinkan
        }
    }

    public void EnableInput() // Memungkinkan input
    {
        isInputEnabled = true;
    }

    void HandlePlayer2Input()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Pemain 2 menekan L");
            reactionMechanic.PlayerWin(2); // Panggil untuk menangani kemenangan Pemain 2
        }
    }
}
