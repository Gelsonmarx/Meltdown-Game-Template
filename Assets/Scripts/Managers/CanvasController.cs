using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : Singleton<CanvasController>
{
    [SerializeField] TextMeshProUGUI actualScore, endScore, highestScore;
    [SerializeField] GameObject endPanel, hud;

    public void UpdateScore(int score){
        actualScore.text = "Score: " + score;
    }

    public void EndGamePanel(int _endScore, int _highestSxcore) {
        hud.SetActive(false);
        endPanel.SetActive(true);
        endScore.text = "Final Score: " + _endScore;
        highestScore.text = "Highest Score: " + _highestSxcore;
    }

    public void BackMenu() => GameManager.Instance.BackMenu();
    public void RestartLevel() => GameManager.Instance.RestartLevel();
}
