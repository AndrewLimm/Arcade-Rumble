using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectionBUtton : MonoBehaviour
{
    public void CatchItemButton()
    {
        //pindah ke scene Game Slection
        SceneManager.LoadScene("CatchItem");
    }

    public void CollecTheCoin()
    {
        SceneManager.LoadScene("CollectTheCoinScene");
    }
    public void FlappyAnimal()
    {
        SceneManager.LoadScene("FlappyAnimal");
    }

    public void GameTembak()
    {
        SceneManager.LoadScene("GameTembakDemoScene");
    }

    public void HelpMeOut()
    {
        SceneManager.LoadScene("HelpMeOut");
    }

    public void JumpOver()
    {
        SceneManager.LoadScene("JumpOver");
    }

    public void KarateAnimal()
    {
        SceneManager.LoadScene("KarateAnimal");
    }

    public void MemoryMatch()
    {
        SceneManager.LoadScene("MemoryMatchDemo");
    }

    public void QuickMath()
    {
        SceneManager.LoadScene("QuickMathDemo");
    }

    public void QuickTap()
    {
        SceneManager.LoadScene("QuickTapDemo");
    }
}

