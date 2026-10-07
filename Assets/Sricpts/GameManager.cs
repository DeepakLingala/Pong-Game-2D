using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Ball Settings")]
    [SerializeField] private Ball ball;

    [Header("Game Settings")]
    [SerializeField] private int scoreToWin = 20;

    [Header("Main Menu / Game Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject winnerPanel;

    [Header("Game UI")]
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI computerScoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI winText;

    [Header("Audio")]
    [SerializeField] private AudioManager audioManager;

    private int playerScore;
    private int computerScore;
    private float timer;

    private bool gameStarted = false;

    private void Start()
    {
        Time.timeScale = 0f;

        // Main Menu ON
        mainMenuPanel.SetActive(true);

        // Game UI OFF
        gamePanel.SetActive(false);

        // Winner UI OFF
        winnerPanel.SetActive(false);

        ResetScoreAndTimer();

        gameStarted = false;
    }


    private void Update()
    {
        if (!gameStarted)
            return;

        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = minutes + ":" + seconds.ToString("00");
    }

    public void PlayGame()
    {
        Debug.Log("PLAY GAME");

        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
        winnerPanel.SetActive(false);

        ResetScoreAndTimer();

        gameStarted = true;

        Time.timeScale = 1f;

        // Start ball
        ball.ResetPosition();
    }

    public void PlayerScore()
    {
        if (!gameStarted)
            return;

        playerScore++;

        playerScoreText.text = playerScore.ToString();

        Debug.Log("Player Score: " + playerScore);

        if (playerScore >= scoreToWin)
        {
            GameOver("PLAYER WINS!");
            return;
        }

        ball.ResetPosition();
    }

    public void ComputerScore()
    {
        if (!gameStarted)
            return;

        computerScore++;

        computerScoreText.text = computerScore.ToString();

        Debug.Log("Computer Score: " + computerScore);

        if (computerScore >= scoreToWin)
        {
            GameOver("COMPUTER WINS!");
            return;
        }

        ball.ResetPosition();
    }


    private void GameOver(string winnerMessage)
    {
        Debug.Log("GAME OVER: " + winnerMessage);

        // Stop game logic
        gameStarted = false;

        // Stop physics
        Time.timeScale = 0f;

        // Set winner text
        if (winText != null)
        {
            winText.text = winnerMessage;
        }

        // Hide Game UI
        if (gamePanel != null)
        {
            gamePanel.SetActive(false);
        }

        // Show Winner UI
        if (winnerPanel != null)
        {
            winnerPanel.SetActive(true);
        }

        // Play winner sound
        if (audioManager != null)
        {
            audioManager.PlayWinnerSound();
        }
    }

    public void RestartGame()
    {
        Debug.Log("RESTART GAME");

        // Hide Winner UI
        winnerPanel.SetActive(false);

        // Show Game UI
        gamePanel.SetActive(true);

        ResetScoreAndTimer();

        gameStarted = true;

        Time.timeScale = 1f;

        // Start ball
        ball.ResetPosition();
    }


    public void MainMenu()
    {
        Debug.Log("MAIN MENU");

        gameStarted = false;

        Time.timeScale = 0f;

        // Hide Game UI
        gamePanel.SetActive(false);

        // Hide Winner UI
        winnerPanel.SetActive(false);

        // Show Main Menu
        mainMenuPanel.SetActive(true);

        ResetScoreAndTimer();
    }

    private void ResetScoreAndTimer()
    {
        playerScore = 0;
        computerScore = 0;
        timer = 0f;

        if (playerScoreText != null)
        {
            playerScoreText.text = "0";
        }

        if (computerScoreText != null)
        {
            computerScoreText.text = "0";
        }

        if (timerText != null)
        {
            timerText.text = "0:00";
        }

        if (winText != null)
        {
            winText.text = "";
        }
    }

    public void ToggleSound()
    {
        if (audioManager != null)
        {
            audioManager.ToggleSound();
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");

        Application.Quit();
    }
}