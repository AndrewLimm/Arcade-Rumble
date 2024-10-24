using UnityEngine;

public class FlappyAnimalPipes : MonoBehaviour
{
    public Transform top;         // Transform untuk pipa atas
    public Transform bottom;      // Transform untuk pipa bawah
    public float speed = 5f;      // Kecepatan gerakan pipa
    public float gap = 3f;        // Jarak antara pipa atas dan bawah

    private Transform destroyPoint; // Referensi ke titik hancur

    public bool canMove = true;

    private void Start()
    {
        // Sesuaikan posisi pipa atas dan bawah berdasarkan gap
        top.position += Vector3.up * gap / 2;
        bottom.position += Vector3.down * gap / 2;

        // Cari gameObject dengan tag "DestroyPoint" untuk digunakan sebagai titik hancur
        destroyPoint = GameObject.FindGameObjectWithTag("DestroyPoint").transform;
    }

    private void Update()
    {
        if (canMove) // Gerakkan pipa hanya jika bisa bergerak
        {
            // Gerakkan pipa ke kiri
            transform.position += speed * Time.deltaTime * Vector3.left;

            // Hancurkan pipa ketika mencapai posisi destroyPoint
            if (destroyPoint != null && transform.position.x < destroyPoint.position.x)
            {
                Destroy(gameObject);
            }
        }
    }
    public void StopMovement()
    {
        canMove = false;
    }
}
