using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameHUD;
    public GameObject gameOverPanel;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI finalCoinText;
    public TextMeshProUGUI finalDistanceText;
    public Button restartButton;

    private int finalScore = 0;

    private void Start()
    {
        ShowHUD();
        EventManager.Instance.OnScoreUpdate += UpdateScore;
        EventManager.Instance.OnEnemyCollision += ShowGameOver;
        EventManager.Instance.OnGameOver += UpdateGameOverScore;
        EventManager.Instance.OnGameRestart += ShowHUD;
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnScoreUpdate -= UpdateScore;
        EventManager.Instance.OnEnemyCollision -= ShowGameOver;
        EventManager.Instance.OnGameOver -= UpdateGameOverScore;
        EventManager.Instance.OnGameRestart -= ShowHUD;
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }

    public void UpdateScore(int score)
    {
        coinText.SetText("" + score);
        finalScore = score;
    }

    public void ShowGameOver()
    {
        gameHUD.SetActive(false);
        gameOverPanel.SetActive(true);
        float x = 2;
        EventManager.Instance.GameOver(x);
    }

    public void UpdateGameOverScore(float distance)
    {
        finalCoinText.SetText("Coins Collected: " + finalScore);
        finalDistanceText.SetText("Distance Travelled: " + Mathf.FloorToInt(distance));
    }

    public void ShowHUD()
    {
        gameHUD.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    private void OnRestartButtonClicked()
    {
        Debug.Log("1");
        GameManager.Instance.RestartGame();
    }
}