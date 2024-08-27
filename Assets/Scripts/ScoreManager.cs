using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    private int score = 0;
    private int winningScore = 50;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore()
    {
        score++;
        Debug.Log("Score incremented! New score: " + score);
        UpdateScoreText();

        if (score >= winningScore)
        {
            WinGame();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("Score Text is not assigned!");
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void ResetScore()
    {
        score = 0;
    }
    void WinGame()
    {
        SceneManager.LoadScene("WinningScene");
    }
}
