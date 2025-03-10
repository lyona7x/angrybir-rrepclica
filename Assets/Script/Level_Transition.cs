using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Transition : MonoBehaviour
{
    private Button button;
    [SerializeField] string LevelName;
    
    void OnEnable()
    {
        Bus_System.OnGameOver += LevelTransition;
        button = GetComponent<Button>();
        button.onClick.AddListener(LevelTransition);
    }

    void OnDisable()
    {
        Bus_System.OnGameOver -= LevelTransition;
    }

    void LevelTransition()
    {
        SceneManager.LoadScene(LevelName);
    }
}
