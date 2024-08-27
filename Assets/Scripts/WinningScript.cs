using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{
    // This method will be called when the Restart button is clicked
    public void RestartGame()
    {
        // Reload the main game scene
        SceneManager.LoadScene("MainScene"); // Replace "MainScene" with the actual name of your main game scene
    }

    // This method will be called when the Quit button is clicked
    public void QuitGame()
    {
        // Close the game application
        Application.Quit();

        // If you are in the editor, you can stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
