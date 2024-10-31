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

    public void GoToHelpScreen()
    {
        //pindah ke scene Game Slection
        SceneManager.LoadScene("ArcadeRumbleHelpScreen");
    }

    public void GoToAboutScreen()
    {
        //pindah ke scene Game Slection
        SceneManager.LoadScene("ArcadeRumbleAboutScreen");
    }
    public void GoToExit()
    {
        //pindah ke scene Game Slection
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        //pindah ke scene Game Slection
        SceneManager.LoadScene("ArcadeRumbleMainScene");
    }
}
