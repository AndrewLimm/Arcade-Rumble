using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerGameTembek : MonoBehaviour
{
    public float speed = 1f;
    public float moveDownDistance = 0.5f;

    private bool movingRight = true;

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        // Gerakan ke kanan
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika musuh mencapai batas, ganti arah dan turun
        if (other.CompareTag("Boundary"))
        {
            movingRight = !movingRight;
            transform.position = new Vector2(transform.position.x, transform.position.y - moveDownDistance);
        }
    }
}
