using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private Text _scoreText;
    private Text _highscoreText;
    private Image _newHighscore;
    public bool isHighscore = false;

    public static ScoreBoard Instance;

    public static ScoreBoard GetInstance()
    {
        return Instance;
    }

    public bool IsHighscore()
    {
        return isHighscore;
    }

    private void Awake()
    {
        Instance = this;
        _scoreText = transform.Find("ScoreText").GetComponent<Text>();
        _highscoreText = transform.Find("Highscore").GetComponent<Text>();
        _newHighscore = transform.Find("new").GetComponent<Image>();
        if(SaveData.data != null) _highscoreText.text = "Highscore: " + SaveData.data.score.ToString();
    }

    private void Update()
    {
        _scoreText.text = Bird.GetInstance().GetScore().ToString();
        if (SaveData.data != null && Bird.GetInstance().GetScore() > SaveData.data.score)
        {
            _newHighscore.enabled = true;
            _highscoreText.text = "Highscore: " + Bird.GetInstance().GetScore().ToString();
            isHighscore = true;
        }
        else if (SaveData.data == null)
        {
            _highscoreText.text = "Highscore: " + Bird.GetInstance().GetScore().ToString();
        }
    }
}
