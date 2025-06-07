using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetY = 2f;
    public float smoothSpeed = 5f;

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(
                transform.position.x,        // Keep X
                player.position.y + offsetY, // Instantly match Y
                transform.position.z         // Keep Z
            );
        }
    }
}