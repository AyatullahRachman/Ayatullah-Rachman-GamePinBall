using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditController : MonoBehaviour
{
    public Button CreditButton;

    private void Start()
    {
        CreditButton.onClick.AddListener(creditButtonMenu);
    }

    public void creditButtonMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
