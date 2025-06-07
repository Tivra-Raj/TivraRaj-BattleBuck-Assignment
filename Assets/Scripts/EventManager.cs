using System;
using UnityEngine;

public class EventManager : GenericMonoSingleton<EventManager>
{
    public event Action<int> OnCoinCollected;
    public event Action<int> OnScoreUpdate;
    public event Action OnEnemyCollision;
    public event Action<float> OnGameOver; // score, distance
    public event Action OnGameRestart;

    public void CoinCollected(int coin)
    {
        OnCoinCollected?.Invoke(coin);
    }

    public void UpdateScore(int value)
    {
        OnScoreUpdate?.Invoke(value);
    }

    public void EnemyCollision()
    {
        OnEnemyCollision?.Invoke();
    }

    public void GameOver(float distance)
    {
        OnGameOver?.Invoke(distance);
    }

    public void GameRestart()
    {
        OnGameRestart?.Invoke();
    }
}