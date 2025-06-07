using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int score = 0;
    public int CurrentScore => score;

    private void OnEnable()
    {
        EventManager.Instance.OnCoinCollected += HandleCoinCollected;
        EventManager.Instance.OnGameRestart += ResetScore;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnCoinCollected -= HandleCoinCollected;
        EventManager.Instance.OnGameRestart -= ResetScore;
    }

    private void HandleCoinCollected(int amount)
    {
        score += amount;
        EventManager.Instance.UpdateScore(CurrentScore);
    }

    public void ResetScore()
    {
        score = 0;
    }
}