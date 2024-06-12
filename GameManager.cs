using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isCoopMode = false;
    public bool gameOver = true;
    public GameObject player;
    [SerializeField] private bool _isGameOver;
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] Animator _pauseAminamtor;


    private void Start() 
    {
        _pauseAminamtor = GameObject.Find("Pause Menu Panel").GetComponent<Animator>();
        _pauseAminamtor.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    if (Input.GetKeyDown(KeyCode.P))
    {
        _pauseMenuPanel.SetActive(true);
        _pauseAminamtor.SetBool("Paused", true);
        Time.timeScale = 1;
    }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void resumeGame()
    {
        _pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }



}