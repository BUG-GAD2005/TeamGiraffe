using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController
{
    UIView view;
    UIModel model;

    public UIController(UIView view, UIModel model)
    {
        this.view = view;
        this.model = model;
    }

    public void SubscribeEvents()
    {
        EventController.Instance.OnScoreEarned += UpdateScoreLabel;
        EventController.Instance.OnGameOver += EnableGameOverPanel;
    }

    private void EnableGameOverPanel()
    {
        model.gameOverPanel.SetActive(true);
    }

    private void UpdateScoreLabel(int score)
    {
        model.currentScore += score;
        model.scoreLabel.text = model.currentScore.ToString();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
