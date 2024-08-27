using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("StartGame called. Loading MainScene...");
        SceneManager.LoadScene("MainScene");
    }
}
