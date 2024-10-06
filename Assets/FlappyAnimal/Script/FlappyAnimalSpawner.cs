using UnityEngine;

public class FlappyAnimalSpawner : MonoBehaviour
{
    public FlappyAnimalPipes prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 0.5f;
    public float verticalGap = 1.5f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        FlappyAnimalPipes pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        pipes.gap = verticalGap;
    }

}
