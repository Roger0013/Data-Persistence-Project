using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoresMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoresText;
    // Start is called before the first frame update
    void Start()
    {
        scoresText.text = "";
        int line = 1;
        foreach (KeyValuePair<string, int> item in DataManager.Instance.scores.OrderBy(key => -key.Value))
        {
            if(item.Key == DataManager.Instance.playerName)
            {
                scoresText.text += "<color=red>" + line + ". " + item.Key + ": " + item.Value + "</color>\n";
            }
            else
            {
                scoresText.text += line + ". " + item.Key + ": " + item.Value + "\n";
            }
            line++;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
