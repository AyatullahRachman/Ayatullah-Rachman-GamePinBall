using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameOver : MonoBehaviour
{
    public Collider bola;
    public GameObject CanvasGameOver;

    private void OnTriggerEnter(Collider other)
    {
       CanvasGameOver.SetActive(true);
    }
}
