// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;

// public class QuickMathUITimer : MonoBehaviour
// {
//     public TMP_Text timerText;  // Referensi ke UI Text (gunakan TextMeshPro untuk teks)

//     void OnEnable()
//     {
//         // Subscribing ke event yang meng-update waktu
//         QuickMathGameTImer.OnTimeUpdated += UpdateTimerUI;
//     }

//     void OnDisable()
//     {
//         // Unsubscribing dari event
//         QuickMathGameTImer.OnTimeUpdated -= UpdateTimerUI;
//     }

//     // Fungsi untuk memperbarui UI Timer
//     private void UpdateTimerUI(float timeRemaining)
//     {
//         // Format waktu menjadi menit:detik
//         int minutes = Mathf.FloorToInt(timeRemaining / 60f);
//         int seconds = Mathf.FloorToInt(timeRemaining % 60f);

//         // Memperbarui teks UI
//         timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
//     }
// }
