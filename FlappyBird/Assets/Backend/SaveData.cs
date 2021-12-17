using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{

    public static Data data;
    public static bool isHighscore = false;
   public static void SaveTheData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscore.score";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data _data = new Data();

        if (data != null)
        {
            if (data.score < Bird.GetInstance().GetScore())
            {
                formatter.Serialize(stream, _data);
                data = _data;
                isHighscore = true;
            }
            else
                formatter.Serialize(stream, data);
        }
        else
        {
            formatter.Serialize(stream, _data);
            data = _data;
        }
        stream.Close();
    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/highscore.score";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = formatter.Deserialize(stream) as Data;
            Debug.Log("Loaded data");
       
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    [System.Serializable]
    public class Data
    {

        public int score;

        public Data()
        {
            score = Bird.GetInstance().GetScore();
        }

    }
}
