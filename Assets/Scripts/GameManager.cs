using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GenericMonoSingleton<GameManager>
{
    private bool isGameOver;

    void Update()
    {
        if (isGameOver) return;
    }

    public void GameOver()
    {
        isGameOver = true;
        EventManager.Instance.GameOver(Time.timeSinceLevelLoad);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Debug.Log("2");
        Time.timeScale = 1f;
        EventManager.Instance.GameRestart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}