using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject BackGround; 
    public TMP_Text finalScoreText; 

    void Start()
    {
        
        BackGround.SetActive(false);
    }

    public void GameOver()
    {
        
        if (ScoreManager.instance != null)
        {
            finalScoreText.text = "Score: " + ScoreManager.instance.GetScore().ToString();
        }
        BackGround.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        ResetGame();

        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void ResetGame()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }
        PlaneManager planeManager = FindObjectOfType<PlaneManager>();
        if (planeManager != null)
        {
            planeManager.ResetGame();
        }
    }
}
