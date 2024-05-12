using System;
using System.Collections;
using System.Collections.Generic;
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
        foreach (KeyValuePair<string, int> item in DataManager.Instance.scores)
        {
            if(item.Key == DataManager.Instance.playerName)
            {
                scoresText.text += "<color=red>" + item.Key + ": " + item.Value + "</color>\n";
            }
            else
            {
                scoresText.text += item.Key + ": " + item.Value + "\n";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
