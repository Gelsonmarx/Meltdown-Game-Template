using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    int score = 0;

    Rotator rotator;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        rotator = FindObjectOfType<Rotator>();
    }

    public void AddScore() {
        score++;
        CanvasController.Instance.UpdateScore(score);
        SoundManager.Instance.PlaySoundSFX(SFXType.win);
        rotator.AddSpeed();
    }

    public void EndGame() {
        var player = FindObjectOfType<PlayerBehaviour>();
        player.PlayerDead();
        int highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        if(score > highestScore) highestScore = score;

        PlayerPrefs.SetInt("HighestScore", highestScore);
        CanvasController.Instance.EndGamePanel(score, highestScore);
        SoundManager.Instance.PlaySoundSFX(SFXType.lose);
    }

    public void RestartLevel() => SceneManager.LoadScene(1);
    public void BackMenu() => SceneManager.LoadScene(0);

}
