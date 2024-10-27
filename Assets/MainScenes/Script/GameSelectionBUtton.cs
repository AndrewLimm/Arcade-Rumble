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
}
