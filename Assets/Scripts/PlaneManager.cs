using System.Collections;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    public GameObject planePrefab;
    public float minPulpitDestroyTime = 4f;
    public float maxPulpitDestroyTime = 5f;
    public float pulpitSpawnTime = 2.5f;
    public GameObject player;
    public float offset = 3.3f;

    private GameObject currentPlane;
    private GameObject nextPlane;
    private bool isGameOver = false;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned. Please assign the player GameObject in the inspector.");
            return;
        }

        if (planePrefab == null)
        {
            Debug.LogError("Plane prefab not assigned. Please assign the planePrefab in the inspector.");
            return;
        }

        SpawnInitialPlane();
        StartCoroutine(ManagePlanes());
    }

    void SpawnInitialPlane()
    {
        currentPlane = Instantiate(planePrefab, Vector3.zero, Quaternion.identity);
    }

    IEnumerator ManagePlanes()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(pulpitSpawnTime);

            if (currentPlane != null)
            {
                Vector3 randomPosition = GetRandomPosition();
                nextPlane = Instantiate(planePrefab, randomPosition, Quaternion.identity);
            }

            float pulpitLifetime = Random.Range(minPulpitDestroyTime, maxPulpitDestroyTime);
            yield return new WaitForSeconds(pulpitLifetime - pulpitSpawnTime);

            if (currentPlane != null)
            {
                Destroy(currentPlane);
                currentPlane = nextPlane;
            }

            CheckGameOver();
        }
    }

    public void TriggerScore()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore();
        }
        else
        {
            Debug.LogError("ScoreManager instance is not available.");
        }
    }

    void CheckGameOver()
    {
        if (player.transform.position.y < -3)
        {
            isGameOver = true;
            Debug.Log("Game Over! The player has fallen.");

            // Stop all coroutines and trigger the GameOver method in GameOverManager immediately
            StopAllCoroutines();
            FindObjectOfType<GameOverManager>().GameOver();
        }
    }

    public void ResetGame()
    {
        isGameOver = false;
        StopAllCoroutines();  // Stop any running coroutines
        SpawnInitialPlane();
        StartCoroutine(ManagePlanes());  // Restart the plane management coroutine
    }

    Vector3 GetRandomPosition()
    {
        if (currentPlane == null)
        {
            return Vector3.zero;
        }

        int randomDirection = Random.Range(0, 4);
        Vector3 offsetPosition = Vector3.zero;

        switch (randomDirection)
        {
            case 0: offsetPosition = new Vector3(offset, 0, 0); break;
            case 1: offsetPosition = new Vector3(-offset, 0, 0); break;
            case 2: offsetPosition = new Vector3(0, 0, offset); break;
            case 3: offsetPosition = new Vector3(0, 0, -offset); break;
        }

        return currentPlane.transform.position + offsetPosition;
    }
}
