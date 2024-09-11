using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text _gameOverText;
    public bool _gameEnded = false;

    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
    }

    public void TriggerGameOver()
    {
        if (!_gameEnded)
        {
            _gameOverText.gameObject.SetActive(true);
            _gameEnded = true;
            Debug.Log("Game Over Triggered!");
        }
    }
}
