using UnityEngine;

public class GridPlaneTrigger : MonoBehaviour
{
    private bool hasScored = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !hasScored) 
        {
            PlaneManager planeManager = FindObjectOfType<PlaneManager>();
            if (planeManager != null)
            {
                planeManager.TriggerScore();
                hasScored = true;  
            }
        }
    }
}
