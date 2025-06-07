using UnityEngine;

public class Enemy : MonoBehaviour // will be attach to enemy/obstacle
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("collided with player");
            EventManager.Instance.EnemyCollision();
            other.gameObject.SetActive(false);
        }
    }
}