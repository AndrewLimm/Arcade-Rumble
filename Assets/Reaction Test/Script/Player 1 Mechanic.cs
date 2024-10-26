using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Mechanic : MonoBehaviour
{

    public ReactionMechanic reactionMechanic;
    private bool isInputEnabled = false; // Flag untuk mengendalikan input

    void Update()
    {
        if (isInputEnabled)
        {
            HandlePlayer1Input(); // Hanya periksa input jika diizinkan
        }
    }

    public void EnableInput() // Memungkinkan input
    {
        isInputEnabled = true;
    }

    void HandlePlayer1Input()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Pemain 1 menekan A");
            reactionMechanic.PlayerWin(1); // Panggil untuk menangani kemenangan Pemain 1
        }
    }
}
