using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInput : MonoBehaviour
{
    public KeyCode trashCollectKey; // Tombol untuk collect sampah
    private PlayerCollect playerCollect;

    [SerializeField] public AudioClip collectSound; // Suara untuk collect makanan edible
    public AudioSource audioSource;

    private void Start()
    {
        playerCollect = FindAnyObjectByType<PlayerCollect>(); // Mengakses skrip PlayerCollect
    }

    public void StartTrashInputCoroutine()
    {
        StartCoroutine(HandleTrashInputPLayer1());
    }

    private IEnumerator HandleTrashInputPLayer1()
    {
        while (true) // Loop untuk memeriksa input terus menerus
        {
            if (!FindObjectOfType<QuickTapTImer>().IsGameActive())
            {
                yield break; // Keluar dari coroutine jika permainan tidak aktif
            }
            // Jika pemain menekan tombol untuk collect trash
            if (Input.GetKeyDown(trashCollectKey))
            {
                GameObject frontTrash = playerCollect.GetFrontFoodInRange(); // Dapatkan sampah terdepan
                if (frontTrash != null)
                {
                    if (frontTrash.CompareTag("Trash"))
                    {
                        playerCollect.CollectTrash(frontTrash); // Jika trash, collect
                        PlayCollectSound(); // Mainkan suara pengambilan

                        Debug.Log("Sampah berhasil diambil: " + frontTrash.name);
                    }
                    else
                    {
                        playerCollect.WrongCollection(frontTrash); // Jika salah, beri penalti
                        Debug.Log("Salah mengambil objek: " + frontTrash.name);
                    }
                }
            }

            yield return null; // Tunggu hingga frame berikutnya
        }
    }

    private void PlayCollectSound()
    {
        if (collectSound != null)
        {
            audioSource.PlayOneShot(collectSound); // Mainkan suara collect
        }
    }
}
