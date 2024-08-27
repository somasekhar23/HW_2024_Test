using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneManager : MonoBehaviour
{
    public GameObject planePrefab;
    private float minPulpitDestroyTime = 4f;
    private float maxPulpitDestroyTime = 5f;
    private float pulpitSpawnTime = 2.5f;
    public GameObject player;
    private float offset = 3.3f;

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
        }
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
