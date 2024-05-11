using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Rendering;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public SerializedDictionary<string,int> scores;

    [System.Serializable]
    class SaveData
    {
        [SerializeField] public SerializedDictionary<string,int> scores;
    }

    public class PlayerScore
    {
        public string name;
        public int score;
    }

    // Start is called before the first frame update
    void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        LoadScores();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScores()
    {
        SaveData data = new SaveData();
        data.scores = scores;

        string json = JsonUtility.ToJson(data,true); 

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if(data.scores != null)
            {
                scores = data.scores;
            }
            else
            {
                scores = new SerializedDictionary<string,int>();
            }
        }
        else
        {
            scores = new SerializedDictionary<string,int>();
        }
    }

    public void UpdateScores(int points)
    {
        if (!scores.ContainsKey(playerName))
        {
            scores.Add(playerName, points);
        }
        else
        {
            scores[playerName] = points;
        }
    }

    public PlayerScore GetBestScore()
    {
        PlayerScore bestScore = new PlayerScore();
        int currentScore = 0;
        string currentName = "";
        foreach (KeyValuePair<string,int> item in scores)
        {
            if (item.Value > currentScore)
            {
                currentScore = item.Value;
                currentName = item.Key;
            }
        }
        bestScore.score = currentScore;
        bestScore.name = currentName;
        return bestScore;
    }
}
