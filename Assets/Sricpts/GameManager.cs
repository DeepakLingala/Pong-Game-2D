using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Ball Settings")]
    public Ball ball;
    [Header("UI Settings")]
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI computerScoreText;

    private float _playerScore;
    private float _computerScore;

    public void PlayerScore()
    {
        _playerScore++;
        this.playerScoreText.text = _playerScore.ToString();
        Debug.Log("Player Got Point: " + _playerScore);

        this.ball.ResetPosition();
        
    }
    public void ComputerScore()
    {
        _computerScore++;
        this.computerScoreText.text = _playerScore.ToString();
        Debug.Log("Computer Got Point: " + _computerScore);

        this.ball.ResetPosition();
    }


}
