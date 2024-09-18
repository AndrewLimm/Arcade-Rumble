using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopTheBalloonPlayerInput2 : MonoBehaviour
{
    public KeyCode leftKey = KeyCode.J; // Tombol untuk input kiri
    public KeyCode middleKey = KeyCode.K; // Tombol untuk input tengah
    public KeyCode rightKey = KeyCode.L; // Tombol untuk input kanan

    public bool IsInputCorrect(string balloonType)
    {
        // Periksa apakah input yang diberikan sesuai dengan jenis balon
        if (balloonType == "Red" && Input.GetKey(leftKey))
            return true;
        if (balloonType == "Yellow" && Input.GetKey(middleKey))
            return true;
        if (balloonType == "Green" && Input.GetKey(rightKey))
            return true;
        return false;
    }
}
