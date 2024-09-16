using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUiController : MonoBehaviour
{
    public Button mainmenuButton; 
    private void Start()
    {
        mainmenuButton.onClick.AddListener(MainMenu);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("PinBall");
    }

   public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
