using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGAmeSetUp : MonoBehaviour
{
    public GameObject cardPrefab; // Prefab untuk kartu
    public int numberOfPairs; // Jumlah pasangan kartu
    public Transform cardParent; // Parent untuk menampung kartu dalam grid

    void Start()
    {
        CreateCards();
    }

    void CreateCards()
    {
        int totalCards = numberOfPairs * 2;
        Sprite[] shuffledSprites = ShuffleSprites(MemoryMatchGameManager.instance.cardSprites);

        for (int i = 0; i < totalCards; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, cardParent);
            MemoryGameCad MemoryGame = newCard.GetComponent<MemoryGameCad>();
            MemoryGame.id = i / 2; // Set ID untuk pasangan
            newCard.transform.position = new Vector3(i % 4, i / 4, 0); // Ubah posisi sesuai grid yang diinginkan
        }
    }

    Sprite[] ShuffleSprites(Sprite[] sprites)
    {
        // Logika untuk mengacak array sprite
        for (int i = 0; i < sprites.Length; i++)
        {
            Sprite temp = sprites[i];
            int randomIndex = Random.Range(i, sprites.Length);
            sprites[i] = sprites[randomIndex];
            sprites[randomIndex] = temp;
        }
        return sprites;
    }
}
