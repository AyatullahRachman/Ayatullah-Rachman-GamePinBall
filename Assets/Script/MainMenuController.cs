using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button playButton;
    public Button creditButton;
    public Button exitButton;


    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        creditButton.onClick.AddListener(CreditButton);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("PinBall");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CreditButton()
    {
        SceneManager.LoadScene("CreditMenu");
    }
}
