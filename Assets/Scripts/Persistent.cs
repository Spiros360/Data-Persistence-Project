using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class Persistent : MonoBehaviour
{
    public static Persistent Instance;
    
    public int bestScore;
    public int score;
    public string textName;
    


    // Start() and Update() methods deleted - we don't need them right now

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public int score;
        public string textName;
    }

    public void SaveScore()
    {

        if (score > bestScore)
        {

            bestScore = score;
            SaveData data = new SaveData();
       
            data.bestScore = bestScore;
            data.textName = textName;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

            
        }
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);


            bestScore = data.bestScore;
            textName = data.textName;
           
        }
    }
}
