using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartPlaying()
    {
        SoundManager.PlaySound(SoundManager.Sound.Start);
        Loader.Load(Loader.Scene.MainScene);
    }

    private void Start()
    {
        SaveData.Data data = SaveData.LoadData();

        if (data != null)
        {
            transform.Find("Highscore").GetComponent<UnityEngine.UI.Text>().text = "Highscore: " + data.score.ToString();
        }
        else
        {
            transform.Find("Highscore").GetComponent<UnityEngine.UI.Text>().text = "";
        }
    }

}
