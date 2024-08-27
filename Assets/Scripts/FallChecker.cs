using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float fallThreshold = -3f; // The y-position threshold below which the game will be over

    private GameOverManager gameOverManager;
    private bool hasTriggeredGameOver = false; // Prevent multiple triggers

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned. Please assign the player GameObject in the inspector.");
            return;
        }

        gameOverManager = FindObjectOfType<GameOverManager>();

        if (gameOverManager == null)
        {
            Debug.LogError("GameOverManager not found. Please ensure a GameOverManager script is in the scene.");
        }

        hasTriggeredGameOver = false;
    }

    void Update()
    {
        if (hasTriggeredGameOver)
            return;

        // Check if the player has fallen below the threshold
        if (player.transform.position.y < fallThreshold)
        {
            hasTriggeredGameOver = true;
            // Trigger the game over sequence
            gameOverManager.GameOver();
        }
    }

    public void ResetChecker()
    {
        hasTriggeredGameOver = false;
    }
}
