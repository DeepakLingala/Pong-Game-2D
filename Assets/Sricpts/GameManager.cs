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

    [Header("Level Settings")]
    [SerializeField] private GameObject levelPanel;

    [Header("Game UI")]
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI computerScoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI winText;

    [Header("Level UI")]
    [SerializeField] private TextMeshProUGUI selectedLevelText;

    [Header("Audio")]
    [SerializeField] private AudioManager audioManager;

    private int playerScore;
    private int computerScore;
    private float timer;

    private bool gameStarted = false;


    // ==========================================
    // START
    // ==========================================

    private void Start()
    {
        // Pause game
        Time.timeScale = 0f;

        // Main Menu ON
        mainMenuPanel.SetActive(true);

        // Game Panel OFF
        gamePanel.SetActive(false);

        // Winner Panel OFF
        winnerPanel.SetActive(false);

        // Level Panel OFF
        levelPanel.SetActive(false);

        // Default level
        scoreToWin = 20;

        UpdateSelectedLevelText();

        ResetScoreAndTimer();

        gameStarted = false;
    }


    // ==========================================
    // UPDATE
    // ==========================================

    private void Update()
    {
        if (!gameStarted)
            return;

        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = minutes + ":" + seconds.ToString("00");
    }


    // ==========================================
    // PLAY BUTTON
    // ==========================================

    public void PlayGame()
    {
        Debug.Log("PLAY GAME");

        // Hide Main Menu
        mainMenuPanel.SetActive(false);

        // Hide Level Panel
        levelPanel.SetActive(false);

        // Show Game Panel
        gamePanel.SetActive(true);

        // Hide Winner Panel
        winnerPanel.SetActive(false);

        // Reset score and timer
        ResetScoreAndTimer();

        // Start game
        gameStarted = true;

        Time.timeScale = 1f;

        // Start ball
        ball.ResetPosition();
    }

    public void OpenLevelPanel()
    {
        Debug.Log("LEVEL PANEL OPEN");

        // Hide Main Menu
        mainMenuPanel.SetActive(false);

        // Show Level Panel
        levelPanel.SetActive(true);
    }


    public void CloseLevelPanel()
    {
        Debug.Log("LEVEL PANEL CLOSED");

        // Hide Level Panel
        levelPanel.SetActive(false);

        // Show Main Menu
        mainMenuPanel.SetActive(true);
    }


    public void SetLevel10()
    {
        scoreToWin = 10;

        UpdateSelectedLevelText();

        Debug.Log("LEVEL SELECTED: 10 POINTS");
    }

    public void SetLevel20()
    {
        scoreToWin = 20;

        UpdateSelectedLevelText();

        Debug.Log("LEVEL SELECTED: 20 POINTS");
    }


    public void SetLevel30()
    {
        scoreToWin = 30;

        UpdateSelectedLevelText();

        Debug.Log("LEVEL SELECTED: 30 POINTS");
    }


    private void UpdateSelectedLevelText()
    {
        if (selectedLevelText != null)
        {
            selectedLevelText.text = "LEVEL: " + scoreToWin;
        }
    }

    public void PlayerScore()
    {
        if (!gameStarted)
            return;

        playerScore++;

        playerScoreText.text = playerScore.ToString();

        Debug.Log("Player Score: " + playerScore);

        // Check winner
        if (playerScore >= scoreToWin)
        {
            GameOver("PLAYER WINS!");
            return;
        }

        // Reset ball
        ball.ResetPosition();
    }

    public void ComputerScore()
    {
        if (!gameStarted)
            return;

        computerScore++;

        computerScoreText.text = computerScore.ToString();

        Debug.Log("Computer Score: " + computerScore);

        // Check winner
        if (computerScore >= scoreToWin)
        {
            GameOver("COMPUTER WINS!");
            return;
        }

        // Reset ball
        ball.ResetPosition();
    }

    private void GameOver(string winnerMessage)
    {
        Debug.Log("GAME OVER: " + winnerMessage);

        // Stop game
        gameStarted = false;

        // Pause physics
        Time.timeScale = 0f;

        // Set winner text
        if (winText != null)
        {
            winText.text = winnerMessage;
        }

        // Hide Game Panel
        if (gamePanel != null)
        {
            gamePanel.SetActive(false);
        }

        // Show Winner Panel
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

        // Hide Winner Panel
        winnerPanel.SetActive(false);

        // Show Game Panel
        gamePanel.SetActive(true);

        // Reset score and timer
        ResetScoreAndTimer();

        // Start game
        gameStarted = true;

        Time.timeScale = 1f;

        // Start ball
        ball.ResetPosition();
    }

    public void MainMenu()
    {
        Debug.Log("MAIN MENU");

        // Stop game
        gameStarted = false;

        // Pause game
        Time.timeScale = 0f;

        // Hide Game Panel
        gamePanel.SetActive(false);

        // Hide Winner Panel
        winnerPanel.SetActive(false);

        // Hide Level Panel
        levelPanel.SetActive(false);

        // Show Main Menu
        mainMenuPanel.SetActive(true);

        // Reset score and timer
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
        Debug.Log("GAME QUIT");

        Application.Quit();
    }
}