using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManagment : MonoBehaviour
{
    [SerializeField] internal GameHandle gameHandle;
    [SerializeField] internal ScoreScript scoreScript;
    [SerializeField] internal BestScore bestScore;

    public GameObject gameOverPanel;
    public GameObject gamePanel;
    public GameObject menuPanel;
    public GameObject pausePanel;



    internal void CloseGameOverPanel()
    {
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameHandle.ResumeGame();
    }
    internal void OpenGameOverPanel()
    {
        gamePanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    internal void OpenGameMenuPanel()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    internal void ClosedGameMenuPanel()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameHandle.ResumeGame();
    }
}
