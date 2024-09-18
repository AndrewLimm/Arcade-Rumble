using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopTheBalloonPlayerInput1 : MonoBehaviour
{
    public KeyCode leftKey = KeyCode.A; // Tombol untuk input kiri
    public KeyCode middleKey = KeyCode.S; // Tombol untuk input tengah
    public KeyCode rightKey = KeyCode.D; // Tombol untuk input kanan

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
