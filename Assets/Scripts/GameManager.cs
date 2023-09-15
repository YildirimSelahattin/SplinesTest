using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    Button restartButton;

    public GameObject endGameUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        restartButton.onClick.AddListener(RestartLevel);
    }

    void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
