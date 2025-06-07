using UnityEngine;

public class Platform: MonoBehaviour //will be attach to platform
{
    [SerializeField] private Transform enemyPoint;
    [SerializeField] private Transform coinPoint;

    public Transform EnemyPoint => enemyPoint;
    public Transform CoinPoint => coinPoint;
}