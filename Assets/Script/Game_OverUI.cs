using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_OverUI : MonoBehaviour
{
    [SerializeField] GameObject UI;
    void OnEnable()
    {
        Bus_System.OnGameOver += GameOverUI;
    }
    void OnDisable()
    {
        Bus_System.OnGameOver -= GameOverUI;
    }
    void GameOverUI()
    {
        UI.SetActive(true);
        Time.timeScale=0;
    }
}
