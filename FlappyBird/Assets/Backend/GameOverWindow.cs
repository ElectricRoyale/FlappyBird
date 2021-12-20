using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverWindow : MonoBehaviour
{

    public Text scoreText;
    public Text highscoreText;
    public GameObject ScoreBoard;
    public Image newHighscore;

    // Start is called before the first frame update
    void Start()
    {
        Bird.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }

    private void Bird_OnDied(object sender, EventArgs e)
    {
        scoreText.text = Bird.GetInstance().GetScore().ToString();
        highscoreText.text = SaveData.data.score.ToString();
        newHighscore.enabled = SaveData.isHighscore;
        Show();
    }

    public void Replay()
    {
        SoundManager.PlaySound(SoundManager.Sound.Start);
        Loader.Load(Loader.Scene.MainScene);
        SaveData.isHighscore = false;
    }

    private void Show()
    {
        gameObject.SetActive(true);
        ScoreBoard.SetActive(false);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
