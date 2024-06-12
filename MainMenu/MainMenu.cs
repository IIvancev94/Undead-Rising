using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadSinglePlayerGame()
    {
        SceneManager.LoadScene("Singleplayer");
    }

    public void CoOpLoad()
    {
        SceneManager.LoadScene("Co_Op");
    }
}
