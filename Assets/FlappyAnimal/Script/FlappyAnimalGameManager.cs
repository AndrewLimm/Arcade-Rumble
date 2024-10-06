using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class FlappyAnimalGameManager : MonoBehaviour
{
    public static FlappyAnimalGameManager Instance { get; private set; }

    [SerializeField] private FlappyAnimalPlayer1Control player1;
    [SerializeField] private FlappyAnimalPlayer2Controller player2;
    [SerializeField] private FlappyAnimalSpawner spawner;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player1.enabled = false;
        player2.enabled = false;
    }

    public void Play()
    {
        FlappyAnimalScoreManager.Instance.ResetScores();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player1.enabled = true;
        player2.enabled = true;

        FlappyAnimalPipes[] pipes = FindObjectsOfType<FlappyAnimalPipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

}
