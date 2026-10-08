using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject winPanel;
    public GameObject defeatPanel;
    public GameObject gameOverText;
    public GameObject supremeWinPanel;
    public TMP_Text finalScoreText;
    private bool gameEnded = false;
    private bool defeated = false;
    private bool gameOver = false;
    private void Awake()
    {
        Instance = this;
        if (winPanel != null)
            winPanel.SetActive(false);

        if (defeatPanel != null)
            defeatPanel.SetActive(false);

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (supremeWinPanel != null)
            supremeWinPanel.SetActive(false);

        if (finalScoreText != null)
            finalScoreText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Retry after GAME OVER
        if (gameOver && !defeated && Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }

        // Restart whole game after DEFEAT
        if (defeated && Input.GetKeyDown(KeyCode.B))
        {
            RestartFromBeginning();
        }
    }

    public void WinGame()
    {
        if (gameEnded) return;

        gameEnded = true;

        GameData.Instance.score += GameData.Instance.currentLevelScore;

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        // Level 5 completed
        if (currentScene == 4)
        {
            if (GameData.Instance.score == 10)
            {
                if (supremeWinPanel != null)
                    supremeWinPanel.SetActive(true);

                if (finalScoreText != null)
                {
                    finalScoreText.gameObject.SetActive(true);
                    finalScoreText.text = "FINAL SCORE: 10/10";
                }
            }
            else
            {
                if (winPanel != null)
                    winPanel.SetActive(true);

                if (finalScoreText != null)
                {
                    finalScoreText.gameObject.SetActive(true);
                    finalScoreText.text =
                        "FINAL SCORE: " +
                        GameData.Instance.score +
                        "/10";
                }
            }
        }
        else
        {
            if (winPanel != null)
                winPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;

        GameData.Instance.failCount = 0;
        GameData.Instance.currentLevelScore = 2;

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene + 1);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;

        gameOver = false;

        if (gameOverText != null)
            gameOverText.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartFromBeginning()
    {
        Time.timeScale = 1f;

        defeated = false;
        gameOver = false;

        GameData.Instance.score = 0;
        GameData.Instance.failCount = 0;
        GameData.Instance.currentLevelScore = 2;

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (defeatPanel != null)
            defeatPanel.SetActive(false);

        if (supremeWinPanel != null)
            supremeWinPanel.SetActive(false);

        SceneManager.LoadScene(0);
    }

    public void ShowGameOver()
    {
        gameOver = true;

        if (gameOverText != null)
            gameOverText.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ShowDefeat()
    {
        defeated = true;

        if (defeatPanel != null)
            defeatPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}