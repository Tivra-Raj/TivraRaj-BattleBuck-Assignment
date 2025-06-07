using UnityEngine;

public class Coin : MonoBehaviour //will be attach to coin prrefab
{
    public int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            EventManager.Instance.CoinCollected(value);
            this.gameObject.SetActive(false);
        }
    }
}