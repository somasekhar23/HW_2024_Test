using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    private float horizontalInput;
    private float forwardInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontalInput, 0, forwardInput);
        transform.Translate(move * Time.deltaTime * speed, Space.World);
    }
}
