using UnityEngine;
using TMPro;
using System;

[Serializable]
public class UIModel
{
    public int currentScore;
    public TextMeshProUGUI scoreLabel;
    public GameObject gameOverPanel;
    public bool isRestartRequested;
}
