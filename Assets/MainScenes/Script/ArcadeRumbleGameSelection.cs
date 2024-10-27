using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeRumbleGameSelection : MonoBehaviour
{
    public void GoToGameSelectionScreen()
    {
        //pindah ke scene Game Slection
        SceneManager.LoadScene("ArcadeRumbleGameSelection");
    }
}
