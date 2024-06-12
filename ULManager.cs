using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;
using UnityEngine.SocialPlatforms.Impl;

public class ULManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText, bestText;
    [SerializeField] private Sprite[] _liveSprites;
    [SerializeField] private Image _livesImg;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _restartText;
    public int bestScore, score;

    private GameManager _gameManager;


    void Start()
    {
        bestScore = PlayerPrefs.GetInt("HighScore", 0);
        bestText.text = "Best: " + bestScore;
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("GameManager is NULL");
        }
    }

    public void updateScore(int playerScore)
    {
        _scoreText.text = "Score " + playerScore.ToString();
    }

    public void CheckForBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("HighScore", bestScore);
            bestText.text = "Best: " + bestScore;
        }
    }
    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _liveSprites[currentLives];

        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }

    public void GameOverSequence()
    {
            _gameManager.GameOver();
            _gameOverText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
            StartCoroutine(gameOverFlickerRoutine());
    }

    IEnumerator gameOverFlickerRoutine()
    {
        while(true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void resumeGame()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.resumeGame();
    }

    public void quitMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }
}